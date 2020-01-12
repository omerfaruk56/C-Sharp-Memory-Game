using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cSharp_ResimEslemeOyunu
{
    public partial class FormBilgiler : Form
    {
        public FormBilgiler()
        {
            InitializeComponent();
        }

        string etiket;
        ArrayList acilanKilitler = new ArrayList();
        DosyaCRUD d;

        private void FormBilgiler_Load(object sender, EventArgs e)
        {
            pnlicerik.Visible = false;
            kilitleriAc();
        }

        private void kilitleriAc()
        {
            switch (FormOyun.seviyeSayaci)
            {
                case 2:
                    for (int i = 1; i < 7; i++)
                        acilanKilitler.Add(i.ToString());
                    break;
                case 3:
                    for (int i = 1; i < 13; i++)
                        acilanKilitler.Add(i.ToString());
                    break;
                case 4:
                    for (int i = 1; i < 19; i++)
                        acilanKilitler.Add(i.ToString());
                    break;
                default:
                    break;
            }

            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    Button btn = (Button)item;
                    if (acilanKilitler.IndexOf(btn.Tag.ToString()) != -1)
                    {
                        btn.BackgroundImage = Image.FromFile((string)btn.Tag + ".png");
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        continue;
                    }
                    btn.BackgroundImage = Image.FromFile("19.png");
                    btn.Enabled = false;
                }
            }
        }

        private void pictGeriDon_Click(object sender, EventArgs e)
        {
            FormAnaMenu anaMenu = new FormAnaMenu();
            anaMenu.Show();
            this.Hide();
        }

        private void btnBilgilendirmeKapat_Click(object sender, EventArgs e)
        {
            pnlicerik.Visible = false;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            pnlicerik.Visible = true;
            richTxtBaslik.Font = new Font("Comic Sans MS", 30);

            if (sender is Button)
            {
                Button btn = (Button)sender;
                etiket = btn.Tag.ToString();
            }

            switch (etiket)
            {
                case "1":
                    d = new DosyaCRUD("1", "1");
                    richTxtBaslik.Text = "FARE";
                    break;
                case "2":
                    d = new DosyaCRUD("2", "2");
                    richTxtBaslik.Text = "KAPLUMBAĞA";
                    break;
                case "3":
                    d = new DosyaCRUD("3", "3");
                    richTxtBaslik.Text = "TAVUK";
                    break;
                case "4":
                    d = new DosyaCRUD("4", "4");
                    richTxtBaslik.Text = "YENGEÇ";
                    break;
                case "5":
                    d = new DosyaCRUD("5", "5");
                    richTxtBaslik.Text = "YUNUS BALIĞI";
                    richTxtBaslik.Font = new Font("Comic Sans MS", 24);
                    break;
                case "6":
                    d = new DosyaCRUD("6", "6");
                    richTxtBaslik.Text = "EŞEK";
                    break;
                case "7":
                    d = new DosyaCRUD("7", "7");
                    richTxtBaslik.Text = "KOYUN";
                    break;
                case "8":
                    d = new DosyaCRUD("8", "8");
                    richTxtBaslik.Text = "İNEK";
                    break;
                case "9":
                    d = new DosyaCRUD("9", "9");
                    richTxtBaslik.Text = "AHTAPOT";
                    break;
                case "10":
                    d = new DosyaCRUD("10", "10");
                    richTxtBaslik.Text = "ISTAKOZ";
                    break;
                case "11":
                    d = new DosyaCRUD("11", "11");
                    richTxtBaslik.Text = "SİNCAP";
                    break;
                case "12":
                    d = new DosyaCRUD("12", "12");
                    richTxtBaslik.Text = "KÖPEKBALIĞI";
                    break;
                case "13":
                    d = new DosyaCRUD("13", "13");
                    richTxtBaslik.Text = "KALAMAR";
                    break;
                case "14":
                    d = new DosyaCRUD("14", "14");
                    richTxtBaslik.Text = "BULDOG";
                    break;
                case "15":
                    d = new DosyaCRUD("15", "15");
                    richTxtBaslik.Text = "HAMSTER";
                    break;
                case "16":
                    d = new DosyaCRUD("16", "16");
                    richTxtBaslik.Text = "KURBAĞA";
                    break;
                case "17":
                    d = new DosyaCRUD("17", "17");
                    richTxtBaslik.Text = "AT";
                    break;
                case "18":
                    d = new DosyaCRUD("18", "18");
                    richTxtBaslik.Text = "PAPAĞAN";
                    break;
                default:
                    break;
            }

            richTxtIcerik.Text = d.dosyaOku();
            pictureHayvanlar.Image = Image.FromFile(d.resimOku());

        }
    }
}