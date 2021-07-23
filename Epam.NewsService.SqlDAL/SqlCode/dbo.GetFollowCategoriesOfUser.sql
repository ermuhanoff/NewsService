CREATE PROCEDURE [dbo].[GetFollowCategoriesOfUser]
	@UserId int
AS
BEGIN
	SELECT DISTINCT UC.CategoryId, UC.UserId, C.Id AS CategoryId, C.Name AS CategoryTitle, C.Description as CategoryDesc
	FROM UsersFollowCategories AS UC
	INNER JOIN Categories as C
	ON UC.CategoryId = C.Id
	WHERE UC.UserId = @UserId
END