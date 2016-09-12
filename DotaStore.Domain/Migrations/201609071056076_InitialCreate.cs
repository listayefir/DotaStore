namespace DotaStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        ProductionDate = c.DateTime(),
                        Picture = c.Binary(storeType: "image"),
                        Description = c.String(maxLength: 200),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Cathegory = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Item");
        }
    }
}
