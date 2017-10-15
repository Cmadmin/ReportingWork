
Create PROC LoadAllTables	
AS
BEGIN



DECLARE @TableName AS NVARCHAR(255)
DECLARE @TableId AS INT
DECLARE @ColumnName AS NVARCHAR(255)
DECLARE @AllSql AS NVARCHAR(max)

DECLARE @TableNames AS TABLE(Id INT IDENTITY(1,1), Name NVARCHAR(255), ColumnJson NVARCHAR(max) NULL, Processed BIT DEFAULT(0))

DECLARE @TabRawData AS TABLE(
	   Id INT IDENTITY(1,1),
	   TABLE_SCHEMA NVARCHAR(200),
       TABLE_NAME  NVARCHAR(200),
       COLUMN_NAME  NVARCHAR(200),
       ORDINAL_POSITION  NVARCHAR(200),
       COLUMN_DEFAULT  NVARCHAR(200),
       DATA_TYPE  NVARCHAR(200),
       CHARACTER_MAXIMUM_LENGTH  NVARCHAR(200),
       NUMERIC_PRECISION  NVARCHAR(200),
       NUMERIC_PRECISION_RADIX  NVARCHAR(200),
       NUMERIC_SCALE  NVARCHAR(200),
       DATETIME_PRECISION  NVARCHAR(200)
	)

INSERT INTO @TableNames 
SELECT Name, '', 0
FROM Sys.tables

INSERT INTO @TabRawData
 SELECT 
	   TABLE_SCHEMA ,
       TABLE_NAME ,
       COLUMN_NAME ,
       ORDINAL_POSITION ,
       COLUMN_DEFAULT ,
       DATA_TYPE ,
       CHARACTER_MAXIMUM_LENGTH ,
       NUMERIC_PRECISION ,
       NUMERIC_PRECISION_RADIX ,
       NUMERIC_SCALE ,
       DATETIME_PRECISION
FROM   INFORMATION_SCHEMA.COLUMNS
ORDER BY TABLE_NAME;

WHILE (SELECT COUNT(Id) FROM @TableNames WHERE Processed = 0) > 0
BEGIN

	 SET @AllSql = ''
	 SELECT TOP 1 @TableName = Name, @TableId = Id FROM @TableNames WHERE Processed = 0

	 SELECT @AllSql = @AllSql + (CASE WHEN @AllSql = '' THEN '' ELSE ',' END)
	  + '{"name":"' + COLUMN_NAME + '", "type":"' + DATA_TYPE + '", "maxlength":' + ISNULL(CHARACTER_MAXIMUM_LENGTH, 0)
	  + ', "numericprecision":' + ISNULL(NUMERIC_PRECISION,0) + ', "numericprecision_radix":' + ISNULL(NUMERIC_PRECISION_RADIX, 0) + 
	  ', "numericprecision_scale":' + ISNULL(NUMERIC_SCALE, 0) + ', "datetimeprecision":' + ISNULL(DATETIME_PRECISION, 0)
	  + ' }' FROM @TabRawData WHERE TABLE_NAME = @TableName

	 UPDATE @TableNames SET ColumnJson = @AllSql, Processed = 1 WHERE Id = @TableId

END

SELECT Name, ColumnJson 
FROM @TableNames

End


