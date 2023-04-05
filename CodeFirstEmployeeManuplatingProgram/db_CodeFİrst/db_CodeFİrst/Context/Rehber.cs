using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_CodeFİrst.Context
{
    //Tablo içerisinde olmasını istediğimiz değerleri burada belirttik.
    internal class Rehber
    {
        public int RehberID { get; set; }
        public string Ad { get; set; } = null!; //!=>Damn it operatörü
        public string? Soyad { get; set; }
        public string? Telefon { get; set; }

       

    }

    
}
