namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRegistrationLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "RegNum", c => c.String(nullable: false, maxLength: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "RegNum", c => c.String(nullable: false));
        }
    }
}
