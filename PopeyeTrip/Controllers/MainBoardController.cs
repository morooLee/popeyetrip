using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PopEyeTrip.Abstract;
using PopEyeTrip.Entities;
using PopEyeTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PopEyeTrip.Controllers
{
    [AllowAnonymous]
    //[Authorize]
    public class MainBoardController : BaseController
    {
        private IBannerRepository BannerRepository;
        private IMainBoardRepository MainBoardRepository;
        private IHashTagRepository HashTagRepository;
        private ILikeRepository LikeRepository;

        public MainBoardController(IBannerRepository bannerRepository, IMainBoardRepository mainBoardRepository, IHashTagRepository hashTagRepository, ILikeRepository likeRepository)
        {
            this.BannerRepository = bannerRepository;
            this.MainBoardRepository = mainBoardRepository;
            this.HashTagRepository = hashTagRepository;
            this.LikeRepository = likeRepository;
        }
        
        public ViewResult Index(int MainBoard_DetailID)
        {
            MainBoardViewModel model = new MainBoardViewModel();
            List<int> DetailIDs = new List<int>();
            List<HashTag_MainDetail> tmpHashTag = new List<HashTag_MainDetail>();

            // 조회수 올리기
            MainBoardRepository.HitsAdd(MainBoard_DetailID);

            model.MainBoardDetail = MainBoardRepository.MainBoardDetails.FirstOrDefault(p => p.MainBoard_DetailID == MainBoard_DetailID);
            model.MainBoardDetail.PopEyePoints = MainBoardRepository.MainBoardPoints.Where(p => p.MainBoard_DetailID == MainBoard_DetailID).ToList();
            model.MainBoardDetail.KoreanStudies = MainBoardRepository.MainBoardStudies.Where(p => p.MainBoard_DetailID == MainBoard_DetailID).ToList();
            model.MainBoardDetail.StillCuts = MainBoardRepository.MainBoardStillCuts.Where(p => p.MainBoard_DetailID == MainBoard_DetailID).ToList();
            model.MainBoardDetail.HashTags = HashTagRepository.HashTag_MainDetails.Where(p => p.MainBoard_DetailID == MainBoard_DetailID).ToList();

            // 해시태그와 동일한 태그가 있는 게시글 가져오기
            for (int i = 0; i < model.MainBoardDetail.HashTags.Count; i++)
            {
                tmpHashTag.AddRange(HashTagRepository.HashTag_MainDetails.Where(p => p.TagName == model.MainBoardDetail.HashTags[i].TagName && p.MainBoard_DetailID != MainBoard_DetailID));
            }

            // 중복값 제거하고 아이디만 가져오기
            foreach (HashTag_MainDetail item in tmpHashTag)
            {
                if (!DetailIDs.Contains(item.MainBoard_DetailID))
                {
                    DetailIDs.Add(item.MainBoard_DetailID);
                }
            }
            DetailIDs.OrderByDescending(p => p);
            foreach (int item in DetailIDs)
            {
                model.MainBoardLists.Add(MainBoardRepository.MainBoardLists.FirstOrDefault(p => p.MainBoard_DetailID == item));
            }

            if (model.MainBoardDetail.YoutubeUrl != null)
            {
                String[] tmpUrl = System.Text.RegularExpressions.Regex.Split(model.MainBoardDetail.YoutubeUrl, "/");
                model.YoutubeUrl = tmpUrl.Last();
            }

            PopEyeLike Liked = LikeRepository.Likes.Where(p => p.MainBoard_DetailID == MainBoard_DetailID).FirstOrDefault(m => m.UserID == User.Identity.GetUserId());

            if(Liked == null)
            {
                model.Liked = false;
            }
            else
            {
                model.Liked = true;
            }

            return View((object)model);
        }
        
        [HttpPost]
        public ViewResult Index(MainBoardListViewModel model)
        {
            return View();
        }

        public PartialViewResult _RelatedPartial(int? page, int mainBoard_DetailID)
        {
            List<MainBoard_List> customers = null;
            List<HashTag_MainDetail> HashTag_Details = HashTagRepository.HashTag_MainDetails.Where(p => p.MainBoard_DetailID == mainBoard_DetailID).ToList();
            List<HashTag_MainDetail> tmpHashTag_Details = new List<HashTag_MainDetail>();
            List<int> DetailIDs = new List<int>();

            // 해시태그와 동일한 태그가 있는 게시글 가져오기
            for (int i = 0; i < HashTag_Details.Count; i++)
            {
                tmpHashTag_Details.AddRange(HashTagRepository.HashTag_MainDetails.Where(p => p.TagName == HashTag_Details[i].TagName && p.MainBoard_DetailID != mainBoard_DetailID));
            }
            // 중복값 제거하고 아이디만 가져오기
            foreach (HashTag_MainDetail item in tmpHashTag_Details)
            {
                if (!DetailIDs.Contains(item.MainBoard_DetailID))
                {
                    DetailIDs.Add(item.MainBoard_DetailID);
                }
            }
            DetailIDs.OrderByDescending(p => p);
            foreach (int item in DetailIDs)
            {
                customers.Add(MainBoardRepository.MainBoardLists.FirstOrDefault(p => p.MainBoard_DetailID == item));
            }

            return PartialView(customers);
        }

        public PartialViewResult _PopEyeLikePartial(int popEyeLikes)
        {
            return PartialView(popEyeLikes);
        }

        [HttpPost]
        public PartialViewResult _PopEyeLikePartial(int popEyeLikes, int mainBoard_DetailID)
        {
            PopEyeLike like = new PopEyeLike();
            like.MainBoard_DetailID = mainBoard_DetailID;
            like.UserID = User.Identity.GetUserId();

            LikeRepository.SaveLike(like);

            MainBoard_Detail detail = MainBoardRepository.MainBoardDetails.FirstOrDefault(p => p.MainBoard_DetailID == mainBoard_DetailID);
            detail.PopEyeLike += 1;
            MainBoardRepository.SaveDetail(detail);

            MainBoard_List list = MainBoardRepository.MainBoardLists.FirstOrDefault(p => p.MainBoard_DetailID == mainBoard_DetailID);
            list.PopEyeLike += 1;
            MainBoardRepository.SaveList(list);

            return PartialView(detail.PopEyeLike);
        }
    }
}