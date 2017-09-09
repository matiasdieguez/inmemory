/*
La base de datos debe tener un grupo de archivos MEMORY_OPTIMIZED_DATA
antes de crear el objeto con optimización para memoria.
*/

CREATE PROCEDURE [dbo].[ValuesInsert]
	@data VARCHAR(1000)
WITH NATIVE_COMPILATION, SCHEMABINDING, EXECUTE AS OWNER 
AS 
BEGIN ATOMIC WITH (TRANSACTION ISOLATION LEVEL = SNAPSHOT, LANGUAGE = N'English')

	INSERT INTO [dbo].[Values] ([Data]) VALUES (@data)

	RETURN 0

END