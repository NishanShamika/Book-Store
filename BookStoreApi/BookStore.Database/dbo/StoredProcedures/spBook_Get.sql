CREATE PROCEDURE [dbo].[spBook_Get]
	@Id int = 0
AS
BEGIN
	SELECT * 
	FROM dbo.Books 
	WHERE Id = @Id
END
