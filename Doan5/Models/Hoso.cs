using System;
using System.Collections.Generic;

namespace Doan5.Models
{
    public partial class Hoso
    {
        public int MaHs { get; set; }
        public int? MaCv { get; set; }
        public int? Mauser { get; set; }
        public int? MaKv { get; set; }
        public string Email { get; set; }
        public string Trangthai { get; set; }
        public string FileHs { get; set; }

        public virtual Vieclam MaCvNavigation { get; set; }
        public virtual Khuvuc MaKvNavigation { get; set; }
        public virtual UserNd MauserNavigation { get; set; }
    }
}
