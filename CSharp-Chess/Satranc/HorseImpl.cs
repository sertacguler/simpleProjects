using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satranc
{
    class HorseImpl : Tas
    {

        // tas in konumu
        private int[] konum;
        // tas in karekteristik hareketi
        private int iki_ileri;
        private int bir_ileri;

        public HorseImpl(int[] konum, int iki_ileri, int bir_ileri)
        {
            this.konum = konum;
            this.iki_ileri = iki_ileri;
            this.bir_ileri = bir_ileri;

            ikiileri(konum, iki_ileri);
            birileri(konum, bir_ileri);
        }

        // iki ileri hareketi methodu
        // parametreler taşın ilk konumu ve gidecegi yonu
        // method da yon e gore cagiralacak method belirleniyor
        private void ikiileri(int[] konum, int yon)
        {
            if (yon == 0)
            {
                konum = yukari(konum, 2);
            }
            else if (yon == 1)
            {
                konum = asagi(konum, 2);
            }
            else if (yon == 2)
            {
                konum = sol(konum, 2);
            }
            else if (yon == 3)
            {
                konum = sag(konum, 2);
            }
        }

        // bir ileri hareketi methodu
        // parametreler taşın ilk konumu ve gidecegi yonu
        // method da yon e gore cağıralacak methood belirleniyor
        private void birileri(int[] konum, int yon)
        {
            if (yon == 0)
            {
                konum = yukari(konum, 1);
            }
            else if (yon == 1)
            {
                konum = asagi(konum, 1);
            }
            else if (yon == 2)
            {
                konum = sol(konum, 1);
            }
            else if (yon == 3)
            {
                konum = sag(konum, 1);
            }
        }

        // tas ın hareketleri
        // parametreler taşın konumu ve gidecegi kare sayısı
       
    public int[] yukari(int[] k, int a)
        {
            k[0] -= a;
            return k;
        }

    public int[] asagi(int[] k, int a)
        {
            k[0] += a;
            return k;
        }

    public int[] sol(int[] k, int a)
        {
            k[1] -= a;
            return k;
        }

    public int[] sag(int[] k, int a)
        {
            k[1] += a;
            return k;
        }

        // getter setter methodları
        public int[] getKonum()
        {
            return konum;
        }

        public void setKonum(int[] konum)
        {
            this.konum = konum;
        }

        public int getIki_ileri()
        {
            return iki_ileri;
        }

        public void setIki_ileri(int iki_ileri)
        {
            this.iki_ileri = iki_ileri;
        }

        public int getBir_ileri()
        {
            return bir_ileri;
        }

        public void setBir_ileri(int bir_ileri)
        {
            this.bir_ileri = bir_ileri;
        }

    }

}
