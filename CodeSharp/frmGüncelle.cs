using System;
using System.Linq;
using System.Windows.Forms;

namespace CodeSharp
{
    public partial class frmGüncelle : Form
    {
        private static dbDataContext db = new dbDataContext();
        
        public frmGüncelle()
        {
            InitializeComponent();
        }
        private void frmGüncelle_Load(object sender, EventArgs e)
        {
            rtxtaddeg.Text = frmMain.names;
            rtxtacdeg.Text = frmMain.descr;
            rtxtlandeg.Text = frmMain.langs;
            rtxtpackdeg.Text = frmMain.packs;
            rtxtkoddeg.Text = db.codesharps.First(d => d.id == frmMain.ids).text;
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
        private void btngunce_Click(object sender, EventArgs e)
        {
            if (rtxtacdeg.Text != "" && rtxtaddeg.Text != "" && rtxtkoddeg.Text != "")
            {
                codesharp cod = db.codesharps.First(d => d.id == frmMain.ids);
                cod.name = rtxtaddeg.Text;
                cod.text = rtxtkoddeg.Text;
                cod.descr = rtxtacdeg.Text;
                cod.lang = rtxtlandeg.Text;
                cod.pack = rtxtpackdeg.Text;
                db.SubmitChanges();
                MessageBox.Show("Güncellendi"); this.Close();
            }
            else { MessageBox.Show("Güncellenmendi.(Boş alan bırakmayınız) "); }
        }
    }
}

