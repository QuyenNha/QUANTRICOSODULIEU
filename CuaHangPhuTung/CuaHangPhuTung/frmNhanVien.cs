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
    public partial class frmNhanVien : Form
    {
        string sCon = @"Data Source=DESKTOP-9QSGK01;Initial Catalog=CHPT;Integrated Security=True";
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {//Bước 1 - Thiết lập kết nối 
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
            string sQuery = "Select * from NHANVIEN";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "NHANVIEN");

            dataGridView1.DataSource = ds.Tables["NHANVIEN"];
            dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[1].HeaderText = "Tên nhân viên";
            dataGridView1.Columns[2].HeaderText = "Ngày sinh";
            dataGridView1.Columns[3].HeaderText = "Địa chỉ";
            dataGridView1.Columns[4].HeaderText = "Điện thoại";

            dataGridView1.Columns[0].Width = 170;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 300;
            dataGridView1.Columns[4].Width = 150;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["TenNV"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["DienThoai"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["NgaySinh"].Value);
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0 || this.textBox2.TextLength == 0 || this.textBox3.TextLength == 0 ||
                this.textBox4.TextLength == 0 || this.dateTimePicker1.Value == null)
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
                string sMaNV = textBox1.Text;
                string sTenNV = textBox2.Text;
                string sDienThoai = textBox3.Text;
                string sDiaChi = textBox4.Text;
                string sNgaySinh = dateTimePicker1.Value.ToString("yyy-MM-dd");
                string sQuery2 = " insert into NHANVIEN values(@MaNV, @TenNV,@NgaySinh ,@DiaChi,@DienThoai)";
                SqlCommand cmd = new SqlCommand(sQuery2, con);
                cmd.Parameters.AddWithValue("@MaNV", sMaNV);
                cmd.Parameters.AddWithValue("@TenNV", sTenNV);
                cmd.Parameters.AddWithValue("@DienThoai", sDienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", sDiaChi);
                cmd.Parameters.AddWithValue("@NgaySinh", sNgaySinh);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình thêm mới!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string sQuery = "Select * from NHANVIEN";
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

                DataSet ds = new DataSet();

                adapter.Fill(ds, "NHANVIEN");

                dataGridView1.DataSource = ds.Tables["NHANVIEN"];
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
            string sMaNV = textBox1.Text;
            string sQuery2 = "delete NHANVIEN where MaNV=@MaNV";
            SqlCommand cmd = new SqlCommand(sQuery2, con);
            cmd.Parameters.AddWithValue("@MaNV", sMaNV);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình xóa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string sQuery = "Select * from NHANVIEN";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "NHANVIEN");

            dataGridView1.DataSource = ds.Tables["NHANVIEN"];
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
            string sMaNV = textBox1.Text;
            string sTenNV = textBox2.Text;
            string sDienThoai = textBox3.Text;
            string sDiaChi = textBox4.Text;
            string sNgaySinh = dateTimePicker1.Value.ToString("yyy-MM-dd");
            string sQuery2 = "Update NHANVIEN Set TenNV  = @TenNV , DiaChi = @DiaChi, DienThoai = @DienThoai, NgaySinh = @NgaySinh Where MaNV = @MaNV";
            SqlCommand cmd = new SqlCommand(sQuery2, con);
            cmd.Parameters.AddWithValue("@MaNV", sMaNV);
            cmd.Parameters.AddWithValue("@TenNV ", sTenNV);
            cmd.Parameters.AddWithValue("@DienThoai", sDienThoai);
            cmd.Parameters.AddWithValue("@DiaChi", sDiaChi);
            cmd.Parameters.AddWithValue("@NgaySinh", sNgaySinh);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string sQuery = "Select * from NHANVIEN";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "NHANVIEN");
            dataGridView1.DataSource = ds.Tables["NHANVIEN"];
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dateTimePicker1.Value = new DateTime(2001, 1, 1);
            textBox1.Enabled = true;
            //Bước 1
            SqlConnection con = new SqlConnection(sCon);
            //Bước 2 - lấy dữ liệu về
            string sQuery = "Select * from NHANVIEN";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "NHANVIEN");
            dataGridView1.DataSource = ds.Tables["NHANVIEN"];
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
            string sTenNV = "%" + textBox5.Text + "%";
            string sQuery = "select *from NHANVIEN Where (TenNV) like (@TenNV)";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@TenNV", sTenNV);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }
    }
}
