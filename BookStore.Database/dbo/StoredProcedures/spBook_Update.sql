CREATE PROCEDURE [dbo].[spBook_Update]
	@Id int = 0,
	@Title nvarchar(50),
	@Author nvarchar(50),
	@PublicationYear int
AS
BEGIN
	UPDATE Books 
	SET Title = @Title, Author = @Author, PublicationYear = @PublicationYear 
	WHERE Id = @Id
END
