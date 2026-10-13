using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okosotthon
{
    public class OkosKozpontiRiaszto : OkosEszkoz, IIdozitheto, IHangjezlo, IStatisztika
    {
        private int maradtIdo;
        private bool veszjelzesAktiv = false;
        private int csipogasokSzama = 0;
        public OkosKozpontiRiaszto(string azonosito, string nev) : base(azonosito, nev)
        {
        }

        public void Csipog(int hosszu)
        {
            csipogasokSzama += 1;
            Console.WriteLine($"Csipog {hosszu} percig");
        }

        public int GetMaradtIdo()
        {
            return maradtIdo;
        }

        public void IdozitestBeallit(int perc)
        {
            maradtIdo = perc;

        }


        public string StatisztikatKeszit()
        {
            return ($"Hátralévő iso: {maradtIdo} perc, csipogások: {csipogasokSzama}, {veszjelzesAktiv} ");
        }

        public void VeszjelzesInditas()
        {
            veszjelzesAktiv = true;
            Console.WriteLine("KOZPONTI VESZJELZES!");
        }

        public override string AllapotJelentes()
        {
            if (veszjelzesAktiv)
            {
                return "VÉSZJELZÉS AKTÍV";
            }
            else
            {
                return "A riasztó rendben működik";
            }
        }

        protected override bool OnTesztFuttatasa()
        {
            return true;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            throw new NotImplementedException();
        }
    }
}
