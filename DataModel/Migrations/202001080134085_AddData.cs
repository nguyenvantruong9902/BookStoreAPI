namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public partial class AddData : DbMigration
    {
        public override void Up()
        {
            using (var ctx = new BookStoreContext())
            {
                ctx.Authors.AddRange(DataFactory.ListAuthor());
                ctx.SaveChanges();
            }
            using (var ctx = new BookStoreContext())
            {
                ctx.Categories.AddRange(DataFactory.ListCategory());
                ctx.Books.AddRange(DataFactory.ListBook(ctx.Authors.ToList()));
                ctx.SaveChanges();
            }
        }
        
        public override void Down()
        {
        }
    }
}
