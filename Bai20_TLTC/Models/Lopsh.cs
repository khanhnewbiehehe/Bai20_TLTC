using System;
using System.Collections.Generic;

namespace Bai20_TLTC.Models;

public partial class Lopsh
{
    public string MaLsh { get; set; } = null!;

    public string TenLsh { get; set; } = null!;

    public string? MaNganh { get; set; }

    public int Siso { get; set; }

    public int? Sltt { get; set; }

    public string? MaKhoa { get; set; }

    public string? MaGvcn { get; set; }

    public int? Slnam { get; set; }

    public string? Status { get; set; }

    public string? GhiChu { get; set; }

    public int? KhoaHoc { get; set; }

    public string? MaLopTruong { get; set; }

    public string? MaLopPho { get; set; }

    public string? MaBiThu { get; set; }

    public int? HkhienHanh { get; set; }

    public string? HeDaoTao { get; set; }
}
