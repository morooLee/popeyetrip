namespace PopEyeTrip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.MainBoard_KoreanStudy", "MainBoard_DetailID");
            CreateIndex("dbo.MainBoard_Point", "MainBoard_DetailID");
            CreateIndex("dbo.MainBoard_StillCut", "MainBoard_DetailID");
            AddForeignKey("dbo.MainBoard_KoreanStudy", "MainBoard_DetailID", "dbo.MainBoard_Detail", "MainBoard_DetailID", cascadeDelete: true);
            AddForeignKey("dbo.MainBoard_Point", "MainBoard_DetailID", "dbo.MainBoard_Detail", "MainBoard_DetailID", cascadeDelete: true);
            AddForeignKey("dbo.MainBoard_StillCut", "MainBoard_DetailID", "dbo.MainBoard_Detail", "MainBoard_DetailID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MainBoard_StillCut", "MainBoard_DetailID", "dbo.MainBoard_Detail");
            DropForeignKey("dbo.MainBoard_Point", "MainBoard_DetailID", "dbo.MainBoard_Detail");
            DropForeignKey("dbo.MainBoard_KoreanStudy", "MainBoard_DetailID", "dbo.MainBoard_Detail");
            DropIndex("dbo.MainBoard_StillCut", new[] { "MainBoard_DetailID" });
            DropIndex("dbo.MainBoard_Point", new[] { "MainBoard_DetailID" });
            DropIndex("dbo.MainBoard_KoreanStudy", new[] { "MainBoard_DetailID" });
        }
    }
}
