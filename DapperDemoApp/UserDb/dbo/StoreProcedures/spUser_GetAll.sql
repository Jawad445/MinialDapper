CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
BEGIN
	SELECT u.Id,u.FirstName, u.LastName FROM dbo.Users u;
End
