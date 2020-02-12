namespace BootFlixBC9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) Values (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) Values (2, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) Values (3, 'Family')");
            Sql("INSERT INTO Genres (Id, Name) Values (4, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) Values (5, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) Values (6, 'Documentary')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id IN (1, 2, 3, 4, 5, 6)");
        }
    }
}
