using System;
using System.Collections.Generic;

namespace CarritoFinal.Models;

public partial class Venta
{
    public string CdvEnta { get; set; } = null!;

    public string? CdCliente { get; set; }

    public int? TotalProducto { get; set; }

    public decimal? MontoTotal { get; set; }

    public string? Contacto { get; set; }

    public string? IdDistrito { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? IdTransaccion { get; set; }

    public DateTime? FechaVenta { get; set; }

    public virtual Cliente? CdClienteNavigation { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
}
