using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class List
    {
        public int listID { get; set; }

        [StringLength(30,MinimumLength = 5)]
        [Required]
        public string title { get; set; }

        [StringLength(1000, MinimumLength = 5)]
        [Required]
        public string content { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string author { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string publisher { get; set; }

        [Required]
        public string genre { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public double price { get; set; }

        [Range(1900,2015)]
        [Required]
        public int year { get; set; }

        [DataType(DataType.ImageUrl)]
        [Required]
        public string picture { get; set; }

        public double rating { get; set; }

        public virtual ICollection<Comments> comments { get; set; }
    }
}