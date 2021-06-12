using System;

public class BaiHat
{
    public int Id { get; set; }
    public int Id_nhacsi { get; set; }
    public int Id_dongnhac { get; set; }
    public string Ten_bai_hat { get; set; }
    public DateTime NgayDang { get; set; }
    public int LuotNghe { get; set; }
    public BaiHat()
	{
	}
    public BaiHat (int id, int id_nhacsi, int id_dongnhac, string tenBH, DateTime ngaydang, int luotnghe) 
    {
        this.Id = id;
        this.Id_nhacsi = id_nhacsi;
        this.Id_dongnhac = id_dongnhac;
        this.Ten_bai_hat = tenBH;
        this.NgayDang = ngaydang;
        this.LuotNghe = luotnghe;
    }
}
