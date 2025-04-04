using ProductosApi.Domain;
using ProductosApi.Infrastructure;

namespace ProductosApi.Application;

public class ProductoService
{
    private readonly ProductoRepository _repo;

    public ProductoService(ProductoRepository repo)
    {
        _repo = repo;
    }

    public Task<IEnumerable<Producto>> GetAllAsync() => _repo.GetAllAsync();

    public Task<int> CreateAsync(Producto producto) => _repo.InsertAsync(producto);
}
