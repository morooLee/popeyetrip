using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopEyeTrip.Entities
{
    public class PopEyeLike
    {
        [Key]
        public int ID { get; set; }
        public string UserID { get; set; }
        public int MainBoard_DetailID { get; set; }
    }
}
