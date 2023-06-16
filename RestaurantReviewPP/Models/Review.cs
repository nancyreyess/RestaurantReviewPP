using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //added for key
using System.ComponentModel.DataAnnotations.Schema; //added for foreign key

namespace RestaurantReviewPP.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        //A restaurant can have multiple reviews, but a review can only belong to one restaurant
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public int UserId { get; set; }
        public DateTime ReviewDate { get; set; }
        public int ReviewRating { get; set; }
        public string ReviewComment { get; set; }

        
    }
}