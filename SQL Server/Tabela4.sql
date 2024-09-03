USE [CadastroCliente]
GO

/****** Object:  Table [dbo].[CadastroRegistroLogin]    Script Date: 03/09/2024 16:33:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CadastroRegistroLogin](
	[ClienteId] [int] NULL,
	[CadastroRegistroLoginDataLogin] [datetime] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CadastroRegistroLogin]  WITH CHECK ADD  CONSTRAINT [FK_ClienteIdRegistroLogin] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO

ALTER TABLE [dbo].[CadastroRegistroLogin] CHECK CONSTRAINT [FK_ClienteIdRegistroLogin]
GO


