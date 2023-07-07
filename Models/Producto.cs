using System;
using System.Collections.Generic;

namespace CarritoFinal.Models;

public partial class Producto
{
    public string CdProducto { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? CdMarca { get; set; }

    public string? CdCategoria { get; set; }

    public decimal? Precio { get; set; }

    public int? Stock { get; set; }

    public string? RutaImagen { get; set; }

    public string? NombreImagen { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual Categoria? CdCategoriaNavigation { get; set; }

    public virtual Marca? CdMarcaNavigation { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
}
