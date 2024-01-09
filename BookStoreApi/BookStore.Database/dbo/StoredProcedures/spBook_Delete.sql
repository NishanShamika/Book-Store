CREATE PROCEDURE [dbo].[spBook_Delete]
	@Id int = 0
AS
BEGIN
	DELETE FROM Books 
	WHERE Id = @Id
END
