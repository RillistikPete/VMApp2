namespace VMApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHasBeenWatchedToMovieClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "HasBeenWatched", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "HasBeenWatched");
        }
    }
}
