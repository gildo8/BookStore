namespace BookStore.Migrations
{
    using BookStore.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookStore.DAL.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookStore.DAL.StoreContext context)
        {
            var book = new List<List>
            {
                new List{listID = 1,title="Book1", author="Avi",publisher="Publisher1",content="This is content of book 1",genre="Comedy",price=19.99,year=2012,picture="http://pcauthorities.com/images/reviews/amb_logo.png"},
                new List{listID = 2,title="Book2", author="Haim",publisher="Publisher2",content="This is content of book 2",genre="Kids",price=19.99,year=1999,picture="http://pcauthorities.com/images/reviews/amb_logo.png"},
                new List{listID = 3,title="Book3", author="Shalom",publisher="Publisher3",content="This is content of book 3",genre="Horror",price=19.99,year=2000,picture="http://pcauthorities.com/images/reviews/amb_logo.png"},
                new List{listID = 4,title="Book4", author="Shriki",publisher="Publisher4",content="This is content of book 4",genre="Scary",price=19.99,year=1991,picture="http://pcauthorities.com/images/reviews/amb_logo.png"},
                new List{listID = 5,title="Book5", author="Avi",publisher="Publisher4",content="This is content of book 5",genre="Comedy",price=19.99,year=1995,picture="http://pcauthorities.com/images/reviews/amb_logo.png"},
                new List{listID = 6,title="Book6", author="shimi",publisher="Publisher5",content="This is content of book 6",genre="Kids",price=19.99,year=2006,picture="http://pcauthorities.com/images/reviews/amb_logo.png"},
                new List{listID = 7,title="Book7", author="Avi",publisher="Publisher5",content="This is content of book 7",genre="Romantic",price=19.99,year=2007,picture="http://pcauthorities.com/images/reviews/amb_logo.png"},
                new List{listID = 8,title="Book8", author="roni",publisher="Publisher2",content="This is content of book 8",genre="History",price=19.99,year=2008,picture="http://pcauthorities.com/images/reviews/amb_logo.png"}

            };

            book.ForEach(s => context.bookList.AddOrUpdate(p => p.title, s));
            context.SaveChanges();

            var comment = new List<Comments>
            {
                new Comments{commentsID = 1,listID = 1 , commentTitle = "Title1" , writer = "Writer1",content="this is the comment content 1",rating = 3 , email ="gfs@gmail.com",phone=039325325},
                new Comments{commentsID = 2,listID = 1 , commentTitle = "Title2" , writer = "Writer2",content="this is the comment content 2",rating = 2 , email = "gfs@gmail.com",phone=039325325},
                new Comments{commentsID = 3,listID = 3 , commentTitle = "Title3" , writer = "Writer3",content="this is the comment content 3",rating = 4 , email = "gfs@gmail.com",phone=039325325},
                new Comments{commentsID = 4,listID = 2 , commentTitle = "Title4" , writer = "Writer4",content="this is the comment content 4",rating = 5 , email = "gfs@gmail.com",phone=039325325},
                new Comments{commentsID = 5,listID = 4 , commentTitle = "Title5" , writer = "Writer5",content="this is the comment content 5",rating = 5 , email = "gfs@gmail.com",phone=039325325},
                new Comments{commentsID = 6,listID = 2 , commentTitle = "Title6" , writer = "Writer6",content="this is the comment content 6",rating = 1 , email = "gfs@gmail.com",phone=039325325},
                new Comments{commentsID = 7,listID = 3 , commentTitle = "Title7" , writer = "Writer7",content="this is the comment content 7",rating = 3 , email = "gfs@gmail.com",phone=039325325},
                new Comments{commentsID = 8,listID = 1 , commentTitle = "Title8" , writer = "Writer8",content="this is the comment content 8",rating = 2 , email = "gfs@gmail.com",phone=039325325},

            };

            comment.ForEach(s => context.bookComments.AddOrUpdate(p => p.commentsID, s));
            context.SaveChanges();

            var stores = new List<Stores>
            {
                new Stores{storeId = 1 , name="Store1", address="Address1", email="bla@gmail.com", openingTime="10:00 - 23:00", phone=03943242},
                new Stores{storeId = 2 , name="Store2", address="Address2", email="bla@gmail.com", openingTime="09:00 - 19:00", phone=03943242},
                new Stores{storeId = 3 , name="Store3", address="Address3", email="bla@gmail.com", openingTime="10:00 - 22:00", phone=03943242},
                new Stores{storeId = 4 , name="Store4", address="Address4", email="bla@gmail.com", openingTime="10:00 - 23:00", phone=03943242},
                new Stores{storeId = 5 , name="Store5", address="Address1", email="bla@gmail.com", openingTime="08:00 - 23:00", phone=03943242},
            };
            stores.ForEach(x => context.bookStores.AddOrUpdate(p => p.storeId, x));
            context.SaveChanges();
        }
    }
}
