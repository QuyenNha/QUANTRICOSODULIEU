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
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-EFQDFTG\SQLEXPRESS;Initial Catalog=CHPT;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                string taikhoan = txtTaiKhoan.Text;
                string matkhau = txtMatKhau.Text;
                //lay du lieu tu bang
                string query = "Select * from TAIKHOAN where TaiKhoan = '" + taikhoan + "' and MatKhau = '" + matkhau + "'";
                //bat dau truy van
                SqlCommand cmd = new SqlCommand(query, conn);
                //doc du lieu
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()==true)
                {
                    FrmMain frmMain = new FrmMain();
                    frmMain.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tên tài khoản hoặc mật khẩu. Vui lòng kiểm tra lại!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTaiKhoan.Text = "";
                    txtMatKhau.Text = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối!");
            }
            //dong ket noi
            conn.Close();;
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
