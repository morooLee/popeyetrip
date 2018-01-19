using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PopEyeTrip.Entities;

namespace PopEyeTrip.Models
{
    public class MainBoardViewModel
    {
        public MainBoardViewModel()
        {
            this.MainBoardLists = new List<MainBoard_List>();
        }
        public MainBoard_Detail MainBoardDetail { get; set; }
        public string YoutubeUrl { get; set; }
        public List<MainBoard_List> MainBoardLists { get; set; }
        public bool Liked { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }

    public class PopEyeLikeViewModel
    {
        public int Likes { get; set; }
    }
}
