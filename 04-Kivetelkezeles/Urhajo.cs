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
        int aktualisTeljesitmeny = 1;
        public int AktualisTeljesitmeny { get { return aktualisTeljesitmeny;} }
        UrhajoKategoria kategoria;
        public UrhajoKategoria Kategoria { get { return kategoria; } }
        IKomponens[] komponensek;
        public Urhajo(string nev, int uresTomeg, UrhajoKategoria kategoria)
        {
                this.nev = nev;
                if (nev == null || nev=="")
                    throw new ArgumentNullException(nev);
                this.uresTomeg = uresTomeg;
                if (uresTomeg <= 0)
                    throw new ArgumentOutOfRangeException("UresTomeg", "Kerem adjon meg 0 nal nagyobb erteku tomeget");
                Program.MessageWriter("[Letrehozás]" +nev + " Sikeresen létrehozva!");
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
            while(felszerelve == false && i < komponensek.Length)
            {
                if(komponensek[i] == null)
                {
                    komponensek[i] = komponens;
                    felszerelve=true;
                    Program.MessageWriter("[hozzadas]"+ komponens.ToString().Split('.')[1] + "hozzadva a " + nev + "hez");
                }
                i++;
            }
            if(felszerelve == false)
                new KomponensNemFerElKivetelException("Nem tudtam felszerelni :",komponens);
        }
        public void KomponensLeszerel(int index)
        {
            try
            {
                if(komponensek[index] == null)
                    throw new KomponensNemTalalhatoKivetelException("Ezen a helyen nem letezik komponens");
                Program.MessageWriter("[leszedés] Sikeresen leszedtem a "+ komponensek[index].ToString().Split('.')[1] +"-t a "+ nev +" ről, Index : " + index);
                komponensek[index] = null;
            }
            catch(IndexOutOfRangeException)
            {
                throw new KomponensNemTalalhatoKivetelException("[Kivétel] A törölni kívánt komponens nem létezik");
            }
        }
        public void Padlogaz()
        {
            for(int i = 0; i < komponensek.Length; i++)
            {
                if(komponensek[i] is Reaktor)
                {
                        (komponensek[i] as Reaktor).Aktival();
                        aktualisTeljesitmeny = aktualisTeljesitmeny -(komponensek[i] as Reaktor).Teljesitmeny;
                        if (aktualisTeljesitmeny <= 0)
                            throw new NincsElegEnergiaKivetelException(aktualisTeljesitmeny);
                }
            }
        }
        public void HajtomuvekLealitasa()
        {
            Console.WriteLine("[Leallitas]" + Nev + " Leálítása");
            foreach(var i in komponensek)
            {
                i.DeAktival();
            }
            aktualisTeljesitmeny = 0;
        }
        public void Beindit()
        {
            int i = 0;
            foreach(var re in komponensek)
            {
                if(re is Reaktor)
                {
                    try
                    {
                        (re as Reaktor).Aktival();
                    }
                    catch(InvalidOperationException)
                    {
                        Console.WriteLine("A reaktor már be van kapcsolva");
                    }
                    catch(NotSupportedException)
                    {
                        KomponensLeszerel(i);
                    }
                }
                i++;
            }
        }
        public void Leallit()
        {
            foreach(var komp in komponensek)
            {
                try
                {
                    komp.DeAktival();
                }
                catch(InvalidOperationException e)
                {
                    throw new NemDeaktivalhatoKivetelException(e.Message, e);
                }

            }
        }
    }
}
