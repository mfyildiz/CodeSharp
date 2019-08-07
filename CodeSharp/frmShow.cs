using System;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;

namespace CodeSharp
{
    public partial class frmShow : Form
    {
        private static dbDataContext db = new dbDataContext();
        public frmShow()
        {
            InitializeComponent();
        }
        private void frmShow_Load(object sender, EventArgs e)
        {
            db.Refresh(RefreshMode.OverwriteCurrentValues, db.codesharps);
            rtxthor.Text = db.codesharps.First(d => d.id == frmMain.ids).text;
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
    }
}
