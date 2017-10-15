

Create PROC LoadTablesSchema
	@TableNames NVARCHAR(max)
AS
BEGIN
	
	DECLARE @tabNames AS TABLE(Name NVARCHAR(200))-- assume table is not bigger than this

	INSERT INTO @tabNames
	 SELECT * FROM dbo.SplitCSV(@TableNames)

	 
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
	FROM   INFORMATION_SCHEMA.COLUMNS InfoSch
	INNER JOIN @tabNames tn
		ON InfoSch.TABLE_NAME = tn.Name
	ORDER BY TABLE_NAME;


End