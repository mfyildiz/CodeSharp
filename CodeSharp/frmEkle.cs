using System;
using System.Windows.Forms;

namespace CodeSharp
{
    public partial class frmEkle : Form
    {
        private static dbDataContext db = new dbDataContext();
        public frmEkle()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnbitir_Click(object sender, EventArgs e)
        {
            if (rtxtacgir.Text != "" && rtxtadgir.Text != "" && rtxtkodgir.Text != "" && rtxtdilgir.Text!="")
            {
                codesharp cod = new codesharp()
                {
                    name = rtxtadgir.Text,
                    descr = rtxtacgir.Text,
                    text = rtxtkodgir.Text,
                    lang = rtxtdilgir.Text,
                    pack=rtxtpackgir.Text
                };
                db.codesharps.InsertOnSubmit(cod);
                db.SubmitChanges();
                MessageBox.Show("Eklendi"); this.Close();
            }

            else { MessageBox.Show("Boş alan bırakmayınız. "); }
        }
    }
}
