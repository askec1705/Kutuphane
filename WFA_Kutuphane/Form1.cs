using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace WFA_Kutuphane
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        void Temizle(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item is MetroTextBox)
                {
                    item.Text = "";
                }
                else if (item is NumericUpDown)
                {
                    item.Text = "0";
                }
                else if (item is ComboBox)
                {
                    item.Text = null;
                }
                else if (item is MetroDateTime)
                {
                    item.Text = "";
                }
            }
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTur.Items.AddRange(Enum.GetNames(typeof(Tür)));
        }

        private void txtKitapAdi_Validating(object sender, CancelEventArgs e)
        {
            if (txtKitapAdi.Text.Trim() == "") //eğer txtKitapAdi boş ise
                errorProvider1.SetError(txtKitapAdi, "Bu alanı boş geçemezsiniz!!!");
            // ErrorProvider açılacak ve
            //üstteki satırda belirtilen msj çıkacak
            else
                errorProvider1.SetError(txtKitapAdi, "");
            // ErrorProvider kapanacak
        }

        private void txtYazarAdi_Validating(object sender, CancelEventArgs e)
        {
            if (txtYazarAdi.Text.Trim() == "") //eğer txtKitapAdi boş ise
                errorProvider1.SetError(txtYazarAdi, "Bu alanı boş geçemezsiniz!!!");
            else
                errorProvider1.SetError(txtYazarAdi, "");
        }

        private void txtISBNNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtISBNNo.Text.Trim() == "") //eğer txtKitapAdi boş ise
                errorProvider1.SetError(txtISBNNo, "Bu alanı boş geçemezsiniz!!!");
            else
                errorProvider1.SetError(txtISBNNo, "");
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.KitapAdi = txtKitapAdi.Text;
            book.YazarAdi = txtYazarAdi.Text;
            book.YayinEvi = txtYayinEvi.Text;
            book.BaskiSayisi = nmrBaskiSayisi.Text;
            book.SayfaSayisi = nmrSayfaSayisi.Text;
            book.BasimYili = dtBasimYili.Text;
            book.Tür = (Tür)Enum.Parse(typeof(Tür), cmbTur.Text);
            book.ISBN_No = txtISBNNo.Text;


            lstKitaplar.Items.Add(book);
            Temizle(groupBox1);  // this
            MessageBox.Show("Kitabınız kaydedildi.");
        }

        private void tsmSil_Click(object sender, EventArgs e)
        {
            if (lstKitaplar.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Lütfen Eleman Seçiniz!");
                return;
            }
            lstKitaplar.Items.Remove(lstKitaplar.SelectedItem);
            MessageBox.Show("Kitabınız silindi.");
        }
        Book bk;
        int index = 0;
        private void tsmDuzenle_Click(object sender, EventArgs e)
        {
            if (lstKitaplar.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Lütfen Eleman Seçiniz!");
                return;
            }

            bk = (Book)lstKitaplar.SelectedItem;  // database üzerinden gelen data
            txtKitapAdi.Text = bk.KitapAdi;
            txtYazarAdi.Text = bk.YazarAdi;
            txtYayinEvi.Text = bk.YayinEvi;
            nmrBaskiSayisi.Text = bk.BaskiSayisi;
            nmrSayfaSayisi.Text = bk.SayfaSayisi;
            dtBasimYili.Text = bk.BasimYili;
            cmbTur.Text = (string)Enum.Parse(typeof(Tür), cmbTur.Text);
            txtISBNNo.Text = bk.ISBN_No;

            index = lstKitaplar.SelectedIndex;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int i = lstKitaplar.SelectedIndex;

            bk.KitapAdi = txtKitapAdi.Text;
            bk.YazarAdi = txtYazarAdi.Text;
            bk.YayinEvi = txtYayinEvi.Text;
            bk.BaskiSayisi = nmrBaskiSayisi.Text;
            bk.SayfaSayisi = nmrSayfaSayisi.Text;
            bk.BasimYili = dtBasimYili.Text;
            bk.Tür = (Tür)Enum.Parse(typeof(Tür), cmbTur.Text);
            bk.ISBN_No = txtISBNNo.Text;

            lstKitaplar.Items.RemoveAt(index);
            lstKitaplar.Items.Insert(index, bk);
            Temizle(groupBox1);
            bk = null;
            MessageBox.Show("Kitabınız güncellendi.");
        }
    }
}
