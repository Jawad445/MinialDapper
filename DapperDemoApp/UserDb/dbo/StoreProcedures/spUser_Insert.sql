CREATE PROCEDURE [dbo].[spUser_Insert]
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50)
AS
BEGIN
	INSERT INTO dbo.Users (FirstName, LastName)
	VALUES(@FirstName, @LastName)
END
