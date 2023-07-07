using System;
using System.Collections.Generic;

namespace CarritoFinal.Models;

public partial class Carrito
{
    public string CdCarrito { get; set; } = null!;

    public string? CdCliente { get; set; }

    public string? CdProducto { get; set; }

    public int? Cantidad { get; set; }

    public virtual Cliente? CdClienteNavigation { get; set; }

    public virtual Producto? CdProductoNavigation { get; set; }
}
