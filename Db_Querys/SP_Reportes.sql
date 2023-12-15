CREATE PROCEDURE SP_VentasTotalesPorMes_Anio
    @Anio INT,
    @ColumnaOrderBy NVARCHAR(50) = 'Mes',
    @OrdenarPor NVARCHAR(4) = 'ASC'
AS
BEGIN
    DECLARE @OrderBy NVARCHAR(100);

    -- Validar input para evitar inyección SQL
    SET @ColumnaOrderBy = CASE 
        WHEN @ColumnaOrderBy IN ('Mes', 'MontoTotalMes', 'NumeroDeVentas') THEN @ColumnaOrderBy
        ELSE 'Mes'
    END;

    SET @OrdenarPor = UPPER(@OrdenarPor);
    SET @OrdenarPor = CASE 
        WHEN @OrdenarPor IN ('ASC', 'DESC') THEN @OrdenarPor
        ELSE 'ASC'
    END;

    SET @OrderBy = QUOTENAME(@ColumnaOrderBy) + ' ' + @OrdenarPor;

    DECLARE @SQLQuery NVARCHAR(MAX);

    SET @SQLQuery = N'
        SELECT
            FORMAT(FechaCompra, ''MMMM'') AS Mes,
            SUM(PrecioTotal) AS MontoTotalMes,
            COUNT(*) AS NumeroDeVentas
        FROM Compra
        WHERE YEAR(FechaCompra) = @ParamAnio AND ID_Estado <> 4
        GROUP BY FORMAT(FechaCompra, ''MMMM'')
        ORDER BY ' + @OrderBy + ';';

    EXEC sp_executesql @SQLQuery, N'@ParamAnio INT', @Anio;
END;

EXEC sp_VentasTotalesPorMes_Anio
    @Anio = 2023,
    @ColumnaOrderBy = 'MontoTotalMes',
    @OrdenarPor = 'DESC';

--DROP PROCEDURE IF EXISTS sp_VentasTotalesPorMes_Anio