using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PopEyeTrip.Abstract;
using PopEyeTrip.Concrete;
using PopEyeTrip.Entities;
using PopEyeTrip.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PopEyeTrip.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        private ApplicationDbContext context;

        private IBannerRepository BannerRepository;
        private IMainBoardRepository MainBoardRepository;
        private IHashTagRepository HashTagRepository;
        public int MainBoardPageSize = 10;

        public AdminController(IBannerRepository bannerRepository, IMainBoardRepository mainBoardRepository, IHashTagRepository hashTagRepository)
        {
            BannerRepository = bannerRepository;
            MainBoardRepository = mainBoardRepository;
            HashTagRepository = hashTagRepository;
            context = new ApplicationDbContext();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Slider
        public ViewResult Banner()
        {
            return View(BannerRepository.Banners);
        }

        public ViewResult BannerAdd()
        {
            return View("BannerEdit", new Banner());
        }

        public ViewResult BannerEdit(int ID)
        {
            Banner banner = BannerRepository.Banners.FirstOrDefault(p => p.ID == ID);
            return View(banner);
        }

        [HttpPost]
        public ActionResult BannerEdit(Banner banner, HttpPostedFileBase imagePath)
        {
            if (ModelState.IsValid)
            {
                if (imagePath != null)
                {
                    Image img = Image.FromStream(imagePath.InputStream);

                    DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Assets/Banner/"));
                    if (dir.Exists == false)
                    {
                        dir.Create();
                    }

                    if (img.Width != 940 || img.Height != 528)
                    {
                        ModelState.AddModelError("", "Image resolution must be 940 x 528 pixels");
                        return View(banner);
                    }

                    string pic = Path.GetFileName(imagePath.FileName);
                    string path = Path.Combine(Server.MapPath("~/Assets/Banner/"), pic);

                    Banner tmpBanner = BannerRepository.Banners.FirstOrDefault(p => p.ImagePath == "~/Assets/Banner/" + pic);

                    if (tmpBanner != null)
                    {
                        ModelState.AddModelError("", "there is already a file with the same name");
                        return View(banner);
                    }
                    else
                    {
                        imagePath.SaveAs(path);
                        banner.ImagePath = "~/Assets/Banner/" + pic;
                    }
                }
                if (banner.RegisterDate == null)
                {
                    banner.RegisterDate = DateTime.Now;
                }
                if (banner.Writer == null)
                {
                    banner.Writer = User.Identity.Name;
                }

                BannerRepository.SaveBanner(banner);
                TempData["message"] = string.Format("have been successfully saved.");
                return RedirectToAction("Banner");
            }
            else
            {
                return View(banner);
            }
        }

        [HttpPost]
        public ActionResult BannerDelete(int bannerID)
        {
            Banner banner = BannerRepository.DeleteBanner(bannerID);

            System.IO.File.Delete(Server.MapPath(banner.ImagePath));
            if (banner == null)
            {
                TempData["message"] = string.Format("have been successfully deleted.");
            }
            return RedirectToAction("Banner");
        }

        public ViewResult MainBoard(int page = 1)
        {
            MainBoardListViewModel model = new MainBoardListViewModel
            {
                MainBoardLists = MainBoardRepository.MainBoardLists.OrderByDescending(p => p.MainBoard_DetailID).Skip((page - 1) * MainBoardPageSize).Take(MainBoardPageSize),
                PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = MainBoardPageSize, TotalItems = MainBoardRepository.MainBoardLists.Count() }
            };

            return View(model);
        }

        public ViewResult MainBoardAdd()
        {
            return View("MainBoardEdit", new MainBoard_Detail());
        }

        public ViewResult MainBoardEdit(int MainBoard_DetailID)
        {
            MainBoard_Detail detail = MainBoardRepository.MainBoardDetails.FirstOrDefault(p => p.MainBoard_DetailID == MainBoard_DetailID);

            IEnumerable<MainBoard_Point> points = MainBoardRepository.MainBoardPoints.Where(p => p.MainBoard_DetailID == MainBoard_DetailID);
            if (points.ToList().Count > 0)
            {
                detail.PopEyePoints = points.ToList();
            }

            IEnumerable<MainBoard_KoreanStudy> studies = MainBoardRepository.MainBoardStudies.Where(p => p.MainBoard_DetailID == MainBoard_DetailID);
            if(studies.ToList().Count > 0)
            {
                detail.KoreanStudies = studies.ToList();
            }

            IEnumerable<MainBoard_StillCut> stillCuts = MainBoardRepository.MainBoardStillCuts.Where(p => p.MainBoard_DetailID == MainBoard_DetailID).OrderBy(m => m.ID);
            if (studies.ToList().Count > 0)
            {
                detail.StillCuts = stillCuts.ToList();
            }

            IEnumerable<HashTag_MainDetail> hashTags = HashTagRepository.HashTag_MainDetails.Where(p => p.MainBoard_DetailID == MainBoard_DetailID);
            if (studies.ToList().Count > 0)
            {
                detail.HashTags = hashTags.ToList();
            }

            return View(detail);
        }

        [HttpPost]
        public ActionResult MainBoardEdit(MainBoard_Detail detail, HttpPostedFileBase mainPath,  HttpPostedFileBase[] stillCutPaths)
        {
            MainBoard_List check = MainBoardRepository.MainBoardLists.FirstOrDefault(p => p.MainBoard_DetailID == detail.MainBoard_DetailID);
            MainBoard_List list = null;

            if (ModelState.IsValid)
            {
                // 추가인지 수정인지 체크
                if (check == null)
                {
                    // 추가인 경우 초기화
                    list = new MainBoard_List();
                    MainBoardRepository.SaveDetail(new MainBoard_Detail());
                    MainBoardRepository.SaveList(list);
                    detail.MainBoard_DetailID = MainBoardRepository.MainBoardDetails.LastOrDefault().MainBoard_DetailID;
                    list = MainBoardRepository.MainBoardLists.LastOrDefault();
                }
                else
                {
                    list = check;
                }
                // 메인이미지 저장
                #region 메인이미지
                if (mainPath != null)
                {
                    Image img = Image.FromStream(mainPath.InputStream);
                    string pic = Path.GetFileName(mainPath.FileName);
                    string path = null;

                    DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Assets/PopEyeBoard/" + detail.MainBoard_DetailID + "/Main/"));
                    if (dir.Exists == false)
                    {
                        dir.Create();
                    }

                    path = Path.Combine(Server.MapPath("~/Assets/PopEyeBoard/" + detail.MainBoard_DetailID + "/Main/"), pic);
                    detail.MainImgagePath = "~/Assets/PopEyeBoard/" + detail.MainBoard_DetailID + "/Main/" + pic;
                    mainPath.SaveAs(path);
                }
                #endregion

                // Point 수정
                #region 포인트
                for (int i = 0; i < detail.PopEyePoints.Count; i++)
                {
                    detail.PopEyePoints[i].MainBoard_DetailID = detail.MainBoard_DetailID;
                }

                if (detail.PopEyePoints.Count > 0)
                {
                    MainBoardRepository.ChangePoints(detail.PopEyePoints, detail.MainBoard_DetailID);
                }
                #endregion

                // Study 수정
                #region 스터디
                for (int i = 0; i < detail.KoreanStudies.Count; i++)
                {
                    detail.KoreanStudies[i].MainBoard_DetailID = detail.MainBoard_DetailID;
                }

                if (detail.KoreanStudies.Count > 0)
                {
                    MainBoardRepository.ChangeStudies(detail.KoreanStudies, detail.MainBoard_DetailID);
                }
                #endregion

                // 스틸컷
                #region 스틸컷
                if (stillCutPaths.Length > 0)
                {
                    List<MainBoard_StillCut> tmpStillCuts = new List<MainBoard_StillCut>();
                    for (int i = 0; i < (stillCutPaths.Length); i++)
                    {
                        if (stillCutPaths[i] != null)
                        {
                            Image img = Image.FromStream(stillCutPaths[i].InputStream);
                            string pic = Path.GetFileName(stillCutPaths[i].FileName);
                            string path = null;

                            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Assets/PopEyeBoard/" + detail.MainBoard_DetailID + "/StillCuts/"));
                            if (dir.Exists == false)
                            {
                                dir.Create();
                            }
                            detail.StillCuts[i].MainBoard_DetailID = detail.MainBoard_DetailID;
                            detail.StillCuts[i].StillCutPath = "~/Assets/PopEyeBoard/" + detail.MainBoard_DetailID + "/StillCuts/" + pic;
                            path = Path.Combine(Server.MapPath("~/Assets/PopEyeBoard/" + detail.MainBoard_DetailID + "/StillCuts/"), pic);
                            stillCutPaths[i].SaveAs(path);
                        }
                    }

                    MainBoardRepository.ChangeStillCuts(detail.StillCuts, detail.MainBoard_DetailID);
                }
                #endregion

                // 해시태그
                #region 해시태그
                if (detail.HashTags.Count > 0)
                {
                    List<HashTag_MainDetail> tmpHashTags = new List<HashTag_MainDetail>();
                    for (int i = 0; i < detail.HashTags.Count; i++)
                    {
                        if (!tmpHashTags.Contains(detail.HashTags[i]))
                        {
                            tmpHashTags.Add(detail.HashTags[i]);
                        }
                    }
                    for (int i = 0; i < tmpHashTags.Count; i++)
                    {
                        tmpHashTags[i].MainBoard_DetailID = detail.MainBoard_DetailID;
                    }
                    detail.HashTags = tmpHashTags;

                    HashTagRepository.ChangeHashTags(detail.HashTags, detail.MainBoard_DetailID);
                } 
                #endregion




                // 생성일 추가
                DateTime now = DateTime.Now;
                if (detail.RegisterDate == null)
                {
                    detail.RegisterDate = now;
                }
                // 수정일 수정
                detail.EditDate = now;
                // 작성자 수정
                detail.Writer = User.Identity.Name;    
                // 리스트 업데이트
                list.MainImgagePath = detail.MainImgagePath;
                list.MainTitle = detail.MainTitle;
                list.SubTitle = detail.SubTitle;
                list.PopEyeLike = detail.PopEyeLike;
                list.Hits = detail.Hits;
                list.Category = detail.Category;
                list.isFollow = detail.isFollow;
                list.isMission = detail.isMission;
                list.RegisterDate = detail.RegisterDate;
                // 디테일 및 리스트 저장
                MainBoardRepository.SaveDetail(detail);
                MainBoardRepository.SaveList(list);
                // 에러 메시지 출력
                TempData["message"] = string.Format("have been successfully saved.");
                return RedirectToAction("MainBoard");
            }
            else
            {
                return View(detail);
            }
        }

        [HttpPost]
        public ActionResult MainBoardDelete(int MainBoard_DetailID)
        {
            MainBoard_Detail detail = MainBoardRepository.MainBoardDetails.FirstOrDefault(p => p.MainBoard_DetailID == MainBoard_DetailID);

            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Assets/PopEyeBoard/" + MainBoard_DetailID + "/"));

            if (dir.Exists == true)
            {
                try
                {
                    FileInfo[] files = dir.GetFiles("*.*", SearchOption.AllDirectories);
                    foreach (FileInfo file in files)
                    {
                        file.Attributes = FileAttributes.Normal;
                    }
                    Directory.Delete(Server.MapPath("~/Assets/PopEyeBoard/" + MainBoard_DetailID + "/"), true);
                }
                catch (Exception)
                {
                }
            }

            if (detail == null)
            {
                TempData["message"] = string.Format("have been successfully deleted.");
            }

            MainBoardRepository.DeleteList(MainBoard_DetailID);
            MainBoardRepository.DeletePoint(MainBoard_DetailID);
            MainBoardRepository.DeleteStudy(MainBoard_DetailID);
            MainBoardRepository.DeleteStillCut(MainBoard_DetailID);
            HashTagRepository.DeleteHashTags(MainBoard_DetailID);
            MainBoardRepository.DeleteDetail(MainBoard_DetailID);

            return RedirectToAction("MainBoard");
        }

        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns></returns>
        public ActionResult Role()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        /// <summary>
        /// Create  a New role
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleEdit()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        /// <summary>
        /// Create a New Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RoleEdit(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Role");
        }
    }
}