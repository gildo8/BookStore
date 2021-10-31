using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BookStore.Models;
namespace BookStore.ViewModels
{
    public class ListViewModels
    {
        public string genre { get; set; }
        public int countBook { get; set; }
    }
}