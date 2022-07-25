using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minefield
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region Tanımlamalar
        int mayın1 = 0;
        int mayın2 = 0;
        int mayın3 = 0;
        int mayın4 = 0;
        int mayın5 = 0;
        int skor = 0;
        int mayınsayısı = 5;
        Random rnd = new Random();
        #endregion
        private void btnBaslat_Click(object sender, EventArgs e)
        {
            #region Mayınları Random Atama
            mayın1 = rnd.Next(0, 71);
            mayın2 = rnd.Next(0, 71);
            mayın3 = rnd.Next(0, 71);
            mayın4 = rnd.Next(0, 71);
            mayın5 = rnd.Next(0, 71);
            #endregion

            #region Buton Oluşturma
            for (int i = 1; i < 71; i++)
            {
                Button buton = new Button();
                buton.Name = "btn" + i.ToString();
                buton.Size = new System.Drawing.Size(35, 35);
                buton.Text = "*";
                if (mayın1==i || mayın2==i ||mayın3==i || mayın4==i || mayın5==i)
                {
                    buton.Tag = true;   
                }
                else
                {
                    buton.Tag = false;
                }
                buton.Click += buton_Click;
                buton.UseVisualStyleBackColor = true;
                flowLayoutPanel1.Controls.Add(buton);
            }
            #endregion
        }

        private void buton_Click(object sender, EventArgs e)
        {

            Button basilanButon = ((Button)sender);
            bool BulunanMayın = (bool)basilanButon.Tag;
            #region Mayın Bulunduğu Zaman
            if (BulunanMayın)
            {
                basilanButon.BackColor = Color.Red;
                mayınsayısı--;
                lblMayınSayı.Text = "Kalan Mayın: " + mayınsayısı;
                basilanButon.Enabled = false;
                #region Mayın Bittiği Zaman
                if (mayınsayısı==0)
                {
                    DialogResult result= MessageBox.Show("Bütün Mayınları Buldunuz" +
                    "\nTekrar Oynamak İster Misiniz?", "Bilgilendirme"
                    ,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (result==DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                    else if(result==DialogResult.No)
                    {
                        Application.ExitThread();
                    }
                    
                }
                #endregion
            }
            else
            {
                basilanButon.BackColor = Color.Green;
                skor += 2;
                lblSkor.Text = "Skorunuz: " + skor;
                basilanButon.Enabled = false;
            }
            #endregion
        }
    }
}
