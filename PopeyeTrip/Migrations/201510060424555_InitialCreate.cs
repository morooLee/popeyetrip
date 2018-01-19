namespace PopEyeTrip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        LinkUrl = c.String(),
                        RegisterDate = c.DateTime(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Writer = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HashTags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MainBoard_Detail",
                c => new
                    {
                        MainBoard_DetailID = c.Int(nullable: false, identity: true),
                        MainImgagePath = c.String(),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                        PopEyeLike = c.Int(nullable: false),
                        Hits = c.Int(nullable: false),
                        YoutubeUrl = c.String(),
                        Category = c.String(),
                        isFollow = c.Boolean(nullable: false),
                        isMission = c.Boolean(nullable: false),
                        PlaceTitle = c.String(),
                        PlaceAdress = c.String(),
                        BusinessOpen = c.String(),
                        BusinessClose = c.String(),
                        WeekendOpen = c.String(),
                        WeekendClose = c.String(),
                        BreakTimeStart = c.String(),
                        BreakTimeEnd = c.String(),
                        Holiday = c.String(),
                        PopEyeTripBody = c.String(),
                        Direction = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        RegisterDate = c.DateTime(),
                        EditDate = c.DateTime(),
                        Writer = c.String(),
                    })
                .PrimaryKey(t => t.MainBoard_DetailID);
            
            CreateTable(
                "dbo.MainBoard_List",
                c => new
                    {
                        MainBoard_DetailID = c.Int(nullable: false, identity: true),
                        MainImgagePath = c.String(),
                        MainTitle = c.String(),
                        SubTitle = c.String(),
                        PopEyeLike = c.Int(nullable: false),
                        Hits = c.Int(nullable: false),
                        Category = c.String(),
                        isFollow = c.Boolean(nullable: false),
                        isMission = c.Boolean(nullable: false),
                        RegisterDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.MainBoard_DetailID);
            
            CreateTable(
                "dbo.MainBoard_Point",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MainBoard_DetailID = c.Int(nullable: false),
                        Point = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MainBoard_StillCut",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MainBoard_DetailID = c.Int(nullable: false),
                        StillCutPath = c.String(),
                        StillCutDescription = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MainBoard_KoreanStudy",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MainBoard_DetailID = c.Int(nullable: false),
                        Korean = c.String(),
                        Pronunciation = c.String(),
                        English = c.String(),
                        Chinese = c.String(),
                        Japanese = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MainBoard_KoreanStudy");
            DropTable("dbo.MainBoard_StillCut");
            DropTable("dbo.MainBoard_Point");
            DropTable("dbo.MainBoard_List");
            DropTable("dbo.MainBoard_Detail");
            DropTable("dbo.HashTags");
            DropTable("dbo.Banners");
        }
    }
}
