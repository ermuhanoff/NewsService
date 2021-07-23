CREATE PROCEDURE [dbo].[GetUserByEmail]
	@Email nvarchar(255)
AS
BEGIN
	SELECT U.Id AS UserId, U.Login, U.Password, U.FirstName, U.LastName, U.Role FROM Users AS U
	WHERE Users.Login = @Email
END