namespace VMApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateStartedToDateAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WatchlistMovies", "DateAdded", c => c.DateTime(nullable: false));
            DropColumn("dbo.WatchlistMovies", "DateStarted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WatchlistMovies", "DateStarted", c => c.DateTime(nullable: false));
            DropColumn("dbo.WatchlistMovies", "DateAdded");
        }
    }
}
