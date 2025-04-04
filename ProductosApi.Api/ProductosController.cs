using Microsoft.AspNetCore.Mvc;
using ProductosApi.Application;
using ProductosApi.Domain;

namespace ProductosApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly ProductoService _service;

    public ProductosController(ProductoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var productos = await _service.GetAllAsync();
        return Ok(productos);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Producto producto)
    {
        var result = await _service.CreateAsync(producto);
        return Ok(new { filasAfectadas = result });
    }
}
