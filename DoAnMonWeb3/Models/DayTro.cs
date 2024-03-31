
namespace DoAnMonWeb3.Models
{
    public class DayTro
    {
        public int Id { get; set; }
        public string? tenDayTro { get; set; }
        public int? soLuongPhong { get; set; }

        public ICollection<Phong> phong { get; set; }
    }
}
