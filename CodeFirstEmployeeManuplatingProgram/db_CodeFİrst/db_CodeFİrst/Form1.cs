using db_CodeFİrst.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_CodeFİrst
{
    public partial class Form1 : Form
    {
        RehberContext _db;  
        public Form1()
        {
            InitializeComponent();
            _db = new RehberContext();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*yine entityFrameworkdeki paketlerimizi yükledik
             * package Manager Console üstünden,add-migration migV.1.0 dedikten sonra verilerimizi açılan ekranda kontrol ediyoruz ve  ardından
             * update-database diyerek database imizi oluşturuyoruz.
            */
            dgwListe.DataSource=_db.Rehbers.ToList();
        }

        private void btnRehbereEkle_Click(object sender, EventArgs e)
        {
            var insan= new Rehber();
            insan.Ad = tbAd.Text;
            insan.Soyad = tbSoyad.Text;
            insan.Telefon = tbTelefon.Text;
            _db.Rehbers.Add(insan);
            tbAd.Clear();
            tbSoyad.Clear();
            tbTelefon.Clear();
            _db.SaveChanges();
            dgwListe.DataSource = _db.Rehbers.ToList();
            MessageBox.Show("Kişi Eklendi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgwListe.SelectedRows.Count == 0) return;


            int id = (int)dgwListe.SelectedRows[0].Cells[0].Value;

            Rehber? rehber = _db.Rehbers.Find(id);
            rehber.Ad = tbAd.Text;
            rehber.Soyad = tbSoyad.Text;
            rehber.Telefon = tbTelefon.Text;

            _db.SaveChanges();

        }

        private void btnKisiAra_Click(object sender, EventArgs e)
        {
            dgwListe.DataSource =_db.Rehbers.Where(a => a.Ad.Contains(tbSearchingWords.Text) || a.Soyad.Contains(tbSearchingWords.Text)).ToList();
            
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            dgwListe.DataSource = null;
            dgwListe.DataSource = _db.Rehbers.ToList();
        }
    }
}