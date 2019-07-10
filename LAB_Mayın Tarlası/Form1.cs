using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_Mayın_Tarlası
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        ArrayList pcbdizi = new ArrayList();       
        Random rnd = new Random();       
        private void Form1_Load(object sender, EventArgs e)
        {
            int[] mayin = new int[20];
            for (int i = 0; i < mayin.Length; i++)
            {
                int eleman = rnd.Next(1, 170);
                if (mayin.Contains(eleman))
                {
                    i--;
                }
                else
                {
                    mayin[i] = eleman;
                }  
            }
            for (int i = 0; i < 169; i++)
            {
                PictureBox pcb = new PictureBox();
                pcb.Width = 30;
                pcb.Height = 30;
                pcb.Margin = new Padding(1);
                if (mayin.Contains(i))
                {
                    pcb.Tag = true;
                }
                else pcb.Tag = false;

                flpGosterge.Controls.Add(pcb);               
                pcbdizi.Add(pcb);

                pcb.Click += pcb_click;                  
            }

            
            timer1.Start();
        }

        private void pcb_click(object sender, EventArgs e)
        {
            PictureBox tiklanan = sender as PictureBox;
            if ((bool)tiklanan.Tag == true)
            {
                foreach (Control item in flpGosterge.Controls)
                {
                    PictureBox pcb = item as PictureBox;
                    if ((bool)pcb.Tag == true)
                    {
                        timer1.Stop();
                        flpGosterge.Controls.Clear();
                        MessageBox.Show("Oyun Bitti");
                        Environment.Exit(0);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Control item in pcbdizi)
            {
                item.BackColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            }              
        }
        
    }
}
