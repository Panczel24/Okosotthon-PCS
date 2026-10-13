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

        public void OsszesVeszjelzesInditasa()
        {
            foreach (OkosEszkoz eszkoz in eszkozok)
            {
                if (eszkoz is IHangjezlo h)
                {
                    h.VeszjelzesInditas();
                }
            }
        }

        public void OsszesStatisztika()
        {
            foreach (OkosEszkoz eszkoz in eszkozok)
            {
                if (eszkoz is IStatisztika s)
                {
                    Console.WriteLine(s.StatisztikatKeszit());
                }
            }
        }

        public void OsszesIdozitoBeallit(int perc)
        {
            foreach (OkosEszkoz eszkoz in eszkozok)
            {
                if (eszkoz is IIdozitheto i)
                {
                    i.IdozitestBeallit(perc);
                }
            }
        }



    }
}
