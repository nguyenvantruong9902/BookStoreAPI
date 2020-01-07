namespace DataModel
{
    using DataModel.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookStoreContext : DbContext
    {
        public BookStoreContext()
            : base("name=BookStoreContext")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}