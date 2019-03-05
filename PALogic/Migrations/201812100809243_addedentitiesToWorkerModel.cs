namespace PALogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedentitiesToWorkerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "SODUrl", c => c.String());
            AddColumn("dbo.Workers", "SODCert", c => c.String());
            AddColumn("dbo.Workers", "BCCert", c => c.String());
            AddColumn("dbo.Workers", "BCUrl", c => c.String());
            AddColumn("dbo.Workers", "BaptismCert", c => c.String());
            AddColumn("dbo.Workers", "BaptismUrl", c => c.String());
            DropColumn("dbo.Workers", "FileUrl");
            DropColumn("dbo.Workers", "FilethunmbnailUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workers", "FilethunmbnailUrl", c => c.String());
            AddColumn("dbo.Workers", "FileUrl", c => c.String());
            DropColumn("dbo.Workers", "BaptismUrl");
            DropColumn("dbo.Workers", "BaptismCert");
            DropColumn("dbo.Workers", "BCUrl");
            DropColumn("dbo.Workers", "BCCert");
            DropColumn("dbo.Workers", "SODCert");
            DropColumn("dbo.Workers", "SODUrl");
        }
    }
}
