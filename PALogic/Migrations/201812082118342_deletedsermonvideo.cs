namespace PALogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedsermonvideo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Sermons", "VideoLink");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sermons", "VideoLink", c => c.String());
        }
    }
}
