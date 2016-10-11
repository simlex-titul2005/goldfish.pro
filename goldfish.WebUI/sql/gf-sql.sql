/************************************************************
 * Code formatted by SoftTree SQL Assistant © v6.5.278
 * Time: 11.10.2016 10:21:37
 ************************************************************/

/*******************************************
 * обогатить сервисы сайта
 *******************************************/
IF OBJECT_ID(N'dbo.enrich_site_services', N'P') IS NOT NULL
    DROP PROCEDURE dbo.enrich_site_services;
GO
CREATE PROCEDURE dbo.enrich_site_services
	@ids NVARCHAR(MAX)
AS
BEGIN
	SELECT dss.Id,
	       dss.MainPageIconCssClass
	FROM   D_SITE_SERVICE AS dss
	WHERE  dss.Id IN (SELECT fsi.[Value]
	                  FROM   dbo.func_split_int(@ids) AS fsi)
END
GO