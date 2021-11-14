using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangPhuTung
{
    public partial class frmNhaCC : Form
    {
        string sCon = "Data Source=DESKTOP-BTBDGRO\\SQLEXPRESS;Initial Catalog=CHPT;Integrated Security=True";
        public frmNhaCC()
        {
            InitializeComponent();
        }

        private void frmNhaCC_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sCon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối Database!", "Thông báo");
            }
            string sQuery = "select * from NhaCC";
            SqlDataAdapter adapter= new SqlDataAdapter(sQuery,con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "NhaCC");
            dataGridView1.DataSource = ds.Tables["NhaCC"];
            con.Close();
        }

        }
    }

