using System;
using System.Collections.Generic;

namespace Doan5.Models
{
    public partial class Vieclam
    {
        public Vieclam()
        {
            Hoso = new HashSet<Hoso>();
        }

        public int MaCv { get; set; }
        public int? MaloaiCv { get; set; }
        public int? MaNtd { get; set; }
        public int? MaKv { get; set; }
        public string TenCv { get; set; }
        public string Tencongty { get; set; }
        public string MotaCv { get; set; }
        public string Mucluong { get; set; }
        public string Diachi { get; set; }
        public string Anh { get; set; }
        public DateTime? Ngaydang { get; set; }
        public string Luotxem { get; set; }

        public virtual Khuvuc MaKvNavigation { get; set; }
        public virtual Nhatuyendung MaNtdNavigation { get; set; }
        public virtual Loaicongviec MaloaiCvNavigation { get; set; }
        public virtual ICollection<Hoso> Hoso { get; set; }
    }
}
