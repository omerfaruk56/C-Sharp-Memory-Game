using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace cSharp_ResimEslemeOyunu
{
    class DosyaCRUD
    {
        private string dosyaYolu;
        private string resimYolu;

        public DosyaCRUD()
        {

        }

        public DosyaCRUD(string dosyaYolu)
        {
            this.dosyaYolu = dosyaYolu + ".txt";
        }

        public DosyaCRUD(string dosyaYolu, string resimYolu)
        {
            this.dosyaYolu = dosyaYolu + ".txt";
            this.resimYolu = resimYolu + ".png";
        }

        public string dosyaOku()
        {
            StreamReader sr = new StreamReader(dosyaYolu, Encoding.GetEncoding("windows-1254"));
           // return File.ReadAllText(dosyaYolu);
            return sr.ReadToEnd();
        }

        public void dosyaYaz(string metin)
        {
            File.WriteAllText(dosyaYolu, metin);
        }

        public string resimOku()
        {
            return resimYolu;
        }

        public void dosyaSil()
        {
            if (File.Exists(dosyaYolu))
                File.Delete(dosyaYolu);
        }

        public void dosyaOlustur()
        {
            File.CreateText(dosyaYolu);
        }
    }
}
