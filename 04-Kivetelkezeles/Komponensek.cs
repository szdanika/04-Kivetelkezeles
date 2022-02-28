using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Kivetelkezeles
{
    class Hajtomu : IKomponens
    {
        int toloero;
        public Hajtomu(int toloero)
        {
            this.toloero = toloero;
        }
        int teljesitmeny;
        public int Teljesitmeny { get => teljesitmeny; set => teljesitmeny = value; }
        bool allapot;
        public bool Allapot { get => allapot; set => allapot = value; }
        public void Aktival()
        {
            Allapot = true;
            Teljesitmeny = toloero;
        }

        public void DeAktival()
        {
            Teljesitmeny = 0;
            Allapot = false;
        }
    }
    class Reaktor : IKomponens
    {
        int teljesitmeny;
        public int Teljesitmeny { get => teljesitmeny; set => teljesitmeny = value;}
        bool allapot;
        public bool Allapot { get => allapot; set => allapot = value; }
        public Reaktor(int teljesitmeny)
        {
            this.teljesitmeny =teljesitmeny;
        }

        public void Aktival()
        {
            Allapot=true;
            Teljesitmeny = -1 * Teljesitmeny;
        }

        public void DeAktival()
        {
            Allapot = false;
            Teljesitmeny=0;
        }
    }
}
