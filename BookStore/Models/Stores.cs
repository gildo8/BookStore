using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Stores
    {
        public int storeId { get; set; }

        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string name { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required]
        public string address { get; set; }

        [Required]
        public int phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string email { get; set; }

        [StringLength(20, MinimumLength = 11)]
        [Required]
        public string openingTime { get; set; }
    }
}