﻿namespace DoAnMonWeb3.Models
{
    public class ThuePhong
    {
        public int Id { get; set; }
        public int IDPhong { get; set; }
        public int IDNguoiThue { get; set; }
        public DateTime ngayThue { get; set; }
        public DateTime ngayTra { get; set; }
        public decimal tienCoc { get; set; }

        public Phong phong { get; set; }
        public NguoiThue nguoiThue { get; set; }
        public ICollection<HoaDon> hoaDon { get; set; }
    }
}
