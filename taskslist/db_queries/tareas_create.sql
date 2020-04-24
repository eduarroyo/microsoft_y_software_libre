CREATE TABLE Tareas (
    tarea_id BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    tarea NVARCHAR(500),
    resuelta BIT NOT NULL,
    usuario NVARCHAR(50),
    creado_fecha DATETIME NOT NULL,
    modificado_fecha DATETIME NOT NULL,
);
GO
