namespace PALogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        Bytes = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Workers", "Allfiles", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workers", "Allfiles");
            DropTable("dbo.Files");
        }
    }
}
