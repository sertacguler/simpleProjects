using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satranc
{
    interface Tas
    {
        // satranc oyununda her tasi kapsayan hareket ozellikleri
        int[] yukari(int[] konum, int a);

        int[] asagi(int[] konum, int a);

        int[] sol(int[] konum, int a);

        int[] sag(int[] konum, int a);
    }

}
