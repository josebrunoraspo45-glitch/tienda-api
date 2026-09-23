using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaAPI.Data;
using TiendaAPI.Models;

namespace TiendaAPI.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class PedidosController : ControllerBase
{
    private readonly AppDbContext _context;

    public PedidosController (AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
    {
        return await _context.Pedidos
            .Include(p => p.DetallePedidos)
            .ToListAsync();
    }
}

 