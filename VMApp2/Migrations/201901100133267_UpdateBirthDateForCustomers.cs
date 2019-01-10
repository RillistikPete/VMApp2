namespace VMApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirthDateForCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate = CAST('1980-09-06' as DATETIME) WHERE Id = 1");
            Sql("UPDATE Customers SET BirthDate = CAST('1993-10-11' as DATETIME) WHERE Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
