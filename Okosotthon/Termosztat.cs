using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class Termosztat : OkosEszkoz
    {
        double jelenlegiHomerseklet;
        double celHomerseklet;

        public double JelenlegiHomerseklet { get => jelenlegiHomerseklet; set => jelenlegiHomerseklet = value; }
        public double CelHomerseklet { get => celHomerseklet; set => celHomerseklet = value; }

        public Termosztat(string azonosito, string nev, double celHomerseklet)
        : base(azonosito, nev)
        {
            this.CelHomerseklet = celHomerseklet;
            this.JelenlegiHomerseklet = 21.0; 
        }

        public override void ParancsVegrehajtasa(string parancs)
        {

            if (parancs.StartsWith("BEALLIT_HOMERSEKLET:"))
            {
                string[] darabok = parancs.Split(':');

                if (darabok.Length == 2)
                {
                    double homerseklet;

                    if (double.TryParse(darabok[1], out homerseklet))
                    {
                        this.CelHomerseklet = homerseklet;
                        this.UtolsoFrissites = DateTime.Now;
                    }
                }
            }


        }

        public override string AllapotJelentes()
        {

            return ($"A célhőmérséklet: {this.CelHomerseklet}, a a jelenlegi hőmérséklet: {this.JelenlegiHomerseklet}");
        }

        protected override bool OnTesztFuttatasa()
        {
            if (this.CelHomerseklet >= 5.0 && this.CelHomerseklet <= 35.0)
            {
                return true;
            }
            else
            {
                return false;

            }

        }

    }
}
