namespace VMApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomer1ToTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Customers ON");
            Sql("INSERT INTO Customers (Id, Name, IsSubscribedToNewsletter, MembershipTypeId, BirthDate) VALUES (1, 'Gary Chapman', 0, 1, null)");
            Sql("SET IDENTITY_INSERT Customers OFF");
        }
        
        public override void Down()
        {
        }
    }
}
