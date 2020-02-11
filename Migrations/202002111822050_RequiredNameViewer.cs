namespace BootFlixBC9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredNameViewer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Viewers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Viewers", "Name", c => c.String());
        }
    }
}
