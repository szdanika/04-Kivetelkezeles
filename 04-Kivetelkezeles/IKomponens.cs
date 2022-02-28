using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Kivetelkezeles
{
    internal interface IKomponens
    {
        public int Teljesitmeny { get; set; }
        public bool Allapot { get; set; }
        public void Aktival();
        public void DeAktival();
    }
}