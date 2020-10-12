using System;
using System.Collections.Generic;

namespace Doan5.Models
{
    public partial class Nhatuyendung
    {
        public Nhatuyendung()
        {
            Vieclam = new HashSet<Vieclam>();
        }

        public int MaNtd { get; set; }
        public int? Mauser { get; set; }
        public string TenNtd { get; set; }

        public virtual UserNd MauserNavigation { get; set; }
        public virtual ICollection<Vieclam> Vieclam { get; set; }
    }
}
