namespace BootFlixBC9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBoolIsReleased : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Series", "IsReleased", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Series", "IsReleased");
        }
    }
}
