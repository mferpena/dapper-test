dotnet new sln -n ProductosApi
dotnet new webapi -n ProductosApi.Api
dotnet new classlib -n ProductosApi.Application
dotnet new classlib -n ProductosApi.Infrastructure
dotnet new classlib -n ProductosApi.Domain

dotnet add ProductosApi.Api reference ProductosApi.Application
dotnet add ProductosApi.Application reference ProductosApi.Infrastructure
dotnet add ProductosApi.Application reference ProductosApi.Domain
dotnet add ProductosApi.Infrastructure reference ProductosApi.Domain

dotnet add ProductosApi.Infrastructure package Dapper
dotnet add ProductosApi.Infrastructure package Npgsql

ProductosApi/
├── ProductosApi.Api                -> Controladores
├── ProductosApi.Application        -> Servicios
├── ProductosApi.Infrastructure     -> Dapper y acceso a datos
└── ProductosApi.Domain             -> Entidades y modelos

docker run --name postgres-productos -e POSTGRES_PASSWORD=postgres123 -e POSTGRES_DB=productosdb -p 5432:5432 -d postgres
docker exec -it postgres-productos psql -U postgres
CREATE DATABASE productosdb;
CREATE TABLE productos (
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(255) NOT NULL,
    precio DECIMAL(10, 2) NOT NULL
);
INSERT INTO productos (nombre, precio)
VALUES
    ('Producto 1', 100.50),
    ('Producto 2', 200.75),
    ('Producto 3', 150.00);
SELECT * FROM productos;

dotnet run --project ProductosApi.Api
