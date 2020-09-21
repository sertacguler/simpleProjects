using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Net;

namespace client
{
    public partial class Form1 : Form
    {
        Thread t;
        TcpClient bagkur;
        NetworkStream ag;
        StreamReader read;
        StreamWriter write;
        IPAddress ipadres;
        public delegate void ricdegis(string text);

        public Form1()
        {
            InitializeComponent();
        }

        public void okumayabasla()
        {
            ag = bagkur.GetStream();
            read = new StreamReader(ag);
            while (true)
            {
                try
                {
                    string yazi = read.ReadLine();
                    ekranabas(yazi);
                }
                catch
                {
                    return;
                }
            }
        }

        public void ekranabas(string ad)
        {
            if (this.InvokeRequired)
            {
                ricdegis degis = new ricdegis(ekranabas);
                this.Invoke(degis, ad);
            }
            else
            {
                richTextBox1.SelectionColor = Color.Green;
               // s = "Arkadaş: " + s;
                richTextBox1.AppendText(Environment.NewLine + "Arkadaş : " + ad);
            }
        }

        public void baglanti_kur()
        {
            try
            {
                bagkur = new TcpClient(textBox3.Text, Convert.ToInt16(textBox1.Text));
                t = new Thread(new ThreadStart(okumayabasla));
                t.Start();
                richTextBox1.SelectionColor = Color.Red;
                richTextBox1.AppendText(Environment.NewLine + DateTime.Now.ToString() + " Bağlandı");
                textBox2.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Server ile baglanti kurulurken hata olustu !");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti_kur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                return;
            }
            else
            {
                write = new StreamWriter(ag);
                write.WriteLine(textBox2.Text);
                write.Flush();
                richTextBox1.SelectionColor = Color.Blue;
                richTextBox1.AppendText(Environment.NewLine + "Ben : " + textBox2.Text);
                textBox2.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bagkur.Client.Close();
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.AppendText(Environment.NewLine + " Bağlantı kapatıldı" );
            textBox2.Visible=false;
        }
    }
}
