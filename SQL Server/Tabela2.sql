USE [CadastroCliente]
GO

/****** Object:  Table [dbo].[ClienteLogradouro]    Script Date: 03/09/2024 16:34:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ClienteLogradouro](
	[ClienteId] [int] NULL,
	[ClienteLogradouro] [varchar](200) NULL,
	[ClienteLogradouroDataCadastro] [datetime] NULL,
	[ClienteLogradouroDataAlteracao] [datetime] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ClienteLogradouro]  WITH CHECK ADD  CONSTRAINT [FK_ClienteIdLogradouro] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO

ALTER TABLE [dbo].[ClienteLogradouro] CHECK CONSTRAINT [FK_ClienteIdLogradouro]
GO


