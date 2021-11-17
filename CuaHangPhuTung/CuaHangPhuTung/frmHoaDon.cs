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
        string sCon = @"Data Source=DESKTOP-EFQDFTG\SQLEXPRESS;Initial Catalog=CHPT;Integrated Security=True";
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

            string sQuery1 = "Select * from CHITIET_HD";
            SqlDataAdapter adapter1 = new SqlDataAdapter(sQuery1, con);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1, "CHITIET_HD");

            dataGridView2.DataSource = ds1.Tables["CHITIET_HD"];
            dataGridView2.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridView2.Columns[1].HeaderText = "Mã hàng";
            dataGridView2.Columns[2].HeaderText = "Số lượng bán";
            dataGridView2.Columns[3].HeaderText = "Thành tiền";
            string sql2 = "Select * from HANG";
            comboBox3.DataSource = Database.Singleton.LoadData(sql2);
            comboBox3.DisplayMember = "MaH";

            dataGridView2.Columns[0].Width = 150;
            dataGridView2.Columns[1].Width = 150;
            dataGridView2.Columns[2].Width = 150;
            dataGridView2.Columns[3].Width = 140;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["TongCong"].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["NgayBan"].Value);
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells["MaCTHD"].Value.ToString();
            comboBox3.Text = dataGridView2.Rows[e.RowIndex].Cells["MaH"].Value.ToString();
            numericUpDown1.Text = dataGridView2.Rows[e.RowIndex].Cells["SoLuongBan"].Value.ToString();
            textBox6.Text = dataGridView2.Rows[e.RowIndex].Cells["ThanhTien"].Value.ToString();
            textBox4.Enabled = false;
            textBox6.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.textBox4.TextLength == 0 || this.comboBox3.Text == null || this.textBox6.TextLength == 0)
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
                string sMaHD = textBox4.Text;
                string sMaH = comboBox3.Text;
                string sThanhTien = textBox6.Text;
                string sSoLuongBan = numericUpDown1.Text;
                string sQuery2 = " insert into CHITIET_HD values(@MaHD, @MaH, @ThanhTien,@SoLuongBan)";
                SqlCommand cmd = new SqlCommand(sQuery2, con);
                cmd.Parameters.AddWithValue("@MaHD", sMaHD);
                cmd.Parameters.AddWithValue("@MaH", sMaH);
                cmd.Parameters.AddWithValue("@ThanhTien", sThanhTien);
                cmd.Parameters.AddWithValue("@SoLuongBan", sSoLuongBan);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã hóa đơn đà tồn tại!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string sQuery3 = "Select * from CHITIET_HD";
                SqlDataAdapter adapter = new SqlDataAdapter(sQuery3, con);

                DataSet ds = new DataSet();

                adapter.Fill(ds, "CHITIET_HD");

                dataGridView2.DataSource = ds.Tables["CHITIET_HD"];
                con.Close();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }

}

