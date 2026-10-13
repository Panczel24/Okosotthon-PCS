using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Okosotthon
{
    public class Termosztat : OkosEszkoz, IIdozitheto, IStatisztika
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

        //ezt ai csinálta mivel valamiért nem akart lefurni a teszt, és azt írta hogy a 24.5 miatt, mert 24,5 lenne? és elküldte higy írjam így át és így működik a két teszt
        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs.StartsWith("BEALLIT_HOMERSEKLET:"))
            {
                string[] darabok = parancs.Split(':');

                if (darabok.Length == 2)
                {
                    double homerseklet;

                    if (double.TryParse(
                        darabok[1],
                        NumberStyles.Any,
                        CultureInfo.InvariantCulture,
                        out homerseklet))
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

        private int maradtIdo;
        public void IdozitestBeallit(int perc)
        {

            maradtIdo = perc;
        }

        public int GetMaradtIdo()
        {
            return maradtIdo;
        }

        public string StatisztikatKeszit()
        {
            return ($"A termosztat idozitoje: {maradtIdo} perc.");
        }
    }
}
