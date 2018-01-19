using PopEyeTrip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopEyeTrip.Abstract
{
    public interface IMainBoardRepository
    {
        IEnumerable<MainBoard_List> MainBoardLists { get; }
        void SaveList(MainBoard_List list);
        MainBoard_List DeleteList(int listID);

        IEnumerable<MainBoard_Detail> MainBoardDetails { get; }
        void SaveDetail(MainBoard_Detail detail);
        MainBoard_Detail DeleteDetail(int detailID);
        void HitsAdd(int MainBoard_DetailID);

        IEnumerable<MainBoard_Point> MainBoardPoints { get; }
        void ChangePoints(List<MainBoard_Point> points, int MainBoard_DetailID);
        void DeletePoint(int MainBoard_DetailID);

        IEnumerable<MainBoard_KoreanStudy> MainBoardStudies { get; }
        void ChangeStudies(List<MainBoard_KoreanStudy> studies, int MainBoard_DetailID);
        void DeleteStudy(int studyID);

        IEnumerable<MainBoard_StillCut> MainBoardStillCuts { get; }
        void ChangeStillCuts(List<MainBoard_StillCut> stillCuts, int MainBoard_DetailID);
        void DeleteStillCut(int stillCutID);
    }
}
