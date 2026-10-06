using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosotthonKozpont
    {
        private readonly List<OkosEszkoz> eszkozok;
        public OkosotthonKozpont()
        {
            this.eszkozok = new List<OkosEszkoz>();
        }



        public void EszkozHozzaadasa(OkosEszkoz eszkoz)
        {
            this.eszkozok.Add(eszkoz);
        }


        public void OsszesCsatlakoztatasa()
        {
            for (int i = 0; i < this.eszkozok.Count; i++)
            {
                this.eszkozok[i].Csatlakozas();
            }
        }

        public int RendszerDiagnosztikaFuttatasa()
        {
            int sikeresTeszt = 0;

            for (int i = 0; i < this.eszkozok.Count; i++)
            {
                bool eredmeny = this.eszkozok[i].DiagnosztikaFuttatasa();

                if (eredmeny)
                {
                    sikeresTeszt++;
                }
            }

            return sikeresTeszt;
        }

    }
}
