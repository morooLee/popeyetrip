using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopEyeTrip.Entities
{
    public class HashTag
    {
        [Key]
        public int TagID { get; set; }
        public string TagName { get; set; }
    }

    public class HashTag_MainDetail
    {
        [Key]
        public int ID { get; set; }
        public string TagName { get; set; }
        public int MainBoard_DetailID { get; set; }
    }
}
