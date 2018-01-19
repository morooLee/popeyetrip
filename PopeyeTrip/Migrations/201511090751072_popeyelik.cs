namespace PopEyeTrip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class popeyelik : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PopEyeLikes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        MainBoard_DetailID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PopEyeLikes");
        }
    }
}
