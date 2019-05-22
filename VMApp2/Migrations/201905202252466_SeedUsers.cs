namespace VMApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
        INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6f749a72-263c-4c62-8b49-ab520bb9d0f8', N'admin@vmapp.com', 0, N'AHggv9BaLbD2SkQY1GQaZ9yCjnZw2XKMJ0lDOx1C4z52DD4cro1qEE7VWRLylERDdg==', N'107e3f69-4c21-4330-b4e6-7aa16e8874b5', NULL, 0, 0, NULL, 1, 0, N'admin@vmapp.com')
        INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'99bdb436-fe04-44f9-94d2-6d4d992b1d70', N'guest@vmapp.com', 0, N'ALjPqvtDjZgaLe4YA39blCItIipVPFFdG9MDJCTntAQyU/MjaLGdYT3AEoOlf+fkwg==', N'c424e4c0-09e5-4b81-bf77-339b70f6c0c0', NULL, 0, 0, NULL, 1, 0, N'guest@vmapp.com')
        INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c04ebc9c-ba18-440b-a522-f4da91a3229f', N'CanManageMovies')
        INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6f749a72-263c-4c62-8b49-ab520bb9d0f8', N'c04ebc9c-ba18-440b-a522-f4da91a3229f')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
