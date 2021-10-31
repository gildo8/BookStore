using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Comments
    {
        public int commentsID { get; set; }
        public int listID { get; set; }

        [StringLength(30, MinimumLength = 5)]
        [Required]
        public string commentTitle { get; set; }

        [StringLength(30, MinimumLength = 5)]
        [Required]
        public string writer { get; set; }

        [StringLength(1000, MinimumLength = 5)]
        [Required]
        public string content { get; set; }

        [Range(1,5)]
        [Required]
        public int rating { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string email { get; set; }


        public int phone { get; set; }

        public virtual List bookList { get; set; }
    }
}