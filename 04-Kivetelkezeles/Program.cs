using System;

namespace _04_Kivetelkezeles
{
    enum UrhajoKategoria { Yacht, Korvett, Fregatt, Rombolo, Teher, Allomas }
    internal class Program
    {
        public static void MessageWriter(string message)
        {
            Console.WriteLine(message);
        }
        static void test1()
        {
            Urhajo elso = new Urhajo("elso", 0, UrhajoKategoria.Yacht);
            Reaktor re = new Reaktor(1);
            elso.KomponensFelszerel(re);
            elso.KomponensFelszerel(re);
            elso.KomponensFelszerel(re);

        }
        static void test2()
        {
            Urhajo masodik;
            try
            {
                Console.WriteLine("----------------------------------------------");
                masodik = new Urhajo("Star Destroyer", 2, UrhajoKategoria.Yacht);
                Reaktor re = new Reaktor(1);
                masodik.KomponensFelszerel(re);
                masodik.KomponensFelszerel(re);
                masodik.KomponensFelszerel(re);
            }          
            catch (ArgumentNullException e)
            {
                MessageWriter("Kerem adjon meg egy nevet az urhajonak!");
            }
            catch(ArgumentOutOfRangeException e)
            {
                MessageWriter(e.Message);
            }
            try
            {
                Console.WriteLine("----------------------------------------------");
                Urhajo nincsnevtest = new Urhajo("", 1, UrhajoKategoria.Yacht);
            }
            catch(ArgumentNullException)
            {
                MessageWriter("Kérem adjon meg egy nevet");
            }
            try
            {
                Console.WriteLine("----------------------------------------------");
                Urhajo nincsures = new Urhajo("Uresseg", 0, UrhajoKategoria.Yacht);
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageWriter("Kérem adjon meg egy 0-nál nagyobb számot");
            }
            try
            {
                Console.WriteLine("----------------------------------------------");
                Urhajo kompleszedes = new Urhajo("Kompleszedes", 2, UrhajoKategoria.Yacht);
                Reaktor re = new Reaktor(1);
                kompleszedes.KomponensFelszerel(re);
                kompleszedes.KomponensFelszerel(re);
                kompleszedes.KomponensLeszerel(1);
                kompleszedes.KomponensLeszerel(5);
            }
            catch(KomponensNemTalalhatoKivetelException e)
            {
                MessageWriter(e.Message);
            }
            try
            {
                Console.WriteLine("----------------------------------------------");
                Urhajo Beinditasproba = new Urhajo("Kompleszedes", 1, UrhajoKategoria.Yacht);
                Reaktor re = new Reaktor(5);
                Beinditasproba.KomponensFelszerel(re);
                Reaktor rek = new Reaktor(-5);
                Beinditasproba.KomponensFelszerel(rek);
                Beinditasproba.Padlogaz();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(NincsElegEnergiaKivetelException e)
            {
                Console.WriteLine(e.Message ); 
            }
            try
            {
                Console.WriteLine("----------------------------------------------");
                Urhajo Lealitasproba = new Urhajo("Kompleszedes", 1, UrhajoKategoria.Yacht);
                Reaktor re = new Reaktor(5);
                Lealitasproba.KomponensFelszerel(re);
                Lealitasproba.HajtomuvekLealitasa();
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            test2();
        }
    }
}
