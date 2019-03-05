namespace PALogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableWedAniversary : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Workers", "MarriageAnniversary", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workers", "MarriageAnniversary", c => c.DateTime(nullable: false));
        }
    }
}
