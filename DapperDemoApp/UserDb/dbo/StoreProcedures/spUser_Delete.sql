CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id INT 
AS
BEGIN
	DELETE FROM dbo.Users
	Where Id = @Id
END
