namespace Loja.Data.Migrations
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
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(maxLength: 250, unicode: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        UsuarioId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(maxLength: 250, unicode: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        Estoque = c.Int(nullable: false),
                        PrecoCusto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecoVenda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImagemURL = c.String(maxLength: 250, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        Tags = c.String(maxLength: 250, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        UsuarioId = c.Long(),
                        FabricanteId = c.Long(nullable: false),
                        CategoriaId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId)
                .ForeignKey("dbo.Fabricante", t => t.FabricanteId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.FabricanteId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Fabricante",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(maxLength: 250, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        UsuarioId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 250, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 250, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        Senha = c.String(nullable: false, maxLength: 250, unicode: false),
                        SolicitarNovaSenha = c.Boolean(nullable: false),
                        DataUltimoAcesso = c.DateTime(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categoria", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Produto", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Fabricante", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Produto", "FabricanteId", "dbo.Fabricante");
            DropForeignKey("dbo.Produto", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Fabricante", new[] { "UsuarioId" });
            DropIndex("dbo.Produto", new[] { "CategoriaId" });
            DropIndex("dbo.Produto", new[] { "FabricanteId" });
            DropIndex("dbo.Produto", new[] { "UsuarioId" });
            DropIndex("dbo.Categoria", new[] { "UsuarioId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Fabricante");
            DropTable("dbo.Produto");
            DropTable("dbo.Categoria");
        }
    }
}
