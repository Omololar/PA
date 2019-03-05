namespace PALogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madeDatesnullableinWorker : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Workers", "MarriageAnniversary", c => c.DateTime());
            AlterColumn("dbo.Workers", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.Workers", "SOMYear", c => c.DateTime());
            AlterColumn("dbo.Workers", "SODYear", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workers", "SODYear", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Workers", "SOMYear", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Workers", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Workers", "MarriageAnniversary", c => c.DateTime(nullable: false));
        }
    }
}
