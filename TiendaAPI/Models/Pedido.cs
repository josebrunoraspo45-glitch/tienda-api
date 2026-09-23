using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaAPI.Models;

public class Pedido
{
    public int Id { get; set; }
    public string? NombreCliente { get; set; }
    public DateTime Fecha { get; set; }

    public EstadoPedido Estado { get; set; }
    public ICollection<DetallePedido>? DetallePedidos { get; set; }
}
public enum EstadoPedido
{
    Pendiente,
    Enviado,
    Entregado
}