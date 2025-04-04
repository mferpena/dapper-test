using System.Data;
using Dapper;
using ProductosApi.Domain;

namespace ProductosApi.Infrastructure;

public class ProductoRepository
{
    private readonly IDbConnection _db;

    public ProductoRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Producto>> GetAllAsync()
    {
        var sql = "SELECT Id, Nombre, Precio FROM Productos";
        return await _db.QueryAsync<Producto>(sql);
    }

    public async Task<int> InsertAsync(Producto producto)
    {
        var sql = "INSERT INTO Productos (Nombre, Precio) VALUES (@Nombre, @Precio)";
        return await _db.ExecuteAsync(sql, producto);
    }
}
