namespace PALogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromEmail = c.String(),
                        Body = c.String(),
                        FullName = c.String(),
                        PhoneNumber = c.String(),
                        To = c.String(),
                        Subject = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Location = c.String(),
                        ImageUrl = c.String(),
                        DepartmentLeaderName = c.String(),
                        LeaderImageUrl = c.String(),
                        LeaderImageThumbnailUrl = c.String(),
                        ImageThumbnailUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkerName = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        ImageUrl = c.String(),
                        ImageThumbnailUrl = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        BaptismDate = c.String(),
                        JoinDate = c.String(),
                        HolyGhostBaptism = c.String(),
                        WaterBaptism = c.String(),
                        Experience = c.String(),
                        IsMarried = c.String(),
                        FileUrl = c.String(),
                        FilethunmbnailUrl = c.String(),
                        IsExperienced = c.String(),
                        SpouseName = c.String(),
                        NumberOfChildren = c.String(),
                        MarriageAnniversary = c.DateTime(nullable: false),
                        Profession = c.String(),
                        ChurchBaptised = c.String(),
                        BornAgain = c.String(),
                        YearBornAgain = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        SOM = c.String(),
                        SOD = c.String(),
                        BC = c.String(),
                        SOMYear = c.DateTime(nullable: false),
                        SODYear = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                        EventDate = c.DateTime(nullable: false),
                        EventTheme = c.String(),
                        EventLocation = c.String(),
                        EventImageThumbnailUrl = c.String(),
                        EventImageUrl = c.String(),
                        EventDescription = c.String(),
                        Eventtype_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventTypes", t => t.Eventtype_Id)
                .Index(t => t.Eventtype_Id);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        PictureThumbnailUrl = c.String(),
                        PictureUrl = c.String(),
                        PictureDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        MemberImageUrl = c.String(),
                        MemeberImageThumbnailUrl = c.String(),
                        Profession = c.String(),
                        Married = c.String(),
                        SpouseName = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        WeddingAnniversary = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DueDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        PictureThumbnailUrl = c.String(),
                        PictureUrl = c.String(),
                        Description = c.String(),
                        Venue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Sermons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PreacherName = c.String(),
                        Title = c.String(),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        Bibletext = c.String(),
                        SermonDate = c.DateTime(nullable: false),
                        ImageUrl = c.String(),
                        ImageThumbnailUrl = c.String(),
                        VideoLink = c.String(),
                        IsLiked = c.Boolean(nullable: false),
                        SermonCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SermonCategories", t => t.SermonCategory_Id)
                .Index(t => t.SermonCategory_Id);
            
            CreateTable(
                "dbo.SermonCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SermonName = c.String(),
                        SermonDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sermons", "SermonCategory_Id", "dbo.SermonCategories");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Events", "Eventtype_Id", "dbo.EventTypes");
            DropForeignKey("dbo.Workers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Sermons", new[] { "SermonCategory_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Events", new[] { "Eventtype_Id" });
            DropIndex("dbo.Workers", new[] { "DepartmentId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SermonCategories");
            DropTable("dbo.Sermons");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.News");
            DropTable("dbo.Members");
            DropTable("dbo.Galleries");
            DropTable("dbo.EventTypes");
            DropTable("dbo.Events");
            DropTable("dbo.Workers");
            DropTable("dbo.Departments");
            DropTable("dbo.Contacts");
        }
    }
}
