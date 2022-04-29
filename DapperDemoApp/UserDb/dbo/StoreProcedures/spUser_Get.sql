CREATE PROCEDURE [dbo].[spUser_Get]
	@Id INT
AS
BEGIN
	SELECT u.Id, u.FirstName, u.LastName FROM dbo.Users u
	WHERE u.Id = @Id
END
