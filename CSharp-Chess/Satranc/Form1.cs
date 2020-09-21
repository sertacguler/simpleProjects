using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Satranc
{
    public partial class Form1 : Form
    {
        Random rastgele = new Random();

        int[,] satranc = new int[8, 8];
        int iki_ileri;
        int bir_ileri;
        int[] konum = new int[2];
        int x, y;
        HorseImpl horse;

        String[,] tahta = new String[8, 8] { { "A8", "B8", "C8", "D8", "E8", "F8", "G8", "H8" } , { "A7", "B7", "C7", "D7", "E7", "F7", "G7", "H7" }
        ,{"A6","B6","C6","D6","E6","F6","G6","H6"} , { "A5", "B5", "C5", "D5", "E5", "F5", "G5", "H5" }
        ,{"A4", "B4", "C4", "D4", "F4", "F4", "G4", "H4"} , { "A3", "B3", "C3", "D3", "E3", "F3", "G3", "H3" }
        ,{"A2","B2","C2","D2","E2","F2","G2","H2"} , { "A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1" }};

        public Form1()
        {
            InitializeComponent();

            //tasin ilk konumu belirleniyor
            x = getRandomInteger(0, 8);
            y = getRandomInteger(0, 8);
            konum[0] = x;
            konum[1] = y;
            Console.WriteLine(x + " " + y);
            satranc[x,y] = 1;
            paintHorse(tahta[x, y]); // tasi ilk konumuna yerlestiriyor
            // !---------
            yazdir(satranc); // tahtanın ilk hali

        }

        // random sayi uretir
        public int getRandomInteger(int minimum, int maximum)
{
    return rastgele.Next(minimum,maximum);
}

        // satranc tahtasını yazdırır console da
        public void yazdir(int[,] satranc)
        {
            String dizi = "";
            for (int i = 0; i < 8; i++)
            {
                dizi = "";
                for (int x = 0; x < 8 ; x++)
                {
                    dizi += " " + satranc[i,x];
                }
                Console.WriteLine(dizi);
            }
        }

        // Tas in ilerlemeden onceki konuma kırmızı at resmi atanıyor
        public void paint(String tahta)
        {
            switch (tahta)
            {
                case "A8":
                    A8.Image = Properties.Resources.strategy;
                    break;
                case "A7":
                    A7.Image = Properties.Resources.strategy;
                    break;
                case "A6":
                    A6.Image = Properties.Resources.strategy;
                    break;
                case "A5":
                    A5.Image = Properties.Resources.strategy;
                    break;
                case "A4":
                    A4.Image = Properties.Resources.strategy;
                    break;
                case "A3":
                    A3.Image = Properties.Resources.strategy;
                    break;
                case "A2":
                    A2.Image = Properties.Resources.strategy;
                    break;
                case "A1":
                    A1.Image = Properties.Resources.strategy;
                    break;
                case "B8":
                    B8.Image = Properties.Resources.strategy;
                    break;
                case "B7":
                    B7.Image = Properties.Resources.strategy;
                    break;
                case "B6":
                    B6.Image = Properties.Resources.strategy;
                    break;
                case "B5":
                    B5.Image = Properties.Resources.strategy;
                    break;
                case "B4":
                    B4.Image = Properties.Resources.strategy;
                    break;
                case "B3":
                    B3.Image = Properties.Resources.strategy;
                    break;
                case "B2":
                    B2.Image = Properties.Resources.strategy;
                    break;
                case "B1":
                    B1.Image = Properties.Resources.strategy;
                    break;
                case "C8":
                    C8.Image = Properties.Resources.strategy;
                    break;
                case "C7":
                    C7.Image = Properties.Resources.strategy;
                    break;
                case "C6":
                    C6.Image = Properties.Resources.strategy;
                    break;
                case "C5":
                    C5.Image = Properties.Resources.strategy;
                    break;
                case "C4":
                    C4.Image = Properties.Resources.strategy;
                    break;
                case "C3":
                    C3.Image = Properties.Resources.strategy;
                    break;
                case "C2":
                    C2.Image = Properties.Resources.strategy;
                    break;
                case "C1":
                    C1.Image = Properties.Resources.strategy;
                    break;
                case "D8":
                    D8.Image = Properties.Resources.strategy;
                    break;
                case "D7":
                    D7.Image = Properties.Resources.strategy;
                    break;
                case "D6":
                    D6.Image = Properties.Resources.strategy;
                    break;
                case "D5":
                    D5.Image = Properties.Resources.strategy;
                    break;
                case "D4":
                    D4.Image = Properties.Resources.strategy;
                    break;
                case "D3":
                    D3.Image = Properties.Resources.strategy;
                    break;
                case "D2":
                    D2.Image = Properties.Resources.strategy;
                    break;
                case "D1":
                    D1.Image = Properties.Resources.strategy;
                    break;
                case "E8":
                    E8.Image = Properties.Resources.strategy;
                    break;
                case "E7":
                    E7.Image = Properties.Resources.strategy;
                    break;
                case "E6":
                    E6.Image = Properties.Resources.strategy;
                    break;
                case "E5":
                    E5.Image = Properties.Resources.strategy;
                    break;
                case "E4":
                    E4.Image = Properties.Resources.strategy;
                    break;
                case "E3":
                    E3.Image = Properties.Resources.strategy;
                    break;
                case "E2":
                    E2.Image = Properties.Resources.strategy;
                    break;
                case "E1":
                    E1.Image = Properties.Resources.strategy;
                    break;
                case "F8":
                    F8.Image = Properties.Resources.strategy;
                    break;
                case "F7":
                    F7.Image = Properties.Resources.strategy;
                    break;
                case "F6":
                    F6.Image = Properties.Resources.strategy;
                    break;
                case "F5":
                    F5.Image = Properties.Resources.strategy;
                    break;
                case "F4":
                    F4.Image = Properties.Resources.strategy;
                    break;
                case "F3":
                    F3.Image = Properties.Resources.strategy;
                    break;
                case "F2":
                    F2.Image = Properties.Resources.strategy;
                    break;
                case "F1":
                    F1.Image = Properties.Resources.strategy;
                    break;
                case "G8":
                    G8.Image = Properties.Resources.strategy;
                    break;
                case "G7":
                    G7.Image = Properties.Resources.strategy;
                    break;
                case "G6":
                    G6.Image = Properties.Resources.strategy;
                    break;
                case "G5":
                    G5.Image = Properties.Resources.strategy;
                    break;
                case "G4":
                    G4.Image = Properties.Resources.strategy;
                    break;
                case "G3":
                    G3.Image = Properties.Resources.strategy;
                    break;
                case "G2":
                    G2.Image = Properties.Resources.strategy;
                    break;
                case "G1":
                    G1.Image = Properties.Resources.strategy;
                    break;
                case "H8":
                    H8.Image = Properties.Resources.strategy;
                    break;
                case "H7":
                    H7.Image = Properties.Resources.strategy;
                    break;
                case "H6":
                    H6.Image = Properties.Resources.strategy;
                    break;
                case "H5":
                    H5.Image = Properties.Resources.strategy;
                    break;
                case "H4":
                    H4.Image = Properties.Resources.strategy;
                    break;
                case "H3":
                    H3.Image = Properties.Resources.strategy;
                    break;
                case "H2":
                    H2.Image = Properties.Resources.strategy;
                    break;
                case "H1":
                    H1.Image = Properties.Resources.strategy;
                    break;
            }
        }

        // Tas in ilerledigi konuma at resmi yerleştiriyor
        // parametre olarak tas in yeni konumu
        public void paintHorse(String tahta)
        {
            switch (tahta)
            {

                case "A8":
                    A8.Image = Properties.Resources.horse;
                    A8.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" A8");
                    break;
                case "A7":
                    A7.Image = Properties.Resources.horse;
                    A7.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" A7");
                    break;
                case "A6":
                    A6.Image = Properties.Resources.horse;
                    A6.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" A6");
                    break;
                case "A5":
                    A5.Image = Properties.Resources.horse;
                    A5.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("A5");
                    break;
                case "A4":
                    A4.Image = Properties.Resources.horse;
                    A4.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("A4");
                    break;
                case "A3":
                    A3.Image = Properties.Resources.horse;
                    A3.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("A3");
                    break;
                case "A2":
                    A2.Image = Properties.Resources.horse;
                    A2.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("A2");
                    break;
                case "A1":
                    A1.Image = Properties.Resources.horse;
                    A1.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("A1");
                    break;
                case "B8":
                    B8.Image = Properties.Resources.horse;
                    B8.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("B8");
                    break;
                case "B7":
                    B7.Image = Properties.Resources.horse;
                    B7.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" B7");
                    break;
                case "B6":
                    B6.Image = Properties.Resources.horse;
                    B6.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" B6");
                    break;
                case "B5":
                    B5.Image = Properties.Resources.horse;
                    B5.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" B5");
                    break;
                case "B4":
                    B4.Image = Properties.Resources.horse;
                    B4.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" B4");
                    break;
                case "B3":
                    B3.Image = Properties.Resources.horse;
                    B3.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" B3");
                    break;
                case "B2":
                    B2.Image = Properties.Resources.horse;
                    B2.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" B2");
                    break;
                case "B1":
                    B1.Image = Properties.Resources.horse;
                    B1.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" B1");
                    break;

                case "C8":
                    C8.Image = Properties.Resources.horse;
                    C8.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" C8");
                    break;
                case "C7":
                    C7.Image = Properties.Resources.horse;
                    C7.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" C7");
                    break;
                case "C6":
                    C6.Image = Properties.Resources.horse;
                    C6.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" C6");
                    break;
                case "C5":
                    C5.Image = Properties.Resources.horse;
                    C5.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" C5");
                    break;
                case "C4":
                    C4.Image = Properties.Resources.horse;
                    C4.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" C4");
                    break;
                case "C3":
                    C3.Image = Properties.Resources.horse;
                    C3.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" C3");
                    break;
                case "C2":
                    C2.Image = Properties.Resources.horse;
                    C2.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" C2");
                    break;
                case "C1":
                    C1.Image = Properties.Resources.horse;
                    C1.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" C1");
                    break;

                case "D8":
                    D8.Image = Properties.Resources.horse;
                    D8.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" D8");
                    break;
                case "D7":
                    D7.Image = Properties.Resources.horse;
                    D7.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" D7");
                    break;
                case "D6":
                    D6.Image = Properties.Resources.horse;
                    D6.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" D6");
                    break;
                case "D5":
                    D5.Image = Properties.Resources.horse;
                    D5.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("D5");
                    break;
                case "D4":
                    D4.Image = Properties.Resources.horse;
                    D4.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("D4");
                    break;
                case "D3":
                    D3.Image = Properties.Resources.horse;
                    D3.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("D3");
                    break;
                case "D2":
                    D2.Image = Properties.Resources.horse;
                    D2.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("D2");
                    break;
                case "D1":
                    D1.Image = Properties.Resources.horse;
                    D1.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("D1");
                    break;

                case "E8":
                    E8.Image = Properties.Resources.horse;
                    E8.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("E8");
                    break;
                case "E7":
                    E7.Image = Properties.Resources.horse;
                    E7.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("E7");
                    break;
                case "E6":
                    E6.Image = Properties.Resources.horse;
                    E6.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("E6");
                    break;
                case "E5":
                    E5.Image = Properties.Resources.horse;
                    E5.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("E5");
                    break;
                case "E4":
                    E4.Image = Properties.Resources.horse;
                    E4.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("E4");
                    break;
                case "E3":
                    E3.Image = Properties.Resources.horse;
                    E3.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("E3");
                    break;
                case "E2":
                    E2.Image = Properties.Resources.horse;
                    E2.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add(" E2");
                    break;
                case "E1":
                    E1.Image = Properties.Resources.horse;
                    E1.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("E1");
                    break;
                case "F8":
                    F8.Image = Properties.Resources.horse;
                    F8.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("F8");
                    break;
                case "F7":
                    F7.Image = Properties.Resources.horse;
                    F7.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("F7");
                    break;
                case "F6":
                    F6.Image = Properties.Resources.horse;
                    F6.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("F6");
                    break;
                case "F5":
                    F5.Image = Properties.Resources.horse;
                    F5.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("F5");
                    break;
                case "F4":
                    F4.Image = Properties.Resources.horse;
                    F4.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("F4");
                    break;
                case "F3":
                    F3.Image = Properties.Resources.horse;
                    F3.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("F3");
                    break;
                case "F2":
                    F2.Image = Properties.Resources.horse;
                    F2.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("F2");
                    break;
                case "F1":
                    F1.Image = Properties.Resources.horse;
                    F1.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("F1");
                    break;

                case "G8":
                    G8.Image = Properties.Resources.horse;
                    G8.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("G8");
                    break;
                case "G7":
                    G7.Image = Properties.Resources.horse;
                    G7.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("G7");
                    break;
                case "G6":
                    G6.Image = Properties.Resources.horse;
                    G6.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("G6");
                    break;
                case "G5":
                    G5.Image = Properties.Resources.horse;
                    G5.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("G5");
                    break;
                case "G4":
                    G4.Image = Properties.Resources.horse;
                    G4.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("G4");
                    break;
                case "G3":
                    G3.Image = Properties.Resources.horse;
                    G3.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("G3");
                    break;
                case "G2":
                    G2.Image = Properties.Resources.horse;
                    G2.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("G2");
                    break;
                case "G1":
                    G1.Image = Properties.Resources.horse;
                    G1.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("G1");
                    break;
                case "H8":
                    H8.Image = Properties.Resources.horse;
                    H8.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("H8");
                    break;
                case "H7":
                    H7.Image = Properties.Resources.horse;
                    H7.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("H7");
                    break;
                case "H6":
                    H6.Image = Properties.Resources.horse;
                    H6.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("H6");
                    break;
                case "H5":
                    H5.Image = Properties.Resources.horse;
                    H5.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("H5");
                    break;
                case "H4":
                    H4.Image = Properties.Resources.horse;
                    H4.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("H4");
                    break;
                case "H3":
                    H3.Image = Properties.Resources.horse;
                    H3.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("H3");
                    break;
                case "H2":
                    H2.Image = Properties.Resources.horse;
                    H2.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("H2");
                    break;
                case "H1":
                    H1.Image = Properties.Resources.horse;
                    H1.SizeMode = PictureBoxSizeMode.StretchImage;
                    listBox1.Items.Add("H1");
                    break;


            }
        }
        
        //bos
        private void PictureBox2_Click(object sender, EventArgs e)
        {}

        // Timer i baslatir ve durdurur
        private void Button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
                label1.Text = listBox1.Items.Count.ToString();
                listBox1.Items.Add(listBox1.Items.Count.ToString());
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // tas in gitmesi gerek yon parametrelerini random olarak uretiyor.
            iki_ileri = getRandomInteger(0, 4);
            Console.WriteLine(iki_ileri);
            if (iki_ileri == 0 || iki_ileri == 1)
            {
                bir_ileri = getRandomInteger(2, 4);
                Console.WriteLine(bir_ileri);
            }
            else
            {
                bir_ileri = getRandomInteger(0, 2);
                Console.WriteLine(bir_ileri);
            }
            // !---------
            konum[0] = x;
            konum[1] = y;
            horse = new HorseImpl(konum, iki_ileri, bir_ileri);

            if (konum[0] <= 7 && konum[1] <= 7 && konum[1] >= 0 && konum[0] >= 0 && satranc[konum[0], konum[1]] != 9)
            {
                satranc[x, y] = 9;
                satranc[konum[0], konum[1]] = 1;
                Console.WriteLine(tahta[konum[0], konum[1]]);
                paintHorse(tahta[konum[0], konum[1]]);
                paint(tahta[x, y]);
                x = konum[0];
                y = konum[1];
            }

            yazdir(satranc);
            Console.WriteLine("---------------------------");
        }

    }
}
