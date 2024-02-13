using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFOdevSifreleme_0.Models;
using EFOdevSifreleme_0.Tools;

namespace EFOdevSifreleme_0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _db = new AccountDBEntities();
        }
        AccountDBEntities _db;
        public void Ekle()
        {
            lstKullanicilar.DataSource = _db.Users.ToList();
            lstKullanicilar.SelectedIndex = -1;
            lstKullanicilar.DisplayMember = "UserName";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Ekle();
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            Sifre s = new Sifre();
            User u = new User();
            u.UserName=txtKullaniciAdi.Text;
            u.Password = s.SifreKaristir(txtSifre.Text);
            _db.Users.Add(u);
            _db.SaveChanges();
            Ekle();
            MessageBox.Show("Kayıt başarılı");

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Sifre s =new Sifre();
            User u = lstKullanicilar.SelectedItem as User;
            if (u.UserName == txtKullaniciAdi.Text && u.Password == s.SifreKaristir(txtSifre.Text))
            {
                MessageBox.Show("Giriş Başarılı!!");


            }
            else
            {
                MessageBox.Show("Giriş Hatalı !!");
            }
        
            
                               
        }
    }
    
}
