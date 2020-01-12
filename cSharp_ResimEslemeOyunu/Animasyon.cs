using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace cSharp_ResimEslemeOyunu
{
    class Animasyon
    {
        public static void sesEfekti(string sesYolu)
        {
            SoundPlayer tikSesi = new SoundPlayer();
            tikSesi.SoundLocation = sesYolu;
            tikSesi.Play();
        }

        public static void butonUstuneGelinceRenkDegistir(object component, Color renk)
        {
            if (component is Button)
            {
                Button b = (Button)component;
                b.BackColor = renk;
            }
        }

        public static void butondanAyrilincaRenkDegisyir(object component, Color renk)
        {
            if (component is Button)
            {
                Button b = (Button)component;
                b.BackColor = renk;
            }
        }
    }
}