namespace VMApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRegisterAndExternalLoginConfirmationViewModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: true, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Phone", c => c.String());
        }
    }
}
