namespace BootFlixBC9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSeriesGenreClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 225),
                        DateAdded = c.DateTime(nullable: false),
                        DateReleased = c.DateTime(nullable: false),
                        Seasons = c.Byte(nullable: false),
                        GenreId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Series", "GenreId", "dbo.Genres");
            DropIndex("dbo.Series", new[] { "GenreId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Series");
        }
    }
}
