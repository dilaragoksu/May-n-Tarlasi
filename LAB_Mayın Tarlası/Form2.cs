using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        
        private void Form2_Load(object sender, EventArgs e)
        {
            tekrar:
            List<int> MayinIndexler = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                int MayinIndex = rnd.Next(1, 170);
                if (!MayinIndexler.Contains(MayinIndex))
                {
                    MayinIndexler.Add(MayinIndex);
                }
                else i--;
            }
            for (int i = 0; i < 169; i++)
            {
                PictureBox pcb = new PictureBox();
                pcb.Name = "RenkliKutu"+i;
                pcb.Width = 30;
                pcb.Height = 30;
                //pcb.Size = new System.Drawing.Size(30, 30);(yukarıdakiler ile aynı işi yapıyor.)
                pcb.Margin = new Padding(1);//dış kenarlıklar
                pcb.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                //i'nin o anki değeri MayinlarIndex dizisinde yer alıyorsa mayın olarak işaretleyebiliriz.
                if (MayinIndexler.Contains(i))pcb.Tag = true;//tag bütün veri tiplerinde değer alabilir.
                else pcb.Tag = false;
                pcb.Click += Pcb_Click;
                flpRenkliKutular.Controls.Add(pcb);
            }
            timer1.Start();
        }

        private void Pcb_Click(object sender, EventArgs e)
        {
            //sender o an tıkladığımızda picturebox'ın tüm değerlerinin bize teslim eder
            PictureBox YakalananKutu = (PictureBox)sender;
            Color KutununRengi = YakalananKutu.BackColor;
            if ((bool)YakalananKutu.Tag)
            {
                timer1.Stop();
                //yakalanan kutunun rengiyle tüm kutuları boyayalım.
                foreach (var item in flpRenkliKutular.Controls)
                {
                    ((PictureBox)item).BackColor = KutununRengi;
                }
                DialogResult secim= MessageBox.Show("Mayına bastınız.Yeniden oynamak istiyor musunuz?","Game Over!!!",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if (secim == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else Environment.Exit(0) ;
            }
            else MessageBox.Show("Yanlış, bilemedin.");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var kutu in flpRenkliKutular.Controls)
            {
                ((PictureBox)kutu).BackColor= Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));         
            }
        }
    }
}
