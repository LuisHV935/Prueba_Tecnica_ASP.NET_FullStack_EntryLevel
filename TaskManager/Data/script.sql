-- Script de creación de la base de datos
-- Ejecutar contra SQL Server antes de iniciar la app

CREATE TABLE ProjectTasks (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NULL,
    Status NVARCHAR(20) NOT NULL,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);
