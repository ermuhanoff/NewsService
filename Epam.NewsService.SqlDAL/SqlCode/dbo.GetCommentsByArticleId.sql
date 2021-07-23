CREATE PROCEDURE [dbo].[GetCommentsByArticleId]
	@ArticleId int
AS
BEGIN
	SELECT C.Id AS CommentId, C.ArticleId, C.Content, C.CreationTime AS CommentCreationTime, C.EditedTime AS CommentEditedTime, C.Likes AS CommentLikes, U.Id AS UserId, U.FirstName, U.LastName, U.Role, U.Login, U.Password
	FROM Comments AS C
	INNER JOIN Users AS U
	ON C.UserId = U.Id
	WHERE C.ArticleId = @ArticleId
END