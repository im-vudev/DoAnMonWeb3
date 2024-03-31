namespace DoAnMonWeb3.Models
{
    public class DichVu
    {
        public int Id { get; set; }
        public string tenDichVu { get; set; }
        public decimal giaDichVu { get; set; }

        public ICollection<DichVuSuDung> dichVuSuDung { get; set; }
    }
}
