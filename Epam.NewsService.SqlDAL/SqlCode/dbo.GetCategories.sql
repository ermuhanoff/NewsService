CREATE PROCEDURE [dbo].[GetCategories]

AS
BEGIN
	SELECT C.Id AS CategoryId, C.Name AS CategoryTitle, C.Description AS CategoryDesc
	FROM Categories as C
END
GO
