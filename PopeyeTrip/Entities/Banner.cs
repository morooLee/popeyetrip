using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PopEyeTrip.Entities
{
    public class Banner
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        public string ImagePath { get; set; }
        public string LinkUrl { get; set; }
        public DateTime? RegisterDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Writer { get; set; }
    }
}