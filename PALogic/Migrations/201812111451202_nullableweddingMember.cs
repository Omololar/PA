namespace PALogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableweddingMember : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "WeddingAnniversary", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "WeddingAnniversary", c => c.DateTime(nullable: false));
        }
    }
}
