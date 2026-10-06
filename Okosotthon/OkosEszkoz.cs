using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public abstract class OkosEszkoz
    {
        private string azonosito;
        private string nev;
        private bool onlineE;
        private DateTime utolsoFrissites;

        public string Azonosito { get => azonosito; private set => azonosito = value; }
        public string Nev { get => nev; private set => nev = value; }
        public bool OnlineE { get => onlineE; private set => onlineE = value; }
        public DateTime UtolsoFrissites { get => utolsoFrissites; protected set => utolsoFrissites = value; }

        public OkosEszkoz(string azonosito, string nev)
        {

            this.Azonosito = azonosito;
            this.Nev = nev;
            OnlineE = false;
            UtolsoFrissites = DateTime.Now;
        }


        public void Csatlakozas()
        {
            this.OnlineE = true;
        }


        public void KapcsolatBontasa()
        {
            this.OnlineE = false;
        }
        public bool DiagnosztikaFuttatasa()
        {
            if (this.OnlineE == false)
            {
                return false;

            }
            bool eredmeny = this.OnTesztFuttatasa();
            return eredmeny;


        }

        public virtual void GyariBeallitasokVisszaallitasa()
        {
            this.UtolsoFrissites = DateTime.Now;
            this.OnlineE = false;

        }


        public abstract void ParancsVegrehajtasa(string parancs);
        public abstract string AllapotJelentes();
        protected abstract bool OnTesztFuttatasa();
    }
}
