using System;
using System.Collections.Generic;

namespace Doan5.Models
{
    public partial class Nguoitimviec
    {
        public int MaNtv { get; set; }
        public int? Mauser { get; set; }
        public string TenNtv { get; set; }

        public virtual UserNd MauserNavigation { get; set; }
    }
}
