namespace PruebaNetFramework.CatalogosDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Cat_ID = c.Int(nullable: false, identity: true),
                        Cat_CodCategoria = c.Int(nullable: false),
                        Cat_Cat_Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Cat_ID);
            
            CreateTable(
                "dbo.SubCategoria",
                c => new
                    {
                        SubCat_ID = c.Int(nullable: false, identity: true),
                        SubCat_Cat_ID = c.Int(nullable: false),
                        SubCat_SubCatCodigo = c.Int(nullable: false),
                        SubCat_Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.SubCat_ID)
                .ForeignKey("dbo.Categoria", t => t.SubCat_Cat_ID, cascadeDelete: true)
                .Index(t => t.SubCat_Cat_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategoria", "SubCat_Cat_ID", "dbo.Categoria");
            DropIndex("dbo.SubCategoria", new[] { "SubCat_Cat_ID" });
            DropTable("dbo.SubCategoria");
            DropTable("dbo.Categoria");
        }
    }
}
