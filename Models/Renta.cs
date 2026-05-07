namespace Catalogo.Models;

public class Renta
{
    public int Id { get; set; }
    public int VideojuegoId { get; set; }
    public int ClienteId { get; set; }
    public DateTime FechaRenta { get; set; }
    public DateTime FechaDevolucion { get; set; }
    public bool Devuelta { get; set; }
}
