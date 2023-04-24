using System;
using System.Collections.Generic;

namespace cb_ejercicio1.Models;

public partial class CbcReglaInconsistencia
{
    public int ReglaId { get; set; }

    public string? TipoRegla { get; set; }

    public string? Regla { get; set; }
}
