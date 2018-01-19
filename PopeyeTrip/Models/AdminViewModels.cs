using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PopEyeTrip.Entities;

namespace PopEyeTrip.Models
{
    public class MainBoardListViewModel
    {
        public IEnumerable<MainBoard_List> MainBoardLists { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
