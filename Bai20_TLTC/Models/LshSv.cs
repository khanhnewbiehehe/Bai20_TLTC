using System;
using System.Collections.Generic;

namespace Bai20_TLTC.Models;

public partial class LshSv
{
    public string MaLsh { get; set; } = null!;

    public string MaSv { get; set; } = null!;

    public int? CurSem { get; set; }

    public int? TichLuy { get; set; }

    public int? Gcp { get; set; }

    public int? Ecp { get; set; }

    public string? Status { get; set; }

    public string? GhiChu { get; set; }

    public string? Cn2 { get; set; }
}
