USE LojaDb
GO

CREATE TABLE dbo.Usuario
	(
	Id                 BIGINT IDENTITY NOT NULL,
	Nome               VARCHAR (250) NOT NULL,
	DataNascimento     DATETIME NOT NULL,
	Email              VARCHAR (250) NOT NULL,
	Ativo              BIT NOT NULL,
	Senha              VARCHAR (250) NOT NULL,
	SolicitarNovaSenha BIT NOT NULL,
	DataUltimoAcesso   DATETIME NULL,
	DataCadastro       DATETIME NOT NULL,
	CONSTRAINT [PK_dbo.Usuario] PRIMARY KEY (Id)
	)
GO

CREATE TABLE dbo.Categoria
	(
	Id           BIGINT IDENTITY NOT NULL,
	Nome         VARCHAR (250) NULL,
	Descricao    VARCHAR (250) NULL,
	Ativo        BIT NOT NULL,
	DataCadastro DATETIME NOT NULL,
	UsuarioId    BIGINT NULL,
	CONSTRAINT [PK_dbo.Categoria] PRIMARY KEY (Id),
	)
GO




CREATE NONCLUSTERED INDEX IX_UsuarioId
	ON dbo.Categoria (UsuarioId)
GO

CREATE TABLE dbo.Fabricante
	(
	Id           BIGINT IDENTITY NOT NULL,
	Nome         VARCHAR (250) NULL,
	Ativo        BIT NOT NULL,
	DataCadastro DATETIME NOT NULL,
	UsuarioId    BIGINT NULL,
	CONSTRAINT [PK_dbo.Fabricante] PRIMARY KEY (Id),
	)
GO

CREATE NONCLUSTERED INDEX IX_UsuarioId
	ON dbo.Fabricante (UsuarioId)
GO

CREATE TABLE dbo.Produto
	(
	Id           BIGINT IDENTITY NOT NULL,
	Nome         VARCHAR (250) NULL,
	Descricao    VARCHAR (250) NULL,
	Estoque      INT NOT NULL,
	PrecoCusto   DECIMAL (18, 2) NOT NULL,
	PrecoVenda   DECIMAL (18, 2) NOT NULL,
	ImagemURL    VARCHAR (250) NULL,
	Ativo        BIT NOT NULL,
	Tags         VARCHAR (250) NULL,
	DataCadastro DATETIME NOT NULL,
	UsuarioId    BIGINT NULL,
	FabricanteId BIGINT NOT NULL,
	CategoriaId  BIGINT NOT NULL,
	CONSTRAINT [PK_dbo.Produto] PRIMARY KEY (Id),
	)
GO


CREATE NONCLUSTERED INDEX IX_UsuarioId
	ON dbo.Produto (UsuarioId)
GO

CREATE NONCLUSTERED INDEX IX_CategoriaId
	ON dbo.Produto (CategoriaId)
GO

CREATE NONCLUSTERED INDEX IX_FabricanteId
	ON dbo.Produto (FabricanteId)
GO


CREATE TABLE dbo.ProdutoPromocao
	(
	PromocaoId         BIGINT NOT NULL,
	ProdutoId          BIGINT NOT NULL,
	DataInicio         DATETIME NOT NULL,
	DataFim            DATETIME NOT NULL,
	PercentualDesconto DECIMAL (18, 2) NOT NULL,
	Ativo              BIT NOT NULL,
	DataCadastro       DATETIME NOT NULL,
	UsuarioId          BIGINT NULL,
	CONSTRAINT [PK_dbo.ProdutoPromocao] PRIMARY KEY (PromocaoId,ProdutoId),
	)
GO

CREATE NONCLUSTERED INDEX IX_ProdutoId
	ON dbo.ProdutoPromocao (ProdutoId)
GO

CREATE NONCLUSTERED INDEX IX_UsuarioId
	ON dbo.ProdutoPromocao (UsuarioId)
GO



CREATE PROCEDURE [dbo].[sp_AdicionarProduto]  
	    @nome VARCHAR(250), 
	    @descricao VARCHAR(250), 
	    @estoque INT, 
	    @precocusto DECIMAL(18,2), 
	    @precovenda DECIMAL(18,2), 
	    @imagemurl VARCHAR(250), 
	    @ativo BIT, 
	    @tags VARCHAR(250), 
	    @datacadastro DATETIME, 
	    @usuarioid BIGINT, 
	    @fabricanteid BIGINT, 
	    @categoriaid BIGINT
    AS
    BEGIN
	    SET NOCOUNT ON;
	
		INSERT INTO dbo.Produto (Nome, Descricao, Estoque, PrecoCusto, PrecoVenda, ImagemURL, Ativo, Tags, DataCadastro, UsuarioId, FabricanteId, CategoriaId)
		VALUES (@nome, @descricao, @estoque, @precocusto, @precovenda, @imagemurl, @ativo, @tags, @datacadastro, @usuarioid, @fabricanteid, @categoriaid)
	
	    SELECT Id, Nome, Descricao, Estoque, PrecoCusto, PrecoVenda, ImagemURL, Ativo, Tags, DataCadastro, UsuarioId, FabricanteId, CategoriaId
	    FROM dbo.Produto
	    WHERE Id = SCOPE_IDENTITY()
    END
GO

INSERT INTO Categoria (Nome, Descricao, Ativo, DataCadastro, UsuarioId) VALUES ('Eletronico', 'Produtos Eletronicos', 1, '2018-11-09 23:25:45.607', 1)
GO

INSERT INTO Fabricante (Nome, Ativo, DataCadastro, UsuarioId) VALUES ('Apple', 1, '2018-11-09 23:25:14.03', 1)
GO
