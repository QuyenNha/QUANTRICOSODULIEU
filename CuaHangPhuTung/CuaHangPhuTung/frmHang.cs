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
    public partial class frmHang : Form
    {

        string sCon = @"Data Source=DESKTOP-9QSGK01;Initial Catalog=CHPT;Integrated Security=True";
        public frmHang()
        {
            InitializeComponent();
        }

        private void frmHang_Load(object sender, EventArgs e)
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
            string sQuery = "Select * from Hang";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Hang");

            dataGridView1.DataSource = ds.Tables["Hang"];
            dataGridView1.Columns[0].HeaderText = "Mã hàng";
            dataGridView1.Columns[1].HeaderText = "Tên hàng";
            dataGridView1.Columns[2].HeaderText = "Đơn vị";
            dataGridView1.Columns[3].HeaderText = "Hãng sản xuất";
            dataGridView1.Columns[4].HeaderText = "Số lượng tồn kho";
            dataGridView1.Columns[5].HeaderText = "Đơn giá nhập";
            dataGridView1.Columns[6].HeaderText = "Đơn giá bán";
            dataGridView1.Columns[7].HeaderText = "Mã loại hàng";
            string sql1 = "Select * from LOAIHANG";
            comboBox1.DataSource = Database.Singleton.LoadData(sql1);
            comboBox1.DisplayMember = "MaLH";


            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 170;
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[6].Width = 150;
            dataGridView1.Columns[7].Width = 150;



            string sQuery1 = "Select * from LOAIHANG";
            SqlDataAdapter adapter1 = new SqlDataAdapter(sQuery1, con);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1, "LOAIHANG");

            dataGridView2.DataSource = ds1.Tables["LOAIHANG"];
            dataGridView2.Columns[0].HeaderText = "Mã loại hàng";
            dataGridView2.Columns[1].HeaderText = "Tên Loại Hàng";

            dataGridView2.Columns[0].Width = 200;
            dataGridView2.Columns[1].Width = 350;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["MaH"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["TenH"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["DonVi"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["HangSX"].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["HangTonKho"].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["DonGiaNhap"].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["DonGiaBan"].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["MaLH"].Value.ToString();

            textBox1.Enabled = false;
            textBox5.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0 || this.textBox2.TextLength == 0 || this.textBox3.TextLength == 0 ||
                this.textBox4.TextLength == 0 || this.textBox5.TextLength == 0 || this.textBox6.TextLength == 0 ||
                this.textBox7.TextLength == 0 || this.comboBox1.Text == null)
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
                string sMaH = textBox1.Text;
                string sTenH = textBox2.Text;
                string sDonVi = textBox3.Text;
                string sHangSX = textBox4.Text;
                string sHangTonKho = textBox5.Text;
                string sDonGiaNhap = textBox6.Text;
                string sDonGiaBan = textBox7.Text;
                string sMaLH = comboBox1.Text;
                string sQuery2 = " insert into HANG values(@MaH, @TenH, @DonVi ,@HangSX, @HangTonKho, @DonGiaNhap, @DonGiaBan, @MaLH)";
                SqlCommand cmd = new SqlCommand(sQuery2, con);
                cmd.Parameters.AddWithValue("@MaH", sMaH);
                cmd.Parameters.AddWithValue("@TenH", sTenH);
                cmd.Parameters.AddWithValue("@DonVi", sDonVi);
                cmd.Parameters.AddWithValue("@HangSX", sHangSX);
                cmd.Parameters.AddWithValue("@HangTonKho", sHangTonKho);
                cmd.Parameters.AddWithValue("@DonGiaNhap", sDonGiaNhap);
                cmd.Parameters.AddWithValue("@DonGiaBan", sDonGiaBan);
                cmd.Parameters.AddWithValue("@MaLH", sMaLH);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình thêm mới!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string sQuery = "Select * from HANG";
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

                DataSet ds = new DataSet();

                adapter.Fill(ds, "HANG");

                dataGridView1.DataSource = ds.Tables["HANG"];
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
            string sMaH = textBox1.Text;
            string sQuery2 = "delete HANG where MaH=@MaH";
            SqlCommand cmd = new SqlCommand(sQuery2, con);
            cmd.Parameters.AddWithValue("@MaH", sMaH);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình xóa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string sQuery = "Select * from HANG";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "HANG");

            dataGridView1.DataSource = ds.Tables["HANG"];
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
            string sMaH = textBox1.Text;
            string sTenH = textBox2.Text;
            string sDonVi = textBox3.Text;
            string sHangSX = textBox4.Text;
            string sHangTonKho = textBox5.Text;
            string sDonGiaNhap = textBox6.Text;
            string sDonGiaBan = textBox7.Text;
            string sMaLH = comboBox1.Text;
            string sQuery2 = "Update HANG Set TenH  = @TenH , DonVi = @DonVi, HangSX = @HangSx, HangTonKho = @HangTonKho, DonGiaNhap= @DonGiaNhap, DonGiaBan = @DonGiaBan, MaLH = @MaLH Where MaH = @MaH";
            SqlCommand cmd = new SqlCommand(sQuery2, con);
            cmd.Parameters.AddWithValue("@MaH", sMaH);
            cmd.Parameters.AddWithValue("@TenH", sTenH);
            cmd.Parameters.AddWithValue("@DonVi", sDonVi);
            cmd.Parameters.AddWithValue("@HangSX", sHangSX);
            cmd.Parameters.AddWithValue("@HangTonKho", sHangTonKho);
            cmd.Parameters.AddWithValue("@DonGiaNhap", sDonGiaNhap);
            cmd.Parameters.AddWithValue("@DonGiaBan", sDonGiaBan);
            cmd.Parameters.AddWithValue("@MaLH", sMaLH);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string sQuery = "Select * from HANG";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "HANG");
            dataGridView1.DataSource = ds.Tables["HANG"];
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox1.Enabled = true;
            textBox9.Text = "";
            //Bước 1
            SqlConnection con = new SqlConnection(sCon);
            //Bước 2 - lấy dữ liệu về
            string sQuery = "Select * from HANG";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "HANG");
            dataGridView1.DataSource = ds.Tables["HANG"];
            con.Close();
        }

        private void button10_Click(object sender, EventArgs e)
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
            string sTenH = "%" + textBox9.Text + "%";
            string sQuery = "select *from HANG Where (TenH) like (@TenH)";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@TenH", sTenH);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox10.Text = dataGridView2.Rows[e.RowIndex].Cells["MaLH"].Value.ToString();
            textBox11.Text = dataGridView2.Rows[e.RowIndex].Cells["TenLH"].Value.ToString();
            textBox10.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.textBox10.TextLength == 0 || this.textBox11.TextLength == 0)
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
                string sMaLH = textBox10.Text;
                string sTenLH = textBox11.Text;
                string sQuery2 = " insert into LOAIHANG values(@MaLH, @TenLH)";
                SqlCommand cmd = new SqlCommand(sQuery2, con);
                cmd.Parameters.AddWithValue("@MaLH", sMaLH);
                cmd.Parameters.AddWithValue("@TenLH", sTenLH);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình thêm mới!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string sQuery = "Select * from LOAIHANG";
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "LOAIHANG");
                dataGridView2.DataSource = ds.Tables["LOAIHANG"];
                con.Close();

                //
                string sql1 = "Select * from LOAIHANG";
                comboBox1.DataSource = Database.Singleton.LoadData(sql1);
                comboBox1.DisplayMember = "MaLH";
            }
        }

        private void button7_Click(object sender, EventArgs e)
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
            string sMaLH = textBox10.Text;
            string sQuery2 = "delete LOAIHANG where MaLH=@MaLH";
            SqlCommand cmd = new SqlCommand(sQuery2, con);
            cmd.Parameters.AddWithValue("@MaLH", sMaLH);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình xóa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string sQuery = "Select * from LOAIHANG";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "LOAIHANG");
            dataGridView2.DataSource = ds.Tables["LOAIHANG"];
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
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
            string sMaLH = textBox10.Text;
            string sTenLH = textBox11.Text;
            string sQuery2 = "Update LOAIHANG Set TenLH  = @TenLH Where MaLH = @MaLH";
            SqlCommand cmd = new SqlCommand(sQuery2, con);
            cmd.Parameters.AddWithValue("@MaLH", sMaLH);
            cmd.Parameters.AddWithValue("@TenLH", sTenLH);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string sQuery = "Select * from LOAIHANG";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "LOAIHANG");
            dataGridView2.DataSource = ds.Tables["LOAIHANG"];
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox10.Enabled = true;
            //Bước 1
            SqlConnection con = new SqlConnection(sCon);
            //Bước 2 - lấy dữ liệu về
            string sQuery = "Select * from LOAIHANG";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "LOAIHANG");
            dataGridView2.DataSource = ds.Tables["LOAIHANG"];
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
            string sTenLH = "%" + textBox12.Text + "%";
            string sQuery = "select *from LOAIHANG  Where (TenLH) like (@TenLH)";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@TenLH", sTenLH);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView2.DataSource = dt;
        }
    }
}