using System;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;

namespace CodeSharp
{
    public partial class frmMain : Form
    {
        #region frmmain
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            fill();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
        }
        private static dbDataContext db = new dbDataContext();
        public static int ids;
        public static string names;
        public static string descr;
        public static string langs;
        public static string packs;

        #endregion
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void fill()
        {
            var result = from d in db.codesharps
                         orderby Name descending
                         select new
                         {
                             NAME = d.name,
                             DESCRİPTİON = d.descr,
                             LANG = d.lang,
                             PACKAGE=d.pack,
                             ID=d.id
                         };
            dgv.DataSource = result.ToList();
            dgv.Columns[4].Visible = false;
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtSearch.Clear();
            }
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            frmEkle yeni = new frmEkle();
            yeni.ShowDialog();
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.codesharps);
            fill();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                ids = int.Parse(dgv.SelectedRows[0].Cells[4].Value.ToString());
                names = string.Copy(dgv.SelectedRows[0].Cells[0].Value.ToString());
                descr = string.Copy(dgv.SelectedRows[0].Cells[1].Value.ToString());
                langs = string.Copy(dgv.SelectedRows[0].Cells[2].Value.ToString());
                packs = string.Copy(dgv.SelectedRows[0].Cells[3].Value.ToString());
                frmGüncelle yeni = new frmGüncelle();
                yeni.ShowDialog();
                db.Refresh(RefreshMode.OverwriteCurrentValues, db.codesharps);
                fill();
            }
            catch
            {
                MessageBox.Show("NO DATA");
            }
        }
        private void dgv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ids = int.Parse(dgv.SelectedRows[0].Cells[4].Value.ToString());
            frmShow yeni = new frmShow();
            yeni.ShowDialog();
            fill();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            fill(txtSearch.Text);
        }
        private void fill(string text)
        {
            var result = from d in db.codesharps
                         where d.name.Contains(text) || d.descr.Contains(text) || d.pack.Contains(text) || d.lang.Contains(text)
                         orderby Name descending
                         select new
                         {
                             NAME = d.name,
                             DESCRİPTİON = d.descr,
                             LANG = d.lang,
                             ID = d.id,
                             PACKAGE=d.pack
                         };
            dgv.DataSource = result.ToList();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int idd = int.Parse(dgv.SelectedRows[0].Cells[4].Value.ToString());
                codesharp cod = db.codesharps.First(d => d.id == idd);
                db.codesharps.DeleteOnSubmit(cod);
                db.SubmitChanges();
                db.Refresh(RefreshMode.OverwriteCurrentValues, db.codesharps);
                fill();
            }
            catch
            {
                MessageBox.Show("NO DATA");
            }
        }
    }
}
