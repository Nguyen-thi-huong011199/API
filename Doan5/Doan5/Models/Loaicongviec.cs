using System;
using System.Collections.Generic;

namespace Doan5.Models
{
    public partial class Loaicongviec
    {
        public Loaicongviec()
        {
            Vieclam = new HashSet<Vieclam>();
        }

        public int MaloaiCv { get; set; }
        public string TenloaiCv { get; set; }

        public virtual ICollection<Vieclam> Vieclam { get; set; }
    }
}
