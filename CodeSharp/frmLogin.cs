using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CodeSharp
{
    public partial class frmLogin : Form
    {
        dbDataContext db = new dbDataContext();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnLog_Click(this, new EventArgs());
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtUser.Clear();
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtPass.Clear();
            }
        }
        
        private void btnLog_Click(object sender, EventArgs e)
        {
            if (txtPass.Text != "" && txtUser.Text != "")
            {
                if (userVal(txtUser.Text, txtPass.Text))
                {
                    frmMain main = new frmMain(); main.ShowDialog(); Close();
                }
            }
            else
            {
                MessageBox.Show("Fill it");txtPass.Text = "";txtPass.Focus();
            }
        }
        private bool userVal(string user,string pass)
        {
            var sonuc = from d in db.users where d.username==user && d.password==pass select d;
            return sonuc.Count() > 0;
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }
    }
}
