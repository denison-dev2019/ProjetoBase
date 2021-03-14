

/* rodar este insert após a criação dos ojetos seja pelo migration ou manulamente pelo script abaixo*/
	insert into clientes values('CLIENTE PADRAO','30190000')

-- Create database LOJATESTE

select * from clientes
if ((select count(1) from sysobjects where upper(name) = '[Clientes]') = 0 ) 
begin
  CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[cep] [nvarchar](max) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
end

GO

if ((select count(1) from sysobjects where upper(name) = 'Produtos') = 0 ) 
begin
	CREATE TABLE [dbo].[Produtos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Preco] [decimal](18, 2) NOT NULL,
	[PromocaoId] [int] NOT NULL,
 CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	
end
GO


if ((select count(1) from sysobjects where upper(name) = 'Pedidos') = 0 ) 
begin
  CREATE TABLE [dbo].[Pedidos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[Status] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
end
GO

if ((select count(1) from sysobjects where upper(name) = 'PedidosItens') = 0 ) 
begin
  
	CREATE TABLE [dbo].[PedidosItens](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[PedidoId] [int] NOT NULL,
		[ProdutoId] [int] NOT NULL,
		[QuantidadeProduto] [int] NOT NULL,
		[ValorUnitarioProduto] [decimal](18, 2) NOT NULL,
		[ValorDesconto] [decimal](18, 2) NOT NULL,
	 CONSTRAINT [PK_PedidosItens] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[PedidosItens] ADD  DEFAULT ((0.0)) FOR [ValorDesconto]

	ALTER TABLE [dbo].[PedidosItens]  WITH CHECK ADD  CONSTRAINT [FK_PedidosItens_Pedidos_PedidoId] FOREIGN KEY([PedidoId])
	REFERENCES [dbo].[Pedidos] ([Id])
	ON DELETE CASCADE

	ALTER TABLE [dbo].[PedidosItens] CHECK CONSTRAINT [FK_PedidosItens_Pedidos_PedidoId]

	ALTER TABLE [dbo].[PedidosItens]  WITH CHECK ADD  CONSTRAINT [FK_PedidosItens_Produtos_ProdutoId] FOREIGN KEY([ProdutoId])
	REFERENCES [dbo].[Produtos] ([Id])
	ON DELETE CASCADE

	ALTER TABLE [dbo].[PedidosItens] CHECK CONSTRAINT [FK_PedidosItens_Produtos_ProdutoId]
	
end
GO



if ((select count(1) from sysobjects where upper(name) = 'Promocoes') = 0 ) 
begin
	CREATE TABLE [dbo].[Promocoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](100) NULL,
	[Acumulativa] [bit] NOT NULL,
	[Formula] [nvarchar](50) NULL,
 CONSTRAINT [PK_Promocoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Promocoes] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Acumulativa]
	
end
go




