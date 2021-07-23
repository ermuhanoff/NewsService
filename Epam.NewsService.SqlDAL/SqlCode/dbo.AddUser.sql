CREATE PROCEDURE [dbo].[AddUser]
	@Login nvarchar(255),
	@Password nvarchar(255),
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Role int
AS
BEGIN
	INSERT INTO Users(Login, Password, FirstName, LastName, Role)
	VALUES(@Login, @Password, @FirstName, @LastName, @Role)
END
GO