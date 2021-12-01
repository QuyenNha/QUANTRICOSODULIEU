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
    public partial class frmNhaCC : Form
    {
        string sCon = @"Data Source=DESKTOP-9QSGK01;Initial Catalog=CHPT;Integrated Security=True";
        public frmNhaCC()
        {
            InitializeComponent();
        }

        private void frmNhaCC_Load(object sender, EventArgs e)
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
            string sQuery = "Select * from NHACC";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "NHACC");

            dataGridView1.DataSource = ds.Tables["NHACC"];
            dataGridView1.Columns[0].HeaderText = "Mã nhà cung cấp";
            dataGridView1.Columns[1].HeaderText = "Tên nhà cung cấp";
            dataGridView1.Columns[2].HeaderText = "Điện thoại";
            dataGridView1.Columns[3].HeaderText = "Địa chỉ";

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 230;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["MaNCC"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["TenNCC"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["DienThoaiNCC"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["DiaChiNCC"].Value.ToString();
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
                string sMaNCC = textBox1.Text;
                string sTenNCC = textBox2.Text;
                string sDienThoaiNCC = textBox3.Text;
                string sDiaChiNCC = textBox4.Text;
                string sQuery2 = " insert into NHACC values(@MaNCC, @TenNCC, @DienThoaiNCC,@DiaChiNCC)";
                SqlCommand cmd = new SqlCommand(sQuery2, con);
                cmd.Parameters.AddWithValue("@MaNCC", sMaNCC);
                cmd.Parameters.AddWithValue("@TenNCC", sTenNCC);
                cmd.Parameters.AddWithValue("@DienThoaiNCC", sDienThoaiNCC);
                cmd.Parameters.AddWithValue("@DiaChiNCC", sDiaChiNCC);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình thêm mới!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string sQuery = "Select * from NHACC";
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

                DataSet ds = new DataSet();

                adapter.Fill(ds, "NHACC");

                dataGridView1.DataSource = ds.Tables["NHACC"];
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
            string sMaNCC = textBox1.Text;
            string sQuery2 = "delete NHACC where MaNCC=@MaNCC";
            SqlCommand cmd = new SqlCommand(sQuery2, con);
            cmd.Parameters.AddWithValue("@MaNCC", sMaNCC);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình xóa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string sQuery = "Select * from NHACC";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "NHACC");

            dataGridView1.DataSource = ds.Tables["NHACC"];
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
            string sMaNCC = textBox1.Text;
            string sTenNCC = textBox2.Text;
            string sDienThoaiNCC = textBox3.Text;
            string sDiaChiNCC = textBox4.Text;
            string sQuery2 = "Update NHACC Set TenNCC = @TenNCC, DiaChiNCC = @DiaChiNCC, DienThoaiNCC = @DienThoaiNCC Where MaNCC = @MaNCC";
            SqlCommand cmd = new SqlCommand(sQuery2, con);
            cmd.Parameters.AddWithValue("@MaNCC", sMaNCC);
            cmd.Parameters.AddWithValue("@TenNCC", sTenNCC);
            cmd.Parameters.AddWithValue("@DienThoaiNCC", sDienThoaiNCC);
            cmd.Parameters.AddWithValue("@DiaChiNCC", sDiaChiNCC);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string sQuery = "Select * from NHACC";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "NHACC");
            dataGridView1.DataSource = ds.Tables["NHACC"];
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
            string sQuery = "Select * from NHACC";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "NHACC");
            dataGridView1.DataSource = ds.Tables["NHACC"];
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
            string sTenNCC = "%" + textBox5.Text + "%";
            string sQuery = "select *from NHACC Where (TenNCC) like (@TenNCC)";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@TenNCC", sTenNCC);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }
    }
}
