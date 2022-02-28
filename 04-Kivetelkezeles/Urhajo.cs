using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Kivetelkezeles
{
    internal class Urhajo
    {
        string nev;
        public string Nev { get { return nev; } }
        int uresTomeg;
        public int UresTomeg { get { return uresTomeg; } }
        int aktualisTeljesitmeny;
        public int AktualisTeljesitmeny { get { return aktualisTeljesitmeny;} }
        UrhajoKategoria kategoria;
        public UrhajoKategoria Kategoria { get { return kategoria; } }
        IKomponens[] komponensek;
        public Urhajo(string nev, int uresTomeg, UrhajoKategoria kategoria)
        {
            this.nev = nev;
            this.uresTomeg = uresTomeg;
            this.kategoria = kategoria;
            int ertek;
            switch(kategoria)
            {
                case UrhajoKategoria.Yacht: ertek = 2;break;
                case UrhajoKategoria.Korvett: ertek = 4;break;
                case UrhajoKategoria.Fregatt: ertek = 6;break;
                case UrhajoKategoria.Rombolo: ertek = 8;break;
                case UrhajoKategoria.Teher: ertek = 8;break;
                case UrhajoKategoria.Allomas: ertek = 20;break;
                default: ertek = 0;break;
            }
            komponensek = new IKomponens[ertek];
        }
        public void KomponensFelszerel(IKomponens komponens)
        {
            bool felszerelve = false;
            int i = 0;
            while(felszerelve == false || i == komponensek.Length)
            {
                if(komponensek[i] == null)
                {
                    komponensek[i] = komponens;
                    felszerelve=true;
                }
                i++;
            }
        }
        public void KomponensLeszerel(int index)
        {
            komponensek[index] = null;
        }
    }
}
