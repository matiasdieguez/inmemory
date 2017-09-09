/*
La base de datos debe tener un grupo de archivos MEMORY_OPTIMIZED_DATA
antes de crear el objeto con optimización para memoria.

El número de depósitos debe duplicar el número 
máximo esperado de valores diferentes en la 
clave de índice, redondeando a la potencia de dos más próxima.
*/

CREATE TABLE [dbo].[Values]
(
	[Id] INT NOT NULL PRIMARY KEY NONCLUSTERED HASH WITH (BUCKET_COUNT = 131072), 
    [Data] VARCHAR(1000) NOT NULL
) WITH (MEMORY_OPTIMIZED = ON)