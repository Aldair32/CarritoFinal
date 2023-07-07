using System;
using System.Collections.Generic;

namespace CarritoFinal.Models;

public partial class Categoria
{ 
    public string CdCategoria { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
