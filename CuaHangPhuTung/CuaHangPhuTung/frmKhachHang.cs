using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CuaHangPhuTung
{
    public partial class frmKhachHang : Form
    {
        string sCon = @"Data Source=DESKTOP-9QSGK01;Initial Catalog=CHPT;Integrated Security=True";
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            //Bước 1 - Thiết lập kết nối 
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
            }
            //Bước 2 - lấy dữ liệu về
            string sQuery = "Select * from KHACHHANG";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "KHACHHANG");

            dataGridView1.DataSource = ds.Tables["KHACHHANG"];
            dataGridView1.Columns[0].HeaderText = "Mã khách hàng";
            dataGridView1.Columns[1].HeaderText = "Tên khách hàng";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
            dataGridView1.Columns[3].HeaderText = "Điện thoại";

            dataGridView1.Columns[0].Width = 170;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 300;
            dataGridView1.Columns[3].Width = 150;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["TenKH"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["DienThoai"].Value.ToString();
            textBox1.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0 || this.textBox2.TextLength == 0 || this.textBox3.TextLength == 0 ||
                this.textBox4.TextLength == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection con = new SqlConnection(sCon);
                try
                {
                    con.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB!");
                }
                string sMaKH = textBox1.Text;
                string sTenKH = textBox2.Text;
                string sDiaChi = textBox3.Text;
                string sDienThoai = textBox4.Text;
                string sQuery2 = " insert into KHACHHANG values(@MaKH, @TenKH, @DiaChi,@DienThoai)";
                SqlCommand cmd = new SqlCommand(sQuery2, con);
                cmd.Parameters.AddWithValue("@MaKH", sMaKH);
                cmd.Parameters.AddWithValue("@TenKH", sTenKH);
                cmd.Parameters.AddWithValue("@DiaChi", sDiaChi);
                cmd.Parameters.AddWithValue("@DienThoai", sDienThoai);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                        MessageBox.Show("Xảy ra lỗi trong quá trình thêm mới!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string sQuery = "Select * from KHACHHANG";
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

                DataSet ds = new DataSet();

                adapter.Fill(ds, "KHACHHANG");

                dataGridView1.DataSource = ds.Tables["KHACHHANG"];
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB!");
            }
            string sMaKH = textBox1.Text;
            string sQuery2 = "delete KHACHHANG where MaKH=@MaKH";
            SqlCommand cmd = new SqlCommand(sQuery2, con);
            cmd.Parameters.AddWithValue("@MaKH", sMaKH);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình xóa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string sQuery = "Select * from KHACHHANG";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "KHACHHANG");

            dataGridView1.DataSource = ds.Tables["KHACHHANG"];
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB3!");
            }
            string sMaKH = textBox1.Text;
            string sTenKH = textBox2.Text;
            string sDiaChi = textBox3.Text;
            string sDienThoai = textBox4.Text;
            string sQuery2 = "Update KHACHHANG Set TenKH = @TenKH, DiaChi = @DiaChi, DienThoai = @DienThoai Where MaKH = @MaKH";
            SqlCommand cmd = new SqlCommand(sQuery2, con);
            cmd.Parameters.AddWithValue("@MaKH", sMaKH);
            cmd.Parameters.AddWithValue("@TenKH", sTenKH);
            cmd.Parameters.AddWithValue("@DiaChi", sDiaChi);
            cmd.Parameters.AddWithValue("@DienThoai", sDienThoai);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string sQuery = "Select * from KHACHHANG";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "KHACHHANG");
            dataGridView1.DataSource = ds.Tables["KHACHHANG"];
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox1.Enabled = true;
            textBox5.Text = "";
            //Bước 1
            SqlConnection con = new SqlConnection(sCon);
            //Bước 2 - lấy dữ liệu về
            string sQuery = "Select * from KHACHHANG";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "KHACHHANG");
            dataGridView1.DataSource = ds.Tables["KHACHHANG"];
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB!");
            }
            string sTenKH = "%" + textBox5.Text + "%";
            string sQuery = "select *from KHACHHANG Where (TenKH) like (@TenKH)";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@TenKH", sTenKH);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }
    }
}
