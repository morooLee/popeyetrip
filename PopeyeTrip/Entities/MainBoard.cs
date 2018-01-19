using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PopEyeTrip.Entities
{
    public class MainBoard_List
    {
        [Key]
        public int MainBoard_DetailID { get; set; }
        public string MainImgagePath {get;set;}
        public string MainTitle { get; set; }
        public string SubTitle { get; set; }
        public int PopEyeLike { get; set; }
        public int Hits { get; set; }
        public string Category { get; set; }
        public bool isFollow { get; set; }
        public bool isMission { get; set; }
        public DateTime? RegisterDate { get; set; }
    }

    public class MainBoard_Detail
    {
        public MainBoard_Detail()
        {
            this.PopEyePoints = new List<MainBoard_Point>();
            this.KoreanStudies = new List<MainBoard_KoreanStudy>();
            this.StillCuts = new List<MainBoard_StillCut>();
            this.HashTags = new List<HashTag_MainDetail>();
        }
        [Key]
        public int MainBoard_DetailID { get; set; }
        public string MainImgagePath { get; set; }
        public string MainTitle { get; set; }
        public string SubTitle { get; set; }
        public int PopEyeLike { get; set; }
        public int Hits { get; set; }
        public string YoutubeUrl { get; set; }
        public string Category { get; set; }
        public bool isFollow { get; set; }
        public bool isMission { get; set; }
        public List<MainBoard_Point> PopEyePoints { get; set; }
        public string PlaceTitle { get; set; }
        public string BusinessType { get; set; }
        [AllowHtml]
        public string PlaceBody { get; set; }
        public string BusinessOpen { get; set; }
        public string BusinessClose { get; set; }
        public string WeekendOpen { get; set; }
        public string WeekendClose { get; set; }
        public string BreakTimeStart { get; set; }
        public string BreakTimeEnd { get; set; }
        public string Holiday { get; set; }
        public List<MainBoard_KoreanStudy> KoreanStudies { get; set; }
        [AllowHtml]
        public string PopEyeTripBody { get; set; }
        [AllowHtml]
        public string Direction { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public List<MainBoard_StillCut> StillCuts { get; set; }
        public DateTime? RegisterDate { get; set; }
        public DateTime? EditDate { get; set; }
        public string Writer { get; set; }
        public List<HashTag_MainDetail> HashTags {get;set;}
    }

    public class MainBoard_Point
    {
        [Key]
        public int ID { get; set; }
        public int MainBoard_DetailID { get; set; }
        public string Point { get; set; }
    }

    public class MainBoard_KoreanStudy
    {
        [Key]
        public int ID { get; set; }
        public int MainBoard_DetailID { get; set; }
        public string Korean { get; set; }
        public string Pronunciation { get; set; }
        public string English { get; set; }
        public string Chinese { get; set; }
        public string Japanese { get; set; }
    }

    public class MainBoard_StillCut
    {
        [Key]
        public int ID { get; set; }
        public int MainBoard_DetailID { get; set; }
        public string StillCutPath { get; set; }
        public string StillCutDescription { get; set; }
    }
}
