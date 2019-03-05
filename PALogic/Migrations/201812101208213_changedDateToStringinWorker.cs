namespace PALogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDateToStringinWorker : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Workers", "SOMYear", c => c.String());
            AlterColumn("dbo.Workers", "SODYear", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workers", "SODYear", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Workers", "SOMYear", c => c.DateTime(nullable: false));
        }
    }
}
