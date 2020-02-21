namespace BootFlixBC9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'25ef4a6f-1f5e-4cbf-8505-870ed3ff9e95', N'SeriesManager')
                INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'572a121e-782b-4a2c-8e5f-0fe112a7f6e3', N'a@a.com', 0, N'ADIdnUpcB90TrOz/KqpVCKY64SIcagN3/AZUEkwelRGj9n1x5tIT4sp3tscfo0r3Yw==', N'59e5ef57-4ba7-4f1e-8a89-5f18f027cdbd', NULL, 0, 0, NULL, 1, 0, N'a@a.com')
                INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f64b53bd-3ebc-4382-b436-40d7fa74089c', N'seriesadmin@gmail.com', 0, N'AAErM5P7gx68smbMxhqxgfQdOr7dyvCSUrxmUE8as5BNx4ax2YU1wILLm41uZ3im6Q==', N'71b7ceec-8f61-4c90-8965-7c9d627af5e0', NULL, 0, 0, NULL, 1, 0, N'seriesadmin@gmail.com')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
