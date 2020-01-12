using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Collections;

namespace cSharp_ResimEslemeOyunu
{
    public partial class FormOyun : Form
    {
        public FormOyun()
        {
            InitializeComponent();
        }

        string buton1Tag = "x";
        string buton2Tag = "y";
        string buton1Name;
        string buton2Name;
        int butonSayaci = 0;
        public static int seviyeSayaci = 1;
        int rastgeleSayi;
        int oyunSuresi = 0;
        int tiklamaSayisi = 0;
        int[] rastgeleSayilar = new int[12];
        ArrayList bilinenHayvanlar = new ArrayList();
        int[] hayvanlar = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 };
        int[] hayvanlar2 = { 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12 };
        int[] hayvanlar3 = { 13, 13, 14, 14, 15, 15, 16, 16, 17, 17, 18, 18 };

        private void FormOyun_Load(object sender, EventArgs e)
        {
            zorlukSeviyesi();
            oyunuBaslat(1);
        }

        private void oyunuBaslat(int kacinciSeviye)
        {
            Random rnd = new Random();

            for (int i = 0; i < 11; i++)
            {
                rastgeleSayi = rnd.Next(1, 12);
                while (Array.IndexOf(rastgeleSayilar, rastgeleSayi) != -1)
                    rastgeleSayi = rnd.Next(1, 12);
                rastgeleSayilar[i] = rastgeleSayi;
            }

            int j = 0;//Hayvanları kutulara rastgele aktarıyor.
            foreach (Control bilesen in this.Controls)
            {
                if (bilesen is Button)
                {
                    Button btn = (Button)bilesen;
                    btn.Tag = seviye(kacinciSeviye)[rastgeleSayilar[j]] + ".png";
                    j++;
                }
            }
        }

        private void yeniOyun()
        {
            buton1Tag = "x";//sıfırlama işlemi
            buton2Tag = "y";
            butonSayaci = 0;
            bilinenHayvanlar.Clear();
            Array.Clear(rastgeleSayilar, 0, rastgeleSayilar.Length);

            foreach (Control bilesen in this.Controls)
            {
                if (bilesen is Button)
                {
                    Button btn = (Button)bilesen;
                    btn.BackgroundImage = Image.FromFile("0.png");
                }
            }
        }

        private void oyunBittiMi()
        {
            
            if (bilinenHayvanlar.Count == 12)
            {
                seviyeSayaci++;

                if (seviyeSayaci > 3)
                {
                    Animasyon.sesEfekti("alkis.wav");
                    tmrOyunSuresi.Stop();
                    MessageBox.Show("Oyun Bitti.");
                    yeniOyun();
                    butonlarAktifMi(false);               
                    FormAnaMenu anaForm = new FormAnaMenu();
                    anaForm.Show();
                    this.Close();
                    return;
                }

                Animasyon.sesEfekti("alkis.wav");
                tmrOyunSuresi.Enabled = false;
                MessageBox.Show("! SEVİYE " + seviyeSayaci + " !");
                lblSeviye.Text = seviyeSayaci + "/3";
                yeniOyun();
                zorlukSeviyesi();
                lblTiklamaSayisi.Text = tiklamaSayisi.ToString();

                if (seviyeSayaci == 2)
                    oyunuBaslat(2);
                else if (seviyeSayaci == 3)
                    oyunuBaslat(3);

            }
        }

        private void kaybettiniz()
        {
            tmrOyunSuresi.Enabled = false;
            butonlarAktifMi(false);
            yeniOyun();
            Animasyon.sesEfekti("sasirma.wav");
            MessageBox.Show("Kaybettiniz :/ ");
            FormAnaMenu anaMenu = new FormAnaMenu();
            anaMenu.Show();
            this.Close();
        }

        private int[] seviye(int kacinciSeviye)
        {
            if (kacinciSeviye == 1)
                return hayvanlar;
            else if (kacinciSeviye == 2)
                return hayvanlar2;
            else if (kacinciSeviye == 3)
                return hayvanlar3;
            else
                return hayvanlar;
        }

        private void zorlukSeviyesi()
        {
            switch (FormAnaMenu.seviye)
            {
                case "KOLAY":
                    oyunSuresi = 61;
                    tiklamaSayisi = 36;
                    break;
                case "ORTA":
                    oyunSuresi = 51;
                    tiklamaSayisi = 31;
                    break;
                case "ZOR":
                    oyunSuresi = 41;
                    tiklamaSayisi = 26;
                    break;
                default:
                    break;
            }
        }

        private void butonlariTersCevir()
        {
            tmrButonlariAc.Enabled = false;
            buton1Tag = "x";
            buton2Tag = "y";
            butonSayaci = 0;

            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    Button btn = (Button)item;
                    if (bilinenHayvanlar.IndexOf(btn.Tag) != -1)//doğru bilinen hayvanları ters çevirme!
                        continue;
                    btn.BackgroundImage = Image.FromFile("0.png");
                }
            }
        }

        public void butonlarAktifMi(Boolean durum)
        {
            foreach (Control bilesen in this.Controls)
            {
                if (bilesen is Button)
                {
                    Button btn = (Button)bilesen;
                    btn.Enabled = durum;
                }
            }
        }

        private void geriSayim()
        {
            if (seviyeSayaci == 4 && tiklamaSayisi != 0 && oyunSuresi != 0)
            {
                tmrOyunSuresi.Enabled = false;
                return;
            }
            if (tiklamaSayisi == 0)
                oyunSuresi = 0;

            if (oyunSuresi == 0)
                kaybettiniz();

            oyunSuresi -= 1;
            lblOyunSuresi.Text = oyunSuresi.ToString();
        }

        private void fotografEslesmeKontrol(string butonTag, string butonName)
        {
            if (butonSayaci == 2)
                butonlariTersCevir();

            butonSayaci++;

            if (butonSayaci == 1)
            {
                buton1Tag = butonTag;
                buton1Name = butonName;
                
            }
            else if (butonSayaci == 2)
            {
                buton2Tag = butonTag;
                buton2Name = butonName;
                butonlarAktifMi(false);
                tmrButonlariAc.Enabled = true;

            }

            if (buton1Name == buton2Name)
                return;

            if (buton1Tag == buton2Tag)
            {
                bilinenHayvanlar.Add(buton1Tag);
                bilinenHayvanlar.Add(buton2Tag);
            }

        }

        //------------------------EVENTS------------------------------//

        private void button_Click(object sender, EventArgs e)
        {
            if (sender is Button)//tüm butonlar bu event ile kontrol ediliyor.
            {
                Button b = (Button)sender;
               
                fotografEslesmeKontrol(b.Tag.ToString(), b.Name);
                b.BackgroundImage = Image.FromFile(b.Tag.ToString());
                Animasyon.sesEfekti("tikSesi.wav");
                tmrOyunSuresi.Enabled = true;
                oyunBittiMi();
                if (tiklamaSayisi == 0)
                    return;
                tiklamaSayisi--;
                lblTiklamaSayisi.Text = tiklamaSayisi.ToString();
            }
        }

        private void tmrButonlariAc_Tick(object sender, EventArgs e)
        {
            butonlarAktifMi(true);//bir sn sonra butonlar aktif hale geliyor
            butonlariTersCevir();//bir sn sonra kutular ters çevriliyor.
        }

        private void tmrOyunSuresi_Tick(object sender, EventArgs e)
        {
            geriSayim();
        }

        private void buton_MouseMove(object sender, MouseEventArgs e)
        {
            Animasyon.butonUstuneGelinceRenkDegistir(sender, Color.LightSteelBlue);
        }

        private void buton_MouseLeave(object sender, EventArgs e)
        {
            Animasyon.butondanAyrilincaRenkDegisyir(sender, Color.DarkSalmon);
        }

        private void pictGeriDon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Oyundan çıkmak istediğinizden emin misiniz?", "Hayvanlar Hafıza Oyunu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FormAnaMenu anaMenu = new FormAnaMenu();
                anaMenu.Show();
                this.Close();
            }
        }

    }
}