CREATE PROCEDURE [dbo].[spUser_Update]
	@Id INT,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50)
AS
BEGIN
	UPDATE dbo.Users
	SET FirstName = @FirstName, LastName = @LastName
	WHERE Id = @Id
END
