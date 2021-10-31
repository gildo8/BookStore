using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BookStore.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("StoreContext") { }

        public DbSet<List> bookList { get; set; }
        public DbSet<Comments> bookComments { get; set; }
        public DbSet<Stores> bookStores { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}