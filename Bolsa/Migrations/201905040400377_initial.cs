namespace Bolsa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ação",
                c => new
                    {
                        codigo = c.String(nullable: false, maxLength: 128),
                        nome = c.String(nullable: false),
                        descricao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        valor = c.Single(nullable: false),
                        quantidade = c.Single(nullable: false),
                        acao_codigo = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Ação", t => t.acao_codigo, cascadeDelete: true)
                .Index(t => t.acao_codigo);
            
            CreateTable(
                "dbo.Infoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        data = c.DateTime(nullable: false),
                        acao_codigo = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Ação", t => t.acao_codigo, cascadeDelete: true)
                .Index(t => t.acao_codigo);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        valor = c.Single(nullable: false),
                        quantidade = c.Single(nullable: false),
                        acao_codigo = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Ação", t => t.acao_codigo, cascadeDelete: true)
                .Index(t => t.acao_codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendas", "acao_codigo", "dbo.Ação");
            DropForeignKey("dbo.Infoes", "acao_codigo", "dbo.Ação");
            DropForeignKey("dbo.Compras", "acao_codigo", "dbo.Ação");
            DropIndex("dbo.Vendas", new[] { "acao_codigo" });
            DropIndex("dbo.Infoes", new[] { "acao_codigo" });
            DropIndex("dbo.Compras", new[] { "acao_codigo" });
            DropTable("dbo.Vendas");
            DropTable("dbo.Infoes");
            DropTable("dbo.Compras");
            DropTable("dbo.Ação");
        }
    }
}
