SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdmisg015SelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdmisg015SelectByID]
GO
 
CREATE PROCEDURE [dbo].[spdmisg015SelectByID]
  @LoginID NVarChar(8),
  @t_type Int,
  @t_cprj VarChar(9),
  @t_srno Int 
  AS
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdmisg015SelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdmisg015SelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spdmisg015SelectListSearch]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @KeyWord VarChar(250),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,t_type Int NOT NULL
 ,t_cprj VarChar(9) NOT NULL
 ,t_srno Int NOT NULL
  )
  INSERT INTO #PageIndex (t_type, t_cprj, t_srno)
  SELECT [tdmisg015" & Comp & " ].[t_type], [tdmisg015" & Comp & " ].[t_cprj], [tdmisg015" & Comp & " ].[t_srno] FROM [tdmisg015" & Comp & " ]
 WHERE  
   ( 
         STR(ISNULL([tdmisg015" & Comp & " ].[t_type], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg015" & Comp & " ].[t_cprj],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg015" & Comp & " ].[t_srno], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg015" & Comp & " ].[t_tfld],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg015" & Comp & " ].[t_tfid], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg015" & Comp & " ].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg015" & Comp & " ].[t_Refcntu], 0)) LIKE @KeyWord1
   ) 
  ORDER BY (Select @OrderBy)

    SET @RecordCount = @@RowCount

  SELECT
    [tdmisg015" & Comp & " ].*  
  FROM [tdmisg015" & Comp & " ] 
      INNER JOIN #PageIndex
          ON [tdmisg015" & Comp & " ].[t_type] = #PageIndex.t_type
          AND [tdmisg015" & Comp & " ].[t_cprj] = #PageIndex.t_cprj
          AND [tdmisg015" & Comp & " ].[t_srno] = #PageIndex.t_srno
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdmisg015SelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdmisg015SelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spdmisg015SelectListFilteres]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  IF (@OrderBy = '')
    SET @OrderBy = 't_type, t_cprj, t_srno'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,t_type Int NOT NULL
 ,t_cprj VarChar(9) NOT NULL
 ,t_srno Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL +=  't_type'
  SET @LGSQL +=  ', t_cprj'
  SET @LGSQL +=  ', t_srno'
  SET @LGSQL +=  ')'
  SET @LGSQL +=  ' SELECT '
  SET @LGSQL +=  '[tdmisg015" & Comp & " ].[t_type]'
  SET @LGSQL +=  ', [tdmisg015" & Comp & " ].[t_cprj]'
  SET @LGSQL +=  ', [tdmisg015" & Comp & " ].[t_srno]'
  SET @LGSQL +=  ' FROM [tdmisg015" & Comp & " ] '
  SET @LGSQL +=  '  WHERE 1 = 1 '
  SET @LGSQL +=  '  ORDER BY ' + @OrderBy
 
 
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [tdmisg015" & Comp & " ].*  
  FROM [tdmisg015" & Comp & " ] 
      INNER JOIN #PageIndex
          ON [tdmisg015" & Comp & " ].[t_type] = #PageIndex.t_type
          AND [tdmisg015" & Comp & " ].[t_cprj] = #PageIndex.t_cprj
          AND [tdmisg015" & Comp & " ].[t_srno] = #PageIndex.t_srno
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdmisg015Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdmisg015Insert]
GO
 
CREATE PROCEDURE [dbo].[spdmisg015Insert]
  @t_type Int,
  @t_cprj VarChar(9),
  @t_srno Int,
  @t_tfld VarChar(256),
  @t_tfid Int,
  @t_Refcntd Int,
  @t_Refcntu Int,
  @Return_t_type Int = null OUTPUT, 
  @Return_t_cprj VarChar(9) = null OUTPUT, 
  @Return_t_srno Int = null OUTPUT 
  AS
  INSERT [tdmisg015" & Comp & " ]
  (
   [t_type]
  ,[t_cprj]
  ,[t_srno]
  ,[t_tfld]
  ,[t_tfid]
  ,[t_Refcntd]
  ,[t_Refcntu]
  )
  VALUES
  (
   @t_type
  ,UPPER(@t_cprj)
  ,@t_srno
  ,@t_tfld
  ,@t_tfid
  ,@t_Refcntd
  ,@t_Refcntu
  )
  SET @Return_t_type = @t_type
  SET @Return_t_cprj = @t_cprj
  SET @Return_t_srno = @t_srno
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdmisg015Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdmisg015Update]
GO
 
CREATE PROCEDURE [dbo].[spdmisg015Update]
  @Original_t_type Int, 
  @Original_t_cprj VarChar(9), 
  @Original_t_srno Int, 
  @t_type Int,
  @t_cprj VarChar(9),
  @t_srno Int,
  @t_tfld VarChar(256),
  @t_tfid Int,
  @t_Refcntd Int,
  @t_Refcntu Int,
  @RowCount int = null OUTPUT
  AS
  UPDATE [tdmisg015" & Comp & " ] SET 
   [t_type] = @t_type
  ,[t_cprj] = @t_cprj
  ,[t_srno] = @t_srno
  ,[t_tfld] = @t_tfld
  ,[t_tfid] = @t_tfid
  ,[t_Refcntd] = @t_Refcntd
  ,[t_Refcntu] = @t_Refcntu
  WHERE
  [t_type] = @Original_t_type
  AND [t_cprj] = @Original_t_cprj
  AND [t_srno] = @Original_t_srno
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spdmisg015Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spdmisg015Delete]
GO
 
CREATE PROCEDURE [dbo].[spdmisg015Delete]
  @Original_t_type Int,
  @Original_t_cprj VarChar(9),
  @Original_t_srno Int,
  @RowCount int = null OUTPUT
  AS
  DELETE [tdmisg015" & Comp & " ]
  WHERE
  [tdmisg015" & Comp & " ].[t_type] = @Original_t_type
  AND [tdmisg015" & Comp & " ].[t_cprj] = @Original_t_cprj
  AND [tdmisg015" & Comp & " ].[t_srno] = @Original_t_srno
  SET @RowCount = @@RowCount
  GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
