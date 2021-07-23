CREATE PROCEDURE [dbo].[GetUserById]
	@Id int
AS
BEGIN
	SELECT U.Id AS UserId, U.Login, U.Password, U.FirstName, U.LastName, U.Role FROM Users AS U
	WHERE U.Id = @Id
END