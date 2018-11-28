namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSaves : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayerSaves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Save = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        SaveName = c.String(),
                        Player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.Player_Id)
                .Index(t => t.Player_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerSaves", "Player_Id", "dbo.Players");
            DropIndex("dbo.PlayerSaves", new[] { "Player_Id" });
            DropTable("dbo.PlayerSaves");
        }
    }
}
