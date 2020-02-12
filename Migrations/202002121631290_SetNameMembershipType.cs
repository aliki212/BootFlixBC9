namespace BootFlixBC9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Free' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Basic' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Standard' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Premium' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
