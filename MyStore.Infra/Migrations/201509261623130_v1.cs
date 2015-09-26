namespace MyStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 36, fixedLength: true),
                        Email = c.String(nullable: false, maxLength: 160),
                        Verified = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        LastLoginDate = c.DateTime(nullable: false),
                        Role = c.Int(nullable: false),
                        VerificationCode = c.String(nullable: false, maxLength: 6, fixedLength: true),
                        ActivationCode = c.String(nullable: false, maxLength: 4, fixedLength: true),
                        AuthorizationCode = c.String(nullable: false, maxLength: 4, fixedLength: true),
                        LastAuthorizationCodeRequest = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
        }
    }
}
