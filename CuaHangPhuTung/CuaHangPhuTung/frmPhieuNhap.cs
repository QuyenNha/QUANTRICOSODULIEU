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
    public partial class frmPhieuNhap : Form
    {
        string sCon = @"Data Source=DESKTOP-9QSGK01;Initial Catalog=CHPT;Integrated Security=True";
        public frmPhieuNhap()
        {
            InitializeComponent();
        }
        private void frmPhieuNhap_Load_1(object sender, EventArgs e)
        {
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
            string sQuery = "Select * from PHIEUNHAP";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "PHIEUNHAP");

            dataGridView1.DataSource = ds.Tables["PHIEUNHAP"];
            dataGridView1.Columns[0].HeaderText = "Mã phiếu nhập hàng";
            dataGridView1.Columns[1].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[2].HeaderText = "Mã nhà cung cấp";
            dataGridView1.Columns[3].HeaderText = "Ngày nhập";
            dataGridView1.Columns[4].HeaderText = "VAT";
            dataGridView1.Columns[5].HeaderText = "Tổng tiền";
            dataGridView1.Columns[6].HeaderText = "Tổng cộng";
            string sql = "Select * from NHANVIEN";
            comboBox1.DataSource = Database.Singleton.LoadData(sql);
            comboBox1.DisplayMember = "MaNV";
            string sql1 = "select * from NhaCC";
            comboBox2.DataSource = Database.Singleton.LoadData(sql1);
            comboBox2.DisplayMember = "MaNCC";

            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 145;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 120;
            dataGridView1.Columns[6].Width = 150;

            string sql2 = "Select * from HANG";
            comboBox3.DataSource = Database.Singleton.LoadData(sql2);
            comboBox3.DisplayMember = "MaH";


            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["MaPNH"].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["MaNCC"].Value.ToString();
            numericUpDown2.Text = dataGridView1.Rows[e.RowIndex].Cells["VAT"].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["TongTien"].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["TongCong"].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["NgayNhap"].Value);
            textBox1.Enabled = false;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox3.Text = dataGridView2.Rows[e.RowIndex].Cells["MaH"].Value.ToString();
            numericUpDown1.Text = dataGridView2.Rows[e.RowIndex].Cells["SoLuongNhap"].Value.ToString();
            textBox9.Text = dataGridView2.Rows[e.RowIndex].Cells["ThanhTien"].Value.ToString();
            textBox9.Enabled = false;
            comboBox3.Enabled = false;
        }
        private void ShowbangchitietPNH()
        {
            SqlConnection con = new SqlConnection(sCon);
            con.Open();
            string sMaCTPNH = textBox1.Text;
            string sQuery = "select MaH,SoLuongNhap,ThanhTien from CHITIET_PN  Where MaCTPNH = @MaCTPNH";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaCTPNH", sMaCTPNH);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView2.DataSource = dt;

            dataGridView2.Columns[0].HeaderText = "Mã hàng";
            dataGridView2.Columns[1].HeaderText = "Số lượng bán";
            dataGridView2.Columns[2].HeaderText = "Thành tiền";

            dataGridView2.Columns[0].Width = 160;
            dataGridView2.Columns[1].Width = 160;
            dataGridView2.Columns[2].Width = 160;
            con.Close();
        }
        private void ShowbangPN()
        {
            SqlConnection con = new SqlConnection(sCon);
            con.Open();
            string sQuery = "Select * from PHIEUNHAP";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "PHIEUNHAP");
            dataGridView1.DataSource = ds.Tables["PHIEUNHAP"];
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ShowbangchitietPNH();
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

            string sQuery1 = "select MaH,Dongianhap from hang";
            SqlDataAdapter adapter1 = new SqlDataAdapter(sQuery1, con);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1, "MaHang");
            textBox8.Text = ds1.Tables["MaHang"].Rows[comboBox3.SelectedIndex]["Dongianhap"].ToString();
            con.Close();// đóng kết nối 


            int dongia = Convert.ToInt32(textBox8.Text);
            int soluong = Convert.ToInt32(numericUpDown1.Value);
            int tien = dongia * soluong;
            textBox9.Text = tien.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int dongia = Convert.ToInt32(textBox8.Text);
            int soluong = Convert.ToInt16(numericUpDown1.Value);
            int tien = dongia * soluong;
            textBox9.Text = tien.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0 || this.dateTimePicker1.Value == null || this.comboBox1.Text == null ||
                this.comboBox2.Text == null || this.numericUpDown2.Value == 0)
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
                string sMaPNH = textBox1.Text;
                string sNgayNhap = dateTimePicker1.Value.ToString("yyy-MM-dd");
                string sMaNV = comboBox1.Text;
                string sMaNCC = comboBox2.Text;
                string sVAT = numericUpDown2.Text;
                string sTongTien = textBox5.Text;
                string sTongCong = textBox6.Text;
                string sQuery2 = " insert into PHIEUNHAP values(@MaPNH, @MaNV, @MaNCC,@NgayNhap,@VAT, @TongTien, @TongCong)";
                SqlCommand cmd = new SqlCommand(sQuery2, con);
                cmd.Parameters.AddWithValue("@MaPNH", sMaPNH);
                cmd.Parameters.AddWithValue("@MaNV", sMaNV);
                cmd.Parameters.AddWithValue("@MaNCC", sMaNCC);
                cmd.Parameters.AddWithValue("@NgayNhap", sNgayNhap);
                cmd.Parameters.AddWithValue("@VAT", sVAT);
                cmd.Parameters.AddWithValue("@TongTien", sTongTien);
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
                ShowbangPN();
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
            string sMaPNH = textBox1.Text;
            string sQuery2 = "delete PHIEUNHAP where MaPNH=@MaPNH";
            SqlCommand cmd = new SqlCommand(sQuery2, con);
            cmd.Parameters.AddWithValue("@MaPNH", sMaPNH);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình xóa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowbangPN();
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
            string sMaPNH = textBox1.Text;
            string sNgayNhap = dateTimePicker1.Value.ToString("yyy-MM-dd");
            string sMaNV = comboBox1.Text;
            string sMaNCC = comboBox2.Text;
            string sVAT = numericUpDown2.Text;
            string sTongCong = textBox6.Text;
            string sQuery2 = "Update PHIEUNHAP Set MaNV=@MaNV,MaNCC=@MaNCC,NgayNhap=@NgayNhap,VAT=@VAT,TongCong=@TongCong Where MaPNH = @MaPNH";
            SqlCommand cmd = new SqlCommand(sQuery2, con);
            cmd.Parameters.AddWithValue("@MaPNH", sMaPNH);
            cmd.Parameters.AddWithValue("@MaNV", sMaNV);
            cmd.Parameters.AddWithValue("@MaNCC", sMaNCC);
            cmd.Parameters.AddWithValue("@NgayNhap", sNgayNhap);
            cmd.Parameters.AddWithValue("@VAT", sVAT);
            cmd.Parameters.AddWithValue("@TongCong", sTongCong);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowbangPN();
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
            string sMaPNH = "%" + textBox7.Text + "%";
            string sQuery = "select *from PHIEUNHAP Where (MaPNH) like (@MaPNH)";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, con);
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.Parameters.AddWithValue("@MaPNH", sMaPNH);
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
            numericUpDown2.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox1.Enabled = true;
            textBox7.Text = "";

            //
            comboBox3.Text = "";
            textBox9.Text = "";
            textBox8.Text = "0";
            numericUpDown1.Text = "0";
            comboBox3.Enabled = true;
            //Bước 1
            SqlConnection con = new SqlConnection(sCon);
            //Bước 2 - lấy dữ liệu về
            ShowbangPN();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0 || this.comboBox3.Text == null || this.numericUpDown1.Value == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hoặc chọn Mã phiếu nhập!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string sMaCTPNH = textBox1.Text;
                string sMaH = comboBox3.Text;
                string sSoLuongNhap = numericUpDown1.Text;
                string sThanhTien = textBox9.Text;
                string sQuery2 = " insert into CHITIET_PN values(@MaCTPNH, @MaH, @SoLuongNhap,@ThanhTien)";
                SqlCommand cmd = new SqlCommand(sQuery2, con);
                cmd.Parameters.AddWithValue("@MaCTPNH", sMaCTPNH);
                cmd.Parameters.AddWithValue("@MaH", sMaH);
                cmd.Parameters.AddWithValue("@SoLuongNhap", sSoLuongNhap);
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
                ShowbangchitietPNH();
                ShowbangPN();
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
            string sMaCTPNH = textBox1.Text;
            string sMaH = comboBox3.Text;
            string sQuery2 = "delete CHITIET_PN where MaCTPNH = @MaCTPNH and MaH = @MaH";
            SqlCommand cmd = new SqlCommand(sQuery2, con);
            cmd.Parameters.AddWithValue("@MaCTPNH", sMaCTPNH);
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
            ShowbangchitietPNH();
            ShowbangPN();
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
            string sMaCTPNH = textBox1.Text;
            string sMaH = comboBox3.Text;
            string sSoLuongNhap = numericUpDown1.Text;
            string sThanhTien = textBox9.Text;
            string sQuery2 = "Update CHITIET_PN Set SoLuongNhap = @SoLuongNhap,ThanhTien = @ThanhTien Where MaCTPNH = @MaCTPNH and MaH = @MaH";
            SqlCommand cmd = new SqlCommand(sQuery2, con);
            cmd.Parameters.AddWithValue("@MaCTPNH", sMaCTPNH);
            cmd.Parameters.AddWithValue("@MaH", sMaH);
            cmd.Parameters.AddWithValue("@SoLuongNhap", sSoLuongNhap);
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
            ShowbangchitietPNH();
            ShowbangPN();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            comboBox3.Text = "";
            textBox9.Text = "";
            textBox8.Text = "0";
            numericUpDown1.Text = "0";
            comboBox3.Enabled = true;
            SqlConnection con = new SqlConnection(sCon);
            //Bước 2 - lấy dữ liệu về
            ShowbangchitietPNH();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int VAT = Convert.ToInt32(numericUpDown2.Value);
            int Tongtien = Convert.ToInt32(textBox5.Text);
            int tien = (Tongtien * VAT / 100) + Tongtien; ;
            textBox6.Text = tien.ToString();
        }

    }
}
