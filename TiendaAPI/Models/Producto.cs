using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaAPI.Models;

public class Producto
{
    public int Id { get; set; }
    public string? Nombre { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
}