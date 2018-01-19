namespace PopEyeTrip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class place1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MainBoard_Detail", "BusinessType", c => c.String());
            DropColumn("dbo.MainBoard_Detail", "PlaceAdress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MainBoard_Detail", "PlaceAdress", c => c.String());
            DropColumn("dbo.MainBoard_Detail", "BusinessType");
        }
    }
}
