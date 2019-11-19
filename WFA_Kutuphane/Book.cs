using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_Kutuphane
{
    public enum Tür
    {
        Roman, Tarih, Mizah, Biyografi, Psikoloji
    }
    class Book
    {
        public string KitapAdi { get; set; }
        public string YazarAdi { get; set; }
        public string YayinEvi { get; set; }
        public string BaskiSayisi { get; set; }
        public string SayfaSayisi { get; set; }
        public string BasimYili { get; set; }
        public Tür Tür { get; set; }
        public string ISBN_No { get; set; }


        public override string ToString()
        {
            //return $"{this.KitapAdi} {this.YazarAdi}";

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.KitapAdi);
            stringBuilder.Append(" ");
            stringBuilder.Append(this.YazarAdi);
            return stringBuilder.ToString();
        }
    }
}
