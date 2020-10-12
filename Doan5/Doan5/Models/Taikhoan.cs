using System;
using System.Collections.Generic;

namespace Doan5.Models
{
    public partial class Taikhoan
    {
        public int MaTk { get; set; }
        public int? Mauser { get; set; }
        public string TenTk { get; set; }
        public string Matkhau { get; set; }
        public string Diachi { get; set; }
        public string Sdt { get; set; }
        public string Phanquyen { get; set; }

        public virtual UserNd MauserNavigation { get; set; }
    }
}
