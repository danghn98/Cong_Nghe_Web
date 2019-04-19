using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Ban_Giay_2.Models
{
    public class San_Pham
    {
        public int Id { get; set; }

        public string TenGiay { get; set; }

        public double GiaBan { get; set; }

        public int Size { get; set; }

        public string Mau { get; set; }

        public string ThuongHieu { get; set; }
    }
}