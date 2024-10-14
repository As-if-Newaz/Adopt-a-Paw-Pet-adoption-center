namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdoptionApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50, unicode: false),
                        ApplicationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ApprovalStatus = c.String(nullable: false, maxLength: 50, unicode: false),
                        ApprovalDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                        PetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PetId);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Type = c.String(nullable: false, maxLength: 50, unicode: false),
                        Breed = c.String(nullable: false, maxLength: 50, unicode: false),
                        Age = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 200, unicode: false),
                        Location = c.String(nullable: false, maxLength: 50, unicode: false),
                        IsAvailable = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DatePosted = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateAdopted = c.DateTime(precision: 7, storeType: "datetime2"),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        Role = c.String(nullable: false, maxLength: 50, unicode: false),
                        Phone = c.String(nullable: false, maxLength: 50, unicode: false),
                        Address = c.String(nullable: false, maxLength: 50, unicode: false),
                        Active = c.Boolean(nullable: false),
                        AuthKey = c.String(nullable: false, maxLength: 15),
                        RegDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SuccessStories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50, unicode: false),
                        Story = c.String(nullable: false, maxLength: 50, unicode: false),
                        AdoptionDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        PetId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.PetId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MedicalRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PetId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .Index(t => t.PetId);
            
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DrName = c.String(nullable: false, maxLength: 50, unicode: false),
                        CheckupDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Remarks = c.String(nullable: false, maxLength: 50, unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        MedicalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicalRecords", t => t.MedicalId, cascadeDelete: true)
                .Index(t => t.MedicalId);
            
            CreateTable(
                "dbo.Vaccinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VaccineName = c.String(nullable: false, maxLength: 50, unicode: false),
                        VaccineDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        MedicalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicalRecords", t => t.MedicalId, cascadeDelete: true)
                .Index(t => t.MedicalId);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(nullable: false, maxLength: 15),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExpiredAt = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsValid = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "UserId", "dbo.Users");
            DropForeignKey("dbo.Vaccinations", "MedicalId", "dbo.MedicalRecords");
            DropForeignKey("dbo.Prescriptions", "MedicalId", "dbo.MedicalRecords");
            DropForeignKey("dbo.MedicalRecords", "PetId", "dbo.Pets");
            DropForeignKey("dbo.AdoptionApplications", "UserId", "dbo.Users");
            DropForeignKey("dbo.AdoptionApplications", "PetId", "dbo.Pets");
            DropForeignKey("dbo.Pets", "UserId", "dbo.Users");
            DropForeignKey("dbo.SuccessStories", "UserId", "dbo.Users");
            DropForeignKey("dbo.SuccessStories", "PetId", "dbo.Pets");
            DropIndex("dbo.Tokens", new[] { "UserId" });
            DropIndex("dbo.Vaccinations", new[] { "MedicalId" });
            DropIndex("dbo.Prescriptions", new[] { "MedicalId" });
            DropIndex("dbo.MedicalRecords", new[] { "PetId" });
            DropIndex("dbo.SuccessStories", new[] { "UserId" });
            DropIndex("dbo.SuccessStories", new[] { "PetId" });
            DropIndex("dbo.Pets", new[] { "UserId" });
            DropIndex("dbo.AdoptionApplications", new[] { "PetId" });
            DropIndex("dbo.AdoptionApplications", new[] { "UserId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.Vaccinations");
            DropTable("dbo.Prescriptions");
            DropTable("dbo.MedicalRecords");
            DropTable("dbo.SuccessStories");
            DropTable("dbo.Users");
            DropTable("dbo.Pets");
            DropTable("dbo.AdoptionApplications");
        }
    }
}
