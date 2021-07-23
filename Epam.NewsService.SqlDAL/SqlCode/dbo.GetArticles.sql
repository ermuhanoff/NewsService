CREATE PROCEDURE [dbo].[GetArticles]
AS
BEGIN
	SELECT DISTINCT * FROM 
	(
		SELECT A1.Id AS ArticleId, A1.Title, A1.Text, A1.IntroImageLink, A1.CreationTime, A1.Likes, U.Id AS UserId, U.FirstName, U.LastName, U.Role, U.Login, U.Password
		FROM Articles AS A1 INNER JOIN Users AS U ON A1.ModeratorId = U.Id
	) AS AU
	INNER JOIN
	(
		SELECT A2.Id AS ArticleId, C.Id AS CategoryId, C.Name AS CategoryTitle, C.Description AS CategoryDesc
		FROM Articles AS A2 INNER JOIN Categories AS C ON A2.CategoryId = C.Id
	) AS AC 
	ON AU.ArticleId = AC.ArticleId
END