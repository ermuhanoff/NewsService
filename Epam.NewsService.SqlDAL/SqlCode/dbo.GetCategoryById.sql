CREATE PROCEDURE [dbo].[GetCategoryById]
	@Id int
AS
BEGIN
	SELECT C.Id AS CategoryId, C.Name AS CategoryTitle, C.Description AS CategoryDesc
	FROM Categories AS C
	WHERE C.Id = @Id
END
GO