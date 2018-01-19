using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PopEyeTrip.Concrete;
using PopEyeTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PopEyeTrip.Abstract;
using PopEyeTrip.Entities;
using System.Threading;

namespace PopEyeTrip.Controllers
{
    [AllowAnonymous]
    //[RequireHttps]
    public class HomeController : BaseController
    {
        private IBannerRepository BannerRepository;
        private IMainBoardRepository MainBoardRepository;
        private IHashTagRepository HashTagRepository;

        public HomeController(IBannerRepository bannerRepository, IMainBoardRepository mainBoardRepository, IHashTagRepository hashTagRepository)
        {
            this.BannerRepository = bannerRepository;
            this.MainBoardRepository = mainBoardRepository;
            this.HashTagRepository = hashTagRepository;
        }

        int pageSize = 10;
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _SliderPartial()
        {
            return PartialView(BannerRepository.Banners);
        }

        public PartialViewResult _MainBoardPartial(int? page, string category, string sort)
        {
            IEnumerable<MainBoard_List> customers = null;

            if (!page.HasValue)
            {
                if (category == null)
                {
                    if (sort == null)
                    {
                        customers = MainBoardRepository.MainBoardLists.OrderByDescending(f => f.MainBoard_DetailID).Take(pageSize);
                    }
                    if (sort == "Updated")
                    {
                        customers = MainBoardRepository.MainBoardLists.OrderByDescending(f => f.MainBoard_DetailID).Take(pageSize);
                    }
                    if (sort == "PopEyed")
                    {
                        customers = MainBoardRepository.MainBoardLists.OrderByDescending(f => f.PopEyeLike).Take(pageSize);
                    }
                    if (sort == "Hits")
                    {
                        customers = MainBoardRepository.MainBoardLists.OrderByDescending(f => f.Hits).Take(pageSize);
                    }
                }
                else if (category == "All")
                {
                    if (sort == null)
                    {
                        customers = MainBoardRepository.MainBoardLists.OrderByDescending(f => f.MainBoard_DetailID).Take(pageSize);
                    }
                    if (sort == "Updated")
                    {
                        customers = MainBoardRepository.MainBoardLists.OrderByDescending(f => f.MainBoard_DetailID).Take(pageSize);
                    }
                    if (sort == "PopEyed")
                    {
                        customers = MainBoardRepository.MainBoardLists.OrderByDescending(f => f.PopEyeLike).Take(pageSize);
                    }
                    if (sort == "Hits")
                    {
                        customers = MainBoardRepository.MainBoardLists.OrderByDescending(f => f.Hits).Take(pageSize);
                    }
                }
                else if (category == "Follow")
                {
                    if (sort == null)
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.isFollow == true).OrderByDescending(f => f.MainBoard_DetailID).Take(pageSize);
                    }
                    if (sort == "Updated")
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.isFollow == true).OrderByDescending(f => f.MainBoard_DetailID).Take(pageSize);
                    }
                    if (sort == "PopEyed")
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.isFollow == true).OrderByDescending(f => f.PopEyeLike).Take(pageSize);
                    }
                    if (sort == "Hits")
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.isFollow == true).OrderByDescending(f => f.Hits).Take(pageSize);
                    }
                }
                else if (category == "Mission")
                {
                    if (sort == null)
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.isMission == true).OrderByDescending(f => f.MainBoard_DetailID).Take(pageSize);
                    }
                    if (sort == "Updated")
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.isMission == true).OrderByDescending(f => f.MainBoard_DetailID).Take(pageSize);
                    }
                    if (sort == "PopEyed")
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.isMission == true).OrderByDescending(f => f.PopEyeLike).Take(pageSize);
                    }
                    if (sort == "Hits")
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.isMission == true).OrderByDescending(f => f.Hits).Take(pageSize);
                    }
                }
                else
                {
                    if (sort == null)
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.Category == category).OrderByDescending(f => f.MainBoard_DetailID).Take(pageSize);
                    }
                    if (sort == "Updated")
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.Category == category).OrderByDescending(f => f.MainBoard_DetailID).Take(pageSize);
                    }
                    if (sort == "PopEyed")
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.Category == category).OrderByDescending(f => f.PopEyeLike).Take(pageSize);
                    }
                    if (sort == "Hits")
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.Category == category).OrderByDescending(f => f.Hits).Take(pageSize);
                    }
                }
            }
            else
            {
                int pageIndex = pageSize * page.Value;

                if (category == null)
                {
                    if (sort == null)
                    {
                        customers = MainBoardRepository.MainBoardLists.OrderByDescending(f => f.MainBoard_DetailID).Skip(pageIndex).Take(pageSize);
                    }
                    if (sort == "Updated")
                    {
                        customers = MainBoardRepository.MainBoardLists.OrderByDescending(f => f.MainBoard_DetailID).Skip(pageIndex).Take(pageSize);
                    }
                    if (sort == "PopEyed")
                    {
                        customers = MainBoardRepository.MainBoardLists.OrderByDescending(f => f.PopEyeLike).Skip(pageIndex).Take(pageSize);
                    }
                    if (sort == "Hits")
                    {
                        customers = MainBoardRepository.MainBoardLists.OrderByDescending(f => f.Hits).Skip(pageIndex).Take(pageSize);
                    }
                }
                else if (category == "All")
                {
                    if (sort == null)
                    {
                        customers = MainBoardRepository.MainBoardLists.OrderByDescending(f => f.MainBoard_DetailID).Skip(pageIndex).Take(pageSize);
                    }
                    if (sort == "Updated")
                    {
                        customers = MainBoardRepository.MainBoardLists.OrderByDescending(f => f.MainBoard_DetailID).Skip(pageIndex).Take(pageSize);
                    }
                    if (sort == "PopEyed")
                    {
                        customers = MainBoardRepository.MainBoardLists.OrderByDescending(f => f.PopEyeLike).Skip(pageIndex).Take(pageSize);
                    }
                    if (sort == "Hits")
                    {
                        customers = MainBoardRepository.MainBoardLists.OrderByDescending(f => f.Hits).Skip(pageIndex).Take(pageSize);
                    }
                }
                else if (category == "Follow")
                {
                    if (sort == null)
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.isFollow == true).OrderByDescending(f => f.MainBoard_DetailID).Skip(pageIndex).Take(pageSize);
                    }
                    if (sort == "Updated")
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.isFollow == true).OrderByDescending(f => f.MainBoard_DetailID).Skip(pageIndex).Take(pageSize);
                    }
                    if (sort == "PopEyed")
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.isFollow == true).OrderByDescending(f => f.PopEyeLike).Skip(pageIndex).Take(pageSize);
                    }
                    if (sort == "Hits")
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.isFollow == true).OrderByDescending(f => f.Hits).Skip(pageIndex).Take(pageSize);
                    }
                }
                else if (category == "Mission")
                {
                    if (sort == null)
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.isMission == true).OrderByDescending(f => f.MainBoard_DetailID).Skip(pageIndex).Take(pageSize);
                    }
                    if (sort == "Updated")
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.isMission == true).OrderByDescending(f => f.MainBoard_DetailID).Skip(pageIndex).Take(pageSize);
                    }
                    if (sort == "PopEyed")
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.isMission == true).OrderByDescending(f => f.PopEyeLike).Skip(pageIndex).Take(pageSize);
                    }
                    if (sort == "Hits")
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.isMission == true).OrderByDescending(f => f.Hits).Skip(pageIndex).Take(pageSize);
                    }
                }
                else
                {
                    if (sort == null)
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.Category == category).OrderByDescending(f => f.MainBoard_DetailID).Skip(pageIndex).Take(pageSize);
                    }
                    if (sort == "Updated")
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.Category == category).OrderByDescending(f => f.MainBoard_DetailID).Skip(pageIndex).Take(pageSize);
                    }
                    if (sort == "PopEyed")
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.Category == category).OrderByDescending(f => f.PopEyeLike).Skip(pageIndex).Take(pageSize);
                    }
                    if (sort == "Hits")
                    {
                        customers = MainBoardRepository.MainBoardLists.Where(f => f.Category == category).OrderByDescending(f => f.Hits).Skip(pageIndex).Take(pageSize);
                    }
                }
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView(customers);
            }
            return PartialView(customers);
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        public ActionResult Agreement()
        {
            return View();
        }
    }
}