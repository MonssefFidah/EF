using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibaryManagment.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
        {
            this.Database.Connection.ConnectionString = Properties.Settings.Default.LibaryConnectionStrig;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Error> Errors { get; set; }


    }
}