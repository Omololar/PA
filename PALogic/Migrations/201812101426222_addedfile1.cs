namespace PALogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfile1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Files", newName: "Filesses");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Filesses", newName: "Files");
        }
    }
}
