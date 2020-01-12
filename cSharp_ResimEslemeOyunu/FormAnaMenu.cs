using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cSharp_ResimEslemeOyunu
{
    public partial class FormAnaMenu : Form
    {
        public FormAnaMenu()
        {
            InitializeComponent();
        }

        public static string seviye;

        void oyunuAc()
        {
            this.Hide();
            FormOyun oyun = new FormOyun();
            FormOyun.seviyeSayaci = 1;
            oyun.Show();

        }

        private void btn_Kolay_Click(object sender, EventArgs e)
        {
            seviye = "KOLAY";
            oyunuAc();
        }

        private void btn_Orta_Click(object sender, EventArgs e)
        {
            seviye = "ORTA";
            oyunuAc();
        }

        private void btn_Zor_Click(object sender, EventArgs e)
        {
            seviye = "ZOR";
            oyunuAc();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Hayvanlar Hafıza Oyunu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Environment.Exit(0);
        }

        private void btnHayvanlarAlemi_Click(object sender, EventArgs e)
        {
            FormBilgiler hayvanlarAlemi = new FormBilgiler();
            hayvanlarAlemi.Show();
            this.Hide();
        }

        private void FormAnaMenu_Load(object sender, EventArgs e)
        {

        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Animasyon.butonUstuneGelinceRenkDegistir(sender, Color.ForestGreen);

        }

        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            Animasyon.butondanAyrilincaRenkDegisyir(sender, Color.DarkRed);

        }
    }
}
