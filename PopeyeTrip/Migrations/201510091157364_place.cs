namespace PopEyeTrip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class place : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MainBoard_Detail", "PlaceBody", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MainBoard_Detail", "PlaceBody");
        }
    }
}
