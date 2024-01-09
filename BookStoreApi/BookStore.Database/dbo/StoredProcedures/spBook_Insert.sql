CREATE PROCEDURE [dbo].[spBook_Insert]
	@Title nvarchar(50),
	@Author nvarchar(50),
	@PublicationYear int
AS
BEGIN
	INSERT INTO Books (Title, Author, PublicationYear) 
	VALUES (@Title, @Author, @PublicationYear)
END
