using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //added

namespace RestaurantReviewPP.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string RestaurantLink { get; set; }

    }
}