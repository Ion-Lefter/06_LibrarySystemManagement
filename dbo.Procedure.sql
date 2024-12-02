CREATE PROCEDURE SearchBooksByTitle
    @Title NVARCHAR(255)
AS
BEGIN
    SELECT 
        li.Id,
        li.Title,
        li.Author,
        li.YearPublished,
		b.ISBN
    FROM 
        LibraryItems li
    INNER JOIN 
        Books b ON li.Id = b.Id
    WHERE 
        li.Title LIKE '%' + @Title + '%';
END
GO