CREATE PROCEDURE [dbo].[Authentication]
	@Email nvarchar(255),
	@Password nvarchar(255)
AS
BEGIN
	SELECT U.Id AS UserId, U.Login, U.Password, U.FirstName, U.LastName, U.Role FROM Users AS U
	WHERE U.Login = @Email AND U.Password = @Password
END