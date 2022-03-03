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
            if (Allapot == true)
                throw new InvalidOperationException();
            Allapot=true;
            //Teljesitmeny = 1 * Teljesitmeny;
            if(Teljesitmeny == 0)
                throw new NotSupportedException();
        }

        public void DeAktival()
        {
            if(Allapot == false)
                throw new InvalidOperationException("Nem sikerült deaktiválni a rektort");
            Allapot = false;
            Teljesitmeny=0;
        }
    }
}
