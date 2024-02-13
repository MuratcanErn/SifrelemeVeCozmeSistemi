using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFOdevSifreleme_0.Tools
{
    //HP-PC\SQLEXPRESS
    public class Sifre
    {
  
        private string SifreCoz(string s)
        {
            string a = null, b = null;
            foreach (int item in s)
            {
                if (item != '-')
                {
                    b += Convert.ToChar(item);
                }
                else
                {
                    a += Convert.ToChar(((((Convert.ToInt32(b)-69)-31)/2)/5));
                    b = null;
                }
            }
            return a;
        }//Sadece yönetici ekibi şifrelere bakabilir ;)...
        public string SifreKaristir(string s)
        {
            string a = null;
            foreach (char item in s)
            {
                a += $"{Convert.ToInt32((((item *5)*2)+31)+69)}-";
            }
            return a;
        }
    }
}
