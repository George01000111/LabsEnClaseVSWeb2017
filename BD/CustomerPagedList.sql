CREATE PROCEDURE [dbo].[CustomerPagedList]
@startRow int,
@endRow int
AS
BEGIN
WITH CustomerResult AS
(
SELECT [Id]
,[FirstName]
,[LastName]
,[City]
,[Country]
,[Phone]
,ROW_NUMBER() OVER (ORDER BY Id) AS RowNum
FROM .[dbo].[Customer]
)
SELECT [Id]
,[FirstName]
,[LastName]
,[City]
,[Country]
,[Phone]
FROM CustomerResult
WHERE RowNum BETWEEN @startRow AND @endRow;
END