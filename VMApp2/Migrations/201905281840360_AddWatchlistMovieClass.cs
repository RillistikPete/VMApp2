namespace VMApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWatchlistMovieClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WatchlistMovies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateStarted = c.DateTime(nullable: false),
                        DateCompleted = c.DateTime(),
                        Customer_Id = c.Int(),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WatchlistMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.WatchlistMovies", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.WatchlistMovies", new[] { "Movie_Id" });
            DropIndex("dbo.WatchlistMovies", new[] { "Customer_Id" });
            DropTable("dbo.WatchlistMovies");
        }
    }
}
