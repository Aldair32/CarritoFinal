using System;
using System.Collections.Generic;

namespace CarritoFinal.Models;

public partial class Provincia
{
    public string IdProvincia { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string IdDepartamento { get; set; } = null!;
}
