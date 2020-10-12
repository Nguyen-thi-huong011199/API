using System;
using System.Collections.Generic;

namespace Doan5.Models
{
    public partial class UserNd
    {
        public UserNd()
        {
            Hoso = new HashSet<Hoso>();
            Nguoitimviec = new HashSet<Nguoitimviec>();
            Nhatuyendung = new HashSet<Nhatuyendung>();
            Taikhoan = new HashSet<Taikhoan>();
        }

        public int Mauser { get; set; }
        public string Tenuser { get; set; }
        public string Diachi { get; set; }
        public string Noilamviec { get; set; }
        public string Anhdaidien { get; set; }

        public virtual ICollection<Hoso> Hoso { get; set; }
        public virtual ICollection<Nguoitimviec> Nguoitimviec { get; set; }
        public virtual ICollection<Nhatuyendung> Nhatuyendung { get; set; }
        public virtual ICollection<Taikhoan> Taikhoan { get; set; }
    }
}
