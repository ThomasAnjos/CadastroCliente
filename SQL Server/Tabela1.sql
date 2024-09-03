USE [CadastroCliente]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 03/09/2024 16:34:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioNome] [varchar](100) NULL,
	[UsuarioEmail] [varchar](100) NULL,
	[UsuarioSenha] [varchar](200) NULL,
	[UsuarioDataCadastro] [datetime] NULL,
	[UsuarioDataAlteracao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


