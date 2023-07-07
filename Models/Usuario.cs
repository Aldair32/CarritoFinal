using System;
using System.Collections.Generic;

namespace CarritoFinal.Models;

public partial class Usuario
{
    public string CdUsuario { get; set; } = null!;

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }

    public bool? Reestablecer { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
