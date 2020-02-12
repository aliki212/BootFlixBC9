namespace BootFlixBC9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdateToViewer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viewers", "Birtdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Viewers", "Birtdate");
        }
    }
}
