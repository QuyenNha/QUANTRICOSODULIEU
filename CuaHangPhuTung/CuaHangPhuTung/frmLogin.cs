using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CuaHangPhuTung
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        //ta Source=DESKTOP-9QSGK01;Initial Catalog=CHPT;Integrated Security=True
        SqlConnection getCon(string user, string pass)
        {
            return new SqlConnection("Data Source=DESKTOP-9QSGK01; Initial Catalog=CHPT; User ID =" + txtTaiKhoan.Text + ";Password=" + txtMatKhau.Text + ";");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = getCon(txtTaiKhoan.Text, txtMatKhau.Text);
            try
            {
                con.Open();
                FrmMain frmMain = new FrmMain();
                frmMain.Show();
                this.Hide();
            }
            catch(Exception)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
        }
    }
}
