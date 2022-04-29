IF NOT EXISTS (SELECT 1 FROM dbo.Users)
BEGIN 

	INSERT INTO dbo.Users (FirstName, LastName)
	Values ('Jawad', 'Hassan'),
		   ('Sue','Strom'),
		   ('John','Smith'),
		   ('Marry','John');
END