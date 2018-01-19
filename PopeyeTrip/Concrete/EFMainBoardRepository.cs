using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PopEyeTrip.Entities;
using PopEyeTrip.Abstract;

namespace PopEyeTrip.Concrete
{
    public class EFMainBoardRepository : IMainBoardRepository
    {
        // 디비 연결
        private EFDbContext context = new EFDbContext();

        // 리스트
        public IEnumerable<MainBoard_List> MainBoardLists
        {
            get { return context.MainBoardLists; }
        }
        //리스트 저장
        public void SaveList(MainBoard_List list)
        {
            if (list.MainBoard_DetailID == 0)
            {
                context.MainBoardLists.Add(list);
            }
            else
            {
                MainBoard_List dbEntry = context.MainBoardLists.Find(list.MainBoard_DetailID);
                if (dbEntry != null)
                {
                    dbEntry = list;
                }
            }
            context.SaveChanges();
        }
        // 리스트 삭제
        public MainBoard_List DeleteList(int listID)
        {
            MainBoard_List dbEntry = context.MainBoardLists.Find(listID);
            if (dbEntry != null)
            {
                context.MainBoardLists.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        // 디테일
        public IEnumerable<MainBoard_Detail> MainBoardDetails
        {
            get { return context.MainBoardDetails; }
        }
        // 디테일 저장
        public void SaveDetail(MainBoard_Detail detail)
        {
            if (detail.MainBoard_DetailID == 0)
            {
                context.MainBoardDetails.Add(detail);
            }
            else
            {
                MainBoard_Detail dbEntry = context.MainBoardDetails.Find(detail.MainBoard_DetailID);
                if (dbEntry != null)
                {
                    dbEntry.MainBoard_DetailID = detail.MainBoard_DetailID;
                    dbEntry.MainImgagePath = detail.MainImgagePath;
                    dbEntry.MainTitle = detail.MainTitle;
                    dbEntry.SubTitle = detail.SubTitle;
                    dbEntry.PopEyeLike = detail.PopEyeLike;
                    dbEntry.Hits = detail.Hits;
                    dbEntry.YoutubeUrl = detail.YoutubeUrl;
                    dbEntry.Category = detail.Category;
                    dbEntry.isFollow = detail.isFollow;
                    dbEntry.isMission = detail.isMission;
                    dbEntry.PopEyePoints = detail.PopEyePoints;
                    dbEntry.PlaceTitle = detail.PlaceTitle;
                    dbEntry.BusinessType = detail.BusinessType;
                    dbEntry.PlaceBody = detail.PlaceBody;
                    dbEntry.BusinessOpen = detail.BusinessOpen;
                    dbEntry.BusinessClose = detail.BusinessClose;
                    dbEntry.WeekendOpen = detail.WeekendOpen;
                    dbEntry.WeekendClose = detail.WeekendClose;
                    dbEntry.BreakTimeStart = detail.BreakTimeStart;
                    dbEntry.BreakTimeEnd = detail.BreakTimeEnd;
                    dbEntry.Holiday = detail.Holiday;
                    dbEntry.KoreanStudies = detail.KoreanStudies;
                    dbEntry.PopEyeTripBody = detail.PopEyeTripBody;
                    dbEntry.Direction = detail.Direction;
                    dbEntry.Latitude = detail.Latitude;
                    dbEntry.Longitude = detail.Longitude;
                    dbEntry.StillCuts = detail.StillCuts;
                    dbEntry.RegisterDate = detail.RegisterDate;
                    dbEntry.EditDate = detail.EditDate;
                    dbEntry.Writer = detail.Writer;
                    //dbEntry = detail;
                }
            }
            context.SaveChanges();
        }
        // 디테일 삭제
        public MainBoard_Detail DeleteDetail(int detailID)
        {
            MainBoard_Detail dbEntry = context.MainBoardDetails.Find(detailID);
            if (dbEntry != null)
            {
                context.MainBoardDetails.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        // 조회수 증가
        public void HitsAdd(int MainBoard_DetailID)
        {
            if (MainBoard_DetailID > 0)
            {
                MainBoard_Detail dbEntry = context.MainBoardDetails.FirstOrDefault(p => p.MainBoard_DetailID == MainBoard_DetailID);
                dbEntry.Hits += 1;
                context.SaveChanges();
            }
        }

        // 포인트
        public IEnumerable<MainBoard_Point> MainBoardPoints
        {
            get { return context.MainBoardPoints; }
        }
        // 포인트 수정
        public void ChangePoints(List<MainBoard_Point> points, int MainBoard_DetailID)
        {
            List<MainBoard_Point> dbEntries = context.MainBoardPoints.Where(p => p.MainBoard_DetailID == MainBoard_DetailID).ToList();
            for (int i = 0; i < dbEntries.Count; i++)
            {
                if (!points.Contains(dbEntries[i]))
                {
                    context.MainBoardPoints.Remove(dbEntries[i]);
                }
            }
            for (int i = 0; i < points.Count; i++)
            {
                if (!dbEntries.Contains(points[i]))
                {
                    points[i].ID = 0;
                    context.MainBoardPoints.Add(points[i]);
                }
            }

            context.SaveChanges();
        }
        // 포인트 삭제
        public void DeletePoint(int MainBoard_DetailID)
        {
            IEnumerable<MainBoard_Point> dbEntries = context.MainBoardPoints.Where(p => p.MainBoard_DetailID == MainBoard_DetailID);
            foreach(MainBoard_Point dbEntry in dbEntries)
            {
                if (dbEntry != null)
                {
                    context.MainBoardPoints.Remove(dbEntry);
                }
            }
            context.SaveChanges();
        }

        // 스터디
        public IEnumerable<MainBoard_KoreanStudy> MainBoardStudies
        {
            get { return context.MainBoardStudies; }
        }
        // 스터디 수정
        public void ChangeStudies(List<MainBoard_KoreanStudy> studies, int MainBoard_DetailID)
        {
            List<MainBoard_KoreanStudy> dbEntries = context.MainBoardStudies.Where(p => p.MainBoard_DetailID == MainBoard_DetailID).ToList();
            for (int i = 0; i < dbEntries.Count; i++)
            {
                if (!studies.Contains(dbEntries[i]))
                {
                    context.MainBoardStudies.Remove(dbEntries[i]);
                }
            }
            for (int i = 0; i < studies.Count; i++)
            {
                if (!dbEntries.Contains(studies[i]))
                {
                    studies[i].ID = 0;
                    context.MainBoardStudies.Add(studies[i]);
                }
            }

            context.SaveChanges();
        }
        // 스터디 삭제
        public void DeleteStudy(int MainBoard_DetailID)
        {
            IEnumerable<MainBoard_KoreanStudy> dbEntries = context.MainBoardStudies.Where(p => p.MainBoard_DetailID == MainBoard_DetailID);
            foreach (MainBoard_KoreanStudy dbEntry in dbEntries)
            {
                if (dbEntry != null)
                {
                    context.MainBoardStudies.Remove(dbEntry);
                }
            }
            context.SaveChanges();
        }

        // 스틸컷
        public IEnumerable<MainBoard_StillCut> MainBoardStillCuts
        {
            get { return context.MainBoardStillCuts; }
        }
        // 스틸컷 수정
        public void ChangeStillCuts(List<MainBoard_StillCut> stillCuts, int MainBoard_DetailID)
        {
            List<MainBoard_StillCut> dbEntries = context.MainBoardStillCuts.Where(p => p.MainBoard_DetailID == MainBoard_DetailID).ToList();
            for (int i = 0; i < dbEntries.Count; i++)
            {
                if (!stillCuts.Contains(dbEntries[i]))
                {
                    context.MainBoardStillCuts.Remove(dbEntries[i]);
                }
            }
            for (int i = 0; i < stillCuts.Count; i++)
            {
                if (!dbEntries.Contains(stillCuts[i]))
                {
                    stillCuts[i].ID = 0;
                    context.MainBoardStillCuts.Add(stillCuts[i]);
                }
            }

            context.SaveChanges();
        }
        // 스틸컷 삭제
        public void DeleteStillCut(int MainBoard_DetailID)
        {
            IEnumerable<MainBoard_StillCut> dbEntries = context.MainBoardStillCuts.Where(p => p.MainBoard_DetailID == MainBoard_DetailID);
            foreach (MainBoard_StillCut dbEntry in dbEntries)
            {
                if (dbEntry != null)
                {
                    context.MainBoardStillCuts.Remove(dbEntry);
                }
            }
            context.SaveChanges();
        }
    }
}
