namespace BootFlixBC9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Price = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Viewers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Viewers", "MembershipTypeId");
            AddForeignKey("dbo.Viewers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Viewers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Viewers", new[] { "MembershipTypeId" });
            DropColumn("dbo.Viewers", "MembershipTypeId");
            DropTable("dbo.MembershipTypes");
        }
    }
}
