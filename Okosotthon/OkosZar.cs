using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosZar: OkosEszkoz, IHangjezlo, IStatisztika
    {
        private int nyitasokszama = 0;
        private bool rosszPin = false;
        private bool zartE;
        private string pinKod;

        public bool ZartE { get => zartE; private set => zartE = value; }

        public OkosZar(string azonosito, string nev, string pinKod)
        : base(azonosito, nev)
        {
            this.pinKod = pinKod;
            this.ZartE = true;

        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs.StartsWith("NYITAS:"))
            {
                string[] darabok = parancs.Split(':');

                if (darabok.Length == 2)
                {
                    string megadottPin = darabok[1];

                    if (megadottPin == this.pinKod)
                    {
                        this.ZartE = false;
                        this.UtolsoFrissites = DateTime.Now;
                        nyitasokszama += 1;
                    }
                    else
                    {
                        Csipog(2);
                    }
                }
            }

            if (parancs == "ZARAS")
            {
                this.ZartE = true;
                this.UtolsoFrissites = DateTime.Now;
            }
        }


        public override string AllapotJelentes()
        {
            if (this.ZartE)
            {
                return "ZÁRVA";
            }
            else
            {
                return "NYITVA";

            }

        }

        protected override bool OnTesztFuttatasa()
        {

            return true;
        }

        public override void GyariBeallitasokVisszaallitasa()
        {
            base.GyariBeallitasokVisszaallitasa();
            this.ZartE = true;
            this.pinKod = "0000";



        }

      
        public void Csipog(int hosszu)
        {
            Console.WriteLine($"Csipog: {hosszu} percig");

        }

        public void VeszjelzesInditas()
        {
            rosszPin = true;
            Console.WriteLine("Vészjelzés");
        }

        public string StatisztikatKeszit()
        {
            return ($"Nyitások száma: {nyitasokszama}");
        }
    }
}
