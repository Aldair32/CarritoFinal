using System;
using System.Collections.Generic;

namespace CarritoFinal.Models;

public partial class DetalleVenta
{
    public string CdDetalleVenta { get; set; } = null!;

    public string? CdvEnta { get; set; }

    public string? CdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Total { get; set; }

    public virtual Producto? CdProductoNavigation { get; set; }

    public virtual Venta? CdvEntaNavigation { get; set; }
}
