using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Models;
using System.Data.Entity;

namespace BookStore.DAL
{
    public class BookInit : System.Data.Entity.DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var book = new List<List>
            {
                new List{listID = 1,title="Book1", author="Avi",publisher="Publisher1",genre="Comedy",price=19.99,year=1999},
                new List{listID = 2,title="Book2", author="Avi",publisher="Publisher2",genre="Comedy",price=19.99,year=1999},
                new List{listID = 3,title="Book3", author="Avi",publisher="Publisher3",genre="Comedy",price=19.99,year=1999},
                new List{listID = 4,title="Book4", author="Avi",publisher="Publisher4",genre="Comedy",price=19.99,year=1999},
                new List{listID = 5,title="Book5", author="Avi",publisher="Publisher4",genre="Comedy",price=19.99,year=1999}
            };

            book.ForEach(s => context.bookList.Add(s));
            context.SaveChanges();

            var comment = new List<Comments>
            {
                new Comments{commentsID = 1,listID = 1 , commentTitle = "Title1" , writer = "Writer1",content="this is the content 1",rating = 3 , email = "gfs@gmail.com",phone=039325325},
                new Comments{commentsID = 2,listID = 1 , commentTitle = "Title2" , writer = "Writer2",content="this is the content 1",rating = 3 , email = "gfs@gmail.com",phone=039325325},
                new Comments{commentsID = 3,listID = 3 , commentTitle = "Title3" , writer = "Writer3",content="this is the content 1",rating = 3 , email = "gfs@gmail.com",phone=039325325},
                new Comments{commentsID = 4,listID = 2 , commentTitle = "Title4" , writer = "Writer4",content="this is the content 1",rating = 3 , email = "gfs@gmail.com",phone=039325325},
                new Comments{commentsID = 5,listID = 4 , commentTitle = "Title5" , writer = "Writer5",content="this is the content 1",rating = 3 , email = "gfs@gmail.com",phone=039325325},
            };

            comment.ForEach(s => context.bookComments.Add(s));
            context.SaveChanges();

            var stores = new List<Stores>
            {
                new Stores{storeId = 1 , name="Store1", address="Address1", email="bla@gmail.com", openingTime="10-23", phone=03943242},
                new Stores{storeId = 2 , name="Store2", address="Address2", email="bla@gmail.com", openingTime="10-23", phone=03943242},
                new Stores{storeId = 3 , name="Store3", address="Address3", email="bla@gmail.com", openingTime="10-23", phone=03943242},
                new Stores{storeId = 4 , name="Store4", address="Address4", email="bla@gmail.com", openingTime="10-23", phone=03943242},
                new Stores{storeId = 5 , name="Store5", address="Address1", email="bla@gmail.com", openingTime="10-23", phone=03943242},
            };
            stores.ForEach(x => context.bookStores.Add(x));
            context.SaveChanges();
        }
    }
}