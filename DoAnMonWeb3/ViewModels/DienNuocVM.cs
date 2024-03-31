namespace DoAnMonWeb3.ViewModels
{
    public class DienNuocVM
    {
        public int Id { get; set; }
        public int IDPhong { get; set; }
        public DateTime thoiGianHoaDon { get; set; }
        public int dienTieuThu { get; set; }
        public decimal giaDien { get; set; }
        public int nuocTieuThu { get; set; }
        public decimal giaNuoc { get; set; }
        public string? tenPhong { get; set; }
        //public int phongId { get; set; }
    }

    public class GetPhongVM
    {
        public int Id { get; set; }
        public string? tenPhong { get; set; }
    }
}
