using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaAPI.Data;
using TiendaAPI.Models;

namespace TiendaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
    {
        return await _context.Productos.Include(p => p.Categoria).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> GetProducto(int id)
    {
        var producto = await _context.Productos
            .Include(p => p.Categoria)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (producto == null)
        {
            return NotFound();
        }

        return producto;
    }

    [HttpPost]
    public async Task<ActionResult<Producto>> PostProducto(Producto producto)
    {
        var categoriaExiste = await _context.Categorias.FindAsync(producto.CategoriaId);

        if (categoriaExiste == null)
        {
            return BadRequest("La categoría indicada no existe.");
        }

        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProducto(int id, Producto producto)
    {
        var productoExistente = await _context.Productos.FindAsync(id);

        if (productoExistente == null)
        {
            return NotFound();
        }
        var categoriaExiste = await _context.Categorias.FindAsync(producto.CategoriaId);
        if (categoriaExiste == null)
        {
            return BadRequest("La categoría indicada no existe.");
        }


        productoExistente.Nombre = producto.Nombre;
        productoExistente.Precio = producto.Precio;
        productoExistente.Stock = producto.Stock;
        productoExistente.CategoriaId = producto.CategoriaId;

        await _context.SaveChangesAsync();

        return NoContent();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducto(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null)
        {
            return NotFound();
        }

        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}