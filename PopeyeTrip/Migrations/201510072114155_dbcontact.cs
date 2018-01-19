namespace PopEyeTrip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbcontact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HashTag_MainDetail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                        MainBoard_DetailID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.MainBoard_DetailID);
            

        }
        
        public override void Down()
        {
            AddColumn("dbo.HashTags", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.HashTag_MainDetail", "MainBoard_DetailID", "dbo.MainBoard_Detail");
            DropIndex("dbo.HashTag_MainDetail", new[] { "MainBoard_DetailID" });
            DropPrimaryKey("dbo.HashTags");
            DropColumn("dbo.HashTags", "TagID");
            DropTable("dbo.HashTag_MainDetail");
            AddPrimaryKey("dbo.HashTags", "ID");
        }
    }
}
