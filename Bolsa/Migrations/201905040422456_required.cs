namespace Bolsa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class required : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Compras", "acao_codigo", "dbo.Ação");
            DropForeignKey("dbo.Infoes", "acao_codigo", "dbo.Ação");
            DropForeignKey("dbo.Vendas", "acao_codigo", "dbo.Ação");
            DropIndex("dbo.Compras", new[] { "acao_codigo" });
            DropIndex("dbo.Infoes", new[] { "acao_codigo" });
            DropIndex("dbo.Vendas", new[] { "acao_codigo" });
            AlterColumn("dbo.Compras", "acao_codigo", c => c.String(maxLength: 128));
            AlterColumn("dbo.Infoes", "acao_codigo", c => c.String(maxLength: 128));
            AlterColumn("dbo.Vendas", "acao_codigo", c => c.String(maxLength: 128));
            CreateIndex("dbo.Compras", "acao_codigo");
            CreateIndex("dbo.Infoes", "acao_codigo");
            CreateIndex("dbo.Vendas", "acao_codigo");
            AddForeignKey("dbo.Compras", "acao_codigo", "dbo.Ação", "codigo");
            AddForeignKey("dbo.Infoes", "acao_codigo", "dbo.Ação", "codigo");
            AddForeignKey("dbo.Vendas", "acao_codigo", "dbo.Ação", "codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendas", "acao_codigo", "dbo.Ação");
            DropForeignKey("dbo.Infoes", "acao_codigo", "dbo.Ação");
            DropForeignKey("dbo.Compras", "acao_codigo", "dbo.Ação");
            DropIndex("dbo.Vendas", new[] { "acao_codigo" });
            DropIndex("dbo.Infoes", new[] { "acao_codigo" });
            DropIndex("dbo.Compras", new[] { "acao_codigo" });
            AlterColumn("dbo.Vendas", "acao_codigo", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Infoes", "acao_codigo", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Compras", "acao_codigo", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Vendas", "acao_codigo");
            CreateIndex("dbo.Infoes", "acao_codigo");
            CreateIndex("dbo.Compras", "acao_codigo");
            AddForeignKey("dbo.Vendas", "acao_codigo", "dbo.Ação", "codigo", cascadeDelete: true);
            AddForeignKey("dbo.Infoes", "acao_codigo", "dbo.Ação", "codigo", cascadeDelete: true);
            AddForeignKey("dbo.Compras", "acao_codigo", "dbo.Ação", "codigo", cascadeDelete: true);
        }
    }
}
