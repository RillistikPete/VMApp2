namespace VMApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ('Anchorman', 2, '2004-07-09', '2018-01-12', 7)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ('The Conjuring', 3, '2013-07-19', '2018-01-12', 4)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ('Transformers', 1, '2007-07-03', '2018-01-12', 3)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ('Holmes & Watson', 2, '2018-12-21', '2018-01-12', 8)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, DateAdded, NumberInStock) VALUES ('Avengers: Infinity War', 1, '2018-04-27', '2018-01-12', 9)");
        }
        
        public override void Down()
        {
        }
    }
}
