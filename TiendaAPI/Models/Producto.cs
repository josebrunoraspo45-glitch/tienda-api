using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaAPI.Models;

public class Producto
{
    public int Id { get; set; }
    public string? Nombre { get; set; } 
    public string? Descripcion { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal PrecioCosto { get; set; } 

    [Column(TypeName = "decimal(10,2)")]
    public decimal PrecioVenta { get; set; } 

    public int Stock { get; set; }

    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }

    public ICollection<DetallePedido>? DetallePedidos { get; set; }
}