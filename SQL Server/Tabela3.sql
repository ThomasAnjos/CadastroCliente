USE [CadastroCliente]
GO

/****** Object:  Table [dbo].[Cliente]    Script Date: 03/09/2024 16:34:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteNome] [varchar](100) NULL,
	[ClienteEmail] [varchar](100) NULL,
	[ClienteLogotipo] [varbinary](max) NULL,
	[ClienteDataCadastro] [datetime] NULL,
	[ClienteDataAlteracao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


