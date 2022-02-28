using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Kivetelkezeles
{
    internal class KomponensNemTalalhatoKivetelException : Exception
    {
        public KomponensNemTalalhatoKivetelException()
        {

        }
        public KomponensNemTalalhatoKivetelException(string message) : base(message)
        {

        }
    }
    class NemDeaktivalhatoKivetelException : Exception
    {
        public NemDeaktivalhatoKivetelException(string message, Exception e) : base(message,e)
        {

        }
    }
    class KomponensNemFerElKivetelException : Exception
    {
        IKomponens komponens;
        public IKomponens Komponens { get { return komponens; } }
        public KomponensNemFerElKivetelException(string message, IKomponens komponens) : base(message)
        {
            this.komponens = komponens;
        }
    }
    class NincsElegEnergiaKivetelException : Exception
    {
        int hianyMerteke;
        public int HianyMerteke { get { return hianyMerteke; } }
        public NincsElegEnergiaKivetelException(int hianymerteke) : base("Nincs eleg teljesitmeny," + hianymerteke + "MW hianyzik")
        {
            this.hianyMerteke = hianymerteke;
        }
    }
}
