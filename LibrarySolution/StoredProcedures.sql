CREATE OR ALTER PROCEDURE dbo.GetAllBooksWithCategories
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        b.Id AS BookId,
        b.Title,
        b.Author,
        b.PublishedOn,
        STRING_AGG(c.[Name], ',') WITHIN GROUP (ORDER BY c.[Name]) AS Categories
    FROM Books b
    LEFT JOIN BookCategories bc ON bc.BookId = b.Id
    LEFT JOIN Categories c ON c.Id = bc.CategoryId
    GROUP BY b.Id, b.Title, b.Author, b.PublishedOn
    ORDER BY b.Title;
END
