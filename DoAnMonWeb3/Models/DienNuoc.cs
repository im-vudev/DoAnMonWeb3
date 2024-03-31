namespace DoAnMonWeb3.Models
{
    public class DienNuoc
    {
        public int Id { get; set; }
        public int IDPhong { get; set; }
        public DateTime thoiGianHoaDon { get; set; }
        public int dienTieuThu { get; set; }
        public decimal giaDien { get; set; }
        public int nuocTieuThu { get; set; }
        public decimal giaNuoc { get; set; }
        public Phong phong { get; set; }
    }
}
