CREATE PROCEDURE [dbo].[InsereUsuario] 
       @UsuarioNome                      VARCHAR(100)  = NULL, 
       @UsuarioEmail                     VARCHAR(100)  = NULL, 
       @UsuarioSenha                     VARCHAR(200)  = NULL 
AS 
BEGIN 
     SET NOCOUNT ON 

     INSERT INTO dbo.Usuario
          (                    
				UsuarioNome,
				UsuarioEmail,
				UsuarioSenha,
				UsuarioDataCadastro                 
          ) 
     VALUES 
          ( 
				@UsuarioNome,
				@UsuarioEmail,
				@UsuarioSenha,
				GETDATE()
          ) 

END 
GO
CREATE PROCEDURE [dbo].[InsereLogradouro]
	 @ClienteId int,
	 @ClienteLogradouro varchar(200)
AS
BEGIN
	 SET NOCOUNT ON 

	 INSERT INTO ClienteLogradouro (ClienteLogradouro, ClienteLogradouroDataCadastro, ClienteId)
	 VALUES (@ClienteLogradouro, GETDATE(), @ClienteId)
END
GO
CREATE PROCEDURE [dbo].[InsereCliente] 
	   @ClienteNome varchar(100),
	   @ClienteEmail varchar(100),
	   @ClienteLogotipo Varbinary (max)
AS 
BEGIN 
     SET NOCOUNT ON 

	 DECLARE @ClienteEmailCount INT
	 DECLARE @ClienteId INT
	 DECLARE @ClienteInserido INT

	 SELECT @ClienteEmailCount = Count(ClienteEmail) FROM Cliente WHERE ClienteEmail = @ClienteEmail

	 --SELECT @ClienteEmailCount = Count(ClienteEmail), @ClienteId = ClienteId FROM Cliente WHERE ClienteEmail = @ClienteEmail
	 
	 IF @ClienteEmailCount = 0
		BEGIN
			INSERT INTO dbo.Cliente
			(                    
					ClienteNome,
					ClienteEmail,
					ClienteDataCadastro,
					ClienteLogotipo
			) 
			VALUES 
			( 
					@ClienteNome,
					@ClienteEmail,
					GETDATE(),
					@ClienteLogotipo
			) 
		END 

		select SCOPE_IDENTITY()
END 
GO
CREATE PROCEDURE [dbo].[BuscaUsuariosPorId] 
	@UsuarioId    INT
AS 
BEGIN 
     SET NOCOUNT ON 

	 SELECT UsuarioId,
			UsuarioNome,
			UsuarioEmail,
			UsuarioSenha 
	FROM dbo.Usuario WHERE UsuarioId = @UsuarioId
END 
GO
CREATE PROCEDURE [dbo].[BuscaTodosUsuarios] 
AS 
BEGIN 
     SET NOCOUNT ON 

	 SELECT UsuarioId,
			UsuarioNome,
			UsuarioEmail,
			UsuarioSenha 
	FROM dbo.Usuario
END 
GO
CREATE PROCEDURE [dbo].[BuscaTodosClientes] 
AS 
BEGIN 
     SET NOCOUNT ON 

	 SELECT cliente.ClienteId,
	        cliente.ClienteNome,
			cliente.ClienteEmail,
			logradouro.ClienteLogradouro,
			cliente.ClienteDataCadastro,
			cliente.ClienteLogotipo 
	FROM dbo.Cliente cliente
	INNER JOIN dbo.ClienteLogradouro logradouro
	ON cliente.ClienteId = logradouro.ClienteId
END 
GO
CREATE PROCEDURE [dbo].[BuscaClientesPorId] 
	@ClienteId    INT
AS 
BEGIN 
     SET NOCOUNT ON 

	 SELECT cliente.ClienteId,
	        cliente.ClienteNome,
			cliente.ClienteEmail,
			logradouro.ClienteLogradouro,
			cliente.ClienteDataCadastro,
			cliente.ClienteLogotipo 
	FROM dbo.Cliente cliente
	INNER JOIN dbo.ClienteLogradouro logradouro
	ON cliente.ClienteId = logradouro.ClienteId
	WHERE cliente.ClienteId = @ClienteId
END 
GO
CREATE PROCEDURE [dbo].[ApagaUsuario] 
	@UsuarioId    INT
AS 
BEGIN 
     SET NOCOUNT ON 

	 DELETE FROM dbo.Usuario WHERE UsuarioId = @UsuarioId
END 
GO
CREATE PROCEDURE [dbo].[ApagaCliente]
	@ClienteId    INT
AS 
BEGIN 
     SET NOCOUNT ON 

	 DELETE FROM dbo.ClienteLogradouro WHERE ClienteId = @ClienteId
	 DELETE FROM dbo.Cliente WHERE ClienteId = @ClienteId
END 
GO
CREATE PROCEDURE [dbo].[AlteraUsuario] 
	@UsuarioId    INT,
	@UsuarioNome  VARCHAR(100),
	@UsuarioEmail VARCHAR(100),
	@UsuarioSenha VARCHAR(200)
AS 
BEGIN 
     SET NOCOUNT ON 

	 UPDATE Usuario SET UsuarioNome = @UsuarioNome,
						UsuarioEmail = @UsuarioEmail,
						UsuarioSenha = @UsuarioSenha,
						UsuarioDataAlteracao = GETDATE()
						
					WHERE UsuarioId = @UsuarioId
END
GO
CREATE PROCEDURE [dbo].[AlteraCliente] 
     @ClienteId int,
	 @ClienteNome varchar(100),
	 @ClienteEmail varchar(100),
	 @ClienteLogradouro varchar(200),
	 @ClienteLogotipo Varbinary (max)
AS 
BEGIN 
     SET NOCOUNT ON 

	 UPDATE Cliente SET ClienteNome = @ClienteNome,
						ClienteEmail = @ClienteEmail,
						@ClienteLogotipo = @ClienteLogotipo,
						ClienteDataAlteracao = GETDATE()
					WHERE ClienteId = @ClienteId
END
GO
