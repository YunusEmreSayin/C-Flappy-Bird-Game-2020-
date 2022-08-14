using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappybird
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //vars
        int deger = 0; int sec = 0;int puan = 0; int boyutsec = 0;
        Random rnd = new Random();
        bool engelvar = false;

        //events
        private void timer1_Tick(object sender, EventArgs e)
        {
            kus.Top = kus.Top + deger;
            if (engelvar == false)
            {
                engelyokfunc();
            }
            if (engelvar == true)
            {
                engelvarfunc();
            }
            if (kus.Bounds.IntersectsWith(altengel.Bounds) || kus.Bounds.IntersectsWith(ustengel.Bounds) || kus.Location.Y <= 1 || kus.Location.Y >= 428)
            {
                temas();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) deger = -5;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) deger = 5;
        }
        //funcs
        private void timer2_Tick(object sender, EventArgs e)
        {
            //this.BackgroundImage = pictureBox1.Image;
            //MessageBox.Show("OYUN BİTTİ " + "PUAN: " + puan);
            //this.Close();
        }
        public void temas()
        {
            timer1.Enabled = false;
            // timer2.Enabled = true;
            kus.Visible = false;
            altengel.Visible = false;
            ustengel.Visible = false;
            this.BackgroundImage = pictureBox1.Image;
            MessageBox.Show("PUAN: " + puan);
            this.Close();
        }
        public void engelvarfunc()
        {
            if (sec == 1)
            {
                ustengel.Left = ustengel.Left - 5;
            }
            if (sec == 2)
            {
                altengel.Left = altengel.Left - 5;
            }
            if ((ustengel.Left < -100) || (altengel.Left < -100))
            {
                puan++;
                lblpuan.Text = puan.ToString();
                engelvar = false;
                altengel.Left = 700;
                ustengel.Left = 700;
                ustengel.Visible = false;
                altengel.Visible = false;
            }
        }
        public void engelyokfunc()
        {
            engelvar = true;
            sec = rnd.Next(1, 3);
            if (sec == 1)
            {
                ustengel.Visible = true;
                boyutsec = rnd.Next(1, 4);
                if (boyutsec == 1) ustengel.Size = new Size(66, 130);
                else if (boyutsec == 2) ustengel.Size = new Size(66, 160);
                else if (boyutsec == 3) ustengel.Size = new Size(66, 190);
            }
            if (sec == 2)
            {
                altengel.Visible = true;
                boyutsec = rnd.Next(1, 4);
                if (boyutsec == 1) altengel.Size = new Size(66, 130);
                else if (boyutsec == 2) altengel.Size = new Size(66, 160);
                else if (boyutsec == 3) altengel.Size = new Size(66, 190);
            }
        }
    }
}
