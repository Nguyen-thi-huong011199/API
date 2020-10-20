using System;
using System.Collections.Generic;

namespace Doan5.Models
{
    public partial class Khuvuc
    {
        public Khuvuc()
        {
            Hoso = new HashSet<Hoso>();
            Vieclam = new HashSet<Vieclam>();
        }

        public int MaKv { get; set; }
        public string TenKv { get; set; }

        public virtual ICollection<Hoso> Hoso { get; set; }
        public virtual ICollection<Vieclam> Vieclam { get; set; }
    }
}
