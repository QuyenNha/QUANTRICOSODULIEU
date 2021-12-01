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
    public partial class frmHoaDon : Form
    {
        string sCon = @"Data Source=DESKTOP-9QSGK01;Initial Catalog=CHPT;Integrated Security=True";
        public frmHoaDon()
        {
            InitializeComponent();
        }
        private void frmHoaDon_Load(object sender, EventArgs e)
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
            string sQuery = "Select * from HOADON";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "HOADON");

            dataGridView1.DataSource = ds.Tables["HOADON"];
            dataGridView1.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridView1.Columns[1].HeaderText = "Mã khách hàng";
            dataGridView1.Columns[2].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[3].HeaderText = "Ngày bán";
            dataGridView1.Columns[4].HeaderText = "Tổng cộng";
            string sql = "Select * from NHANVIEN";
            comboBox1.DataSource = Database.Singleton.LoadData(sql);
            comboBox1.DisplayMember = "MaNV";
            string sql1 = "Select * from KHACHHANG";
            comboBox2.DataSource = Database.Singleton.LoadData(sql1);
            comboBox2.DisplayMember = "MaKH";

            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 145;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 150;

            string sql2 = "Select * from HANG";
            comboBox3.DataSource = Database.Singleton.LoadData(sql2);
            comboBox3.DisplayMember = "MaH";

            textBox2.Enabled = false;
            textBox8.Enabled = false;
            textBox6.Enabled = false;
            textBox4.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["TongCong"].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["NgayBan"].Value);
            textBox1.Enabled = false;
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox3.Text = dataGridView2.Rows[e.RowIndex].Cells["MaH"].Value.ToString();
            numericUpDown1.Text = dataGridView2.Rows[e.RowIndex].Cells["SoLuongBan"].Value.ToString();
            textBox6.Text = dataGridView2.Rows[e.RowIndex].Cells["ThanhTien"].Value.ToString();
            textBox6.Enabled = false;
            comboBox3.Enabled = false;
        }
        private void ShowHangTonKho()
        {
            SqlConnection con = new SqlConnection(sCon); // khoi tao ket noi 
            con.Open();
            string Squery2 = "select MaH,HangTonKho from hang";
            SqlDataAdapter adapter2 = new SqlDataAdapter(Squery2, con);
            DataSet ds2 = new DataSet();
            adapter2.Fill(ds2, "MaHang");
            textBox4.Text = ds2.Tables["MaHang"].Rows[comboBox3.SelectedIndex]["HangTonKho"].ToString();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon); // khoi tao ket noi 
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối dữ liệu!", "Thông Báo");
            }

            string sQuery1 = "select MaH,Dongiaban from hang";
            SqlDataAdapter adapter1 = new SqlDataAdapter(sQuery1, con);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1, "MaHang");
            textBox8.Text = ds1.Tables["MaHang"].Rows[comboBox3.SelectedIndex]["Dongiaban"].ToString();
            con.Close();// đóng kết nối 

            ShowHangTonKho();
            int dongia = Convert.ToInt32(textBox8.Text);
            int soluong = Convert.ToInt16(numericUpDown1.Value);
            int tien = dongia * soluong;
            textBox6.Text = tien.ToString();

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            int dongia = Convert.ToInt32(textBox8.Text);
            int soluong = Convert.ToInt16(numericUpDown1.Value);
            int tien = dongia * soluong;
            textBox6.Text = tien.ToString();
        }
        private void Showbangchitiethd()
        {
            SqlConnection con = new SqlConnection(sCon);
            con.Open();
            string sMaCTHD = textBox1.Text;
            string sQuery = "select MaH,SoLuongBan,ThanhTien from CHITIET_HD  Where MaCTHD = @MaCTHD";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaCTHD", sMaCTHD);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView2.DataSource = dt;

            dataGridView2.Columns[0].HeaderText = "Mã hàng";
            dataGridView2.Columns[1].HeaderText = "Số lượng bán";
            dataGridView2.Columns[2].HeaderText = "Thành tiền";

            dataGridView2.Columns[0].Width = 150;
            dataGridView2.Columns[1].Width = 150;
            dataGridView2.Columns[2].Width = 160;
            con.Close();
        }
        private void Showbanghd()
        {
            SqlConnection con = new SqlConnection(sCon);
            con.Open();
            string sQuery = "Select * from HOADON";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "HOADON");
            dataGridView1.DataSource = ds.Tables["HOADON"];
            con.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Showbangchitiethd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0 || this.dateTimePicker1.Value == null || this.comboBox1.Text == null ||
                this.comboBox2.Text == null)
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
                string sMaHD = textBox1.Text;
                string sNgayBan = dateTimePicker1.Value.ToString("yyy-MM-dd");
                string sMaNV = comboBox1.Text;
                string sMaKH = comboBox2.Text;
                string sTongCong = textBox2.Text;
                string sQuery2 = " insert into HOADON values(@MaHD, @MaKH, @MaNV,@NgayBan,@TongCong)";
                SqlCommand cmd = new SqlCommand(sQuery2, con);
                cmd.Parameters.AddWithValue("@MaHD", sMaHD);
                cmd.Parameters.AddWithValue("@MaKH", sMaKH);
                cmd.Parameters.AddWithValue("@MaNV", sMaNV);
                cmd.Parameters.AddWithValue("@NgayBan", sNgayBan);
                cmd.Parameters.AddWithValue("@TongCong", sTongCong);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình thêm mới!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Showbanghd();
            }
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
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB!");
            }
            string sMaHD = textBox1.Text;
            string sQuery2 = "delete HOADON where MaHD=@MaHD";
            SqlCommand cmd = new SqlCommand(sQuery2, con);
            cmd.Parameters.AddWithValue("@MaHD", sMaHD);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình xóa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Showbanghd();
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
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB3!");
            }
            string sMaHD = textBox1.Text;
            string sNgayBan = dateTimePicker1.Value.ToString("yyy-MM-dd");
            string sMaNV = comboBox1.Text;
            string sMaKH = comboBox2.Text;
            string sQuery2 = "Update HOADON Set NgayBan = @NgayBan, MaNV = @MaNV, MaKH = @MaKH Where MaHD = @MaHD";
            SqlCommand cmd = new SqlCommand(sQuery2, con);
            cmd.Parameters.AddWithValue("@MaHD", sMaHD);
            cmd.Parameters.AddWithValue("@MaKH", sMaKH);
            cmd.Parameters.AddWithValue("@MaNV", sMaNV);
            cmd.Parameters.AddWithValue("@NgayBan", sNgayBan);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Showbanghd();
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
            string sMaHD = "%" + textBox3.Text + "%";
            string sQuery = "select *from HOADON Where (MaHD) like (@MaHD)";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaHD", sMaHD);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dateTimePicker1.Value = new DateTime(2021, 1, 1);
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox2.Text = "0";
            textBox1.Enabled = true;
            textBox3.Text = "";

            //
            comboBox3.Text = "";
            textBox6.Text = "";
            textBox8.Text = "0";
            numericUpDown1.Text = "0";
            comboBox3.Enabled = true;
            //Bước 1
            SqlConnection con = new SqlConnection(sCon);
            //Bước 2 - lấy dữ liệu về
            Showbanghd();
        }

        
        private void button9_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0 || this.comboBox3.Text == null || this.numericUpDown1.Value == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hoặc chọn Mã hóa đơn!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string sMaCTHD = textBox1.Text;
                string sMaH = comboBox3.Text;
                string sSoLuongBan = numericUpDown1.Text;
                string sThanhTien = textBox6.Text;
                string sQuery2 = " insert into CHITIET_HD values(@MaCTHD, @MaH, @SoLuongBan,@ThanhTien)";
                SqlCommand cmd = new SqlCommand(sQuery2, con);
                cmd.Parameters.AddWithValue("@MaCTHD", sMaCTHD);
                cmd.Parameters.AddWithValue("@MaH", sMaH);
                cmd.Parameters.AddWithValue("@SoLuongBan", sSoLuongBan);
                cmd.Parameters.AddWithValue("@ThanhTien", sThanhTien);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình thêm mới!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ShowHangTonKho();
                Showbanghd();
                Showbangchitiethd();
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
            string sMaCTHD = textBox1.Text;
            string sMaH = comboBox3.Text;
            string sQuery2 = "delete CHITIET_HD where MaCTHD = @MaCTHD and MaH = @MaH";
            SqlCommand cmd = new SqlCommand(sQuery2, con);
            cmd.Parameters.AddWithValue("@MaCTHD", sMaCTHD);
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
            Showbanghd();
            Showbangchitiethd();
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
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB3!");
            }
            string sMaCTHD = textBox1.Text;
            string sMaH = comboBox3.Text;
            string sSoLuongBan = numericUpDown1.Text;
            string sThanhTien = textBox6.Text;
            string sQuery2 = "Update CHITIET_HD Set SoLuongBan = @SoLuongBan,ThanhTien = @ThanhTien Where MaCTHD = @MaCTHD and MaH = @MaH";
            SqlCommand cmd = new SqlCommand(sQuery2, con);
            cmd.Parameters.AddWithValue("@MaCTHD", sMaCTHD);
            cmd.Parameters.AddWithValue("@MaH", sMaH);
            cmd.Parameters.AddWithValue("@SoLuongBan", sSoLuongBan);
            cmd.Parameters.AddWithValue("@ThanhTien", sThanhTien);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowHangTonKho(); 
            Showbanghd();
            Showbangchitiethd();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox3.Text = "";
            textBox6.Text = "";
            textBox8.Text = "0";
            numericUpDown1.Text = "0";
            comboBox3.Enabled = true;
            SqlConnection con = new SqlConnection(sCon);
            //Bước 2 - lấy dữ liệu về
            Showbangchitiethd();
        }

    }

}

