namespace BootFlixBC9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsSubscribedToNewsViews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viewers", "IsSubscribedToNews", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Viewers", "IsSubscribedToNews");
        }
    }
}
