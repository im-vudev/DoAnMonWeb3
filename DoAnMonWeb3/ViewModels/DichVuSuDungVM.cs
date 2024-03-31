
namespace DoAnMonWeb3.ViewModels
{
    public class DichVuSuDungVM
    {
        public int IDPhong { get; set; }
        public int IDDichVu { get; set; }
        public string? tenDichVu { get; set; }
        public string? tenPhong { get; set; }
    }

    public class GetDichVuVM
    {
        public int Id { get; set; }
        public string? tenDichVu { get; set; }
    }

    public class GetDichVuSuDungVM
    {
        public int IDPhong { get; set; }
        public int IDDichVu { get; set; }
        public string? tenDichVu { get; set; }
        public decimal giaDichVu { get; set; }
    }
}
