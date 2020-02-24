namespace BootFlixBC9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActorContract : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Age = c.Int(nullable: false),
                        Nationality = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActorId = c.Int(nullable: false),
                        SerieId = c.Int(nullable: false),
                        Character = c.String(),
                        DateInserted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.Series", t => t.SerieId, cascadeDelete: true)
                .Index(t => t.ActorId)
                .Index(t => t.SerieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "SerieId", "dbo.Series");
            DropForeignKey("dbo.Contracts", "ActorId", "dbo.Actors");
            DropIndex("dbo.Contracts", new[] { "SerieId" });
            DropIndex("dbo.Contracts", new[] { "ActorId" });
            DropTable("dbo.Contracts");
            DropTable("dbo.Actors");
        }
    }
}
