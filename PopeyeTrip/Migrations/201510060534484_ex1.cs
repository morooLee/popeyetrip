namespace PopEyeTrip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ex1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MainBoard_Point", "MainBoard_DetailID", "dbo.MainBoard_Detail");
            DropIndex("dbo.MainBoard_Point", new[] { "MainBoard_DetailID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.MainBoard_Point", "MainBoard_DetailID");
            AddForeignKey("dbo.MainBoard_Point", "MainBoard_DetailID", "dbo.MainBoard_Detail", "MainBoard_DetailID", cascadeDelete: true);
        }
    }
}
