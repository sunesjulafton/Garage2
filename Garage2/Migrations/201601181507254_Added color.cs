namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedcolor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Color", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Color");
        }
    }
}
