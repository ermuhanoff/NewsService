CREATE PROCEDURE [dbo].[AddComment]
	@CreationTime nvarchar(50), 
	@EditedTime nvarchar(50), 
	@Content nvarchar(MAX), 
	@UserId int,
	@ArticleId int, 
	@Likes int
AS
BEGIN
	INSERT INTO Comments(CreationTime, EditedTime, Content,  UserId, ArticleId, Likes)
	VALUES(CONVERT(nvarchar, @CreationTime, 103), CONVERT(nvarchar, @EditedTime, 103), @Content, @UserId, @ArticleId, @Likes)
END 