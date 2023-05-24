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

namespace CNPM
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=ADMIN\NGAN1605;Initial Catalog=QuanLyTTLLSV;Integrated Security=True");
            if(rdQuanTri.Checked == true)
            {
                try
                {
                    conn.Open();
                    string Tk = txtTK.Text;
                    string Mk = txtMK.Text;
                    string sql = "select * from QuanTri where Id_NV  = '" + Tk + "' and MatKhau = '" + Mk + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read() == true)
                    {
                       
                        TrangChuQL ql = new TrangChuQL();
                        this.Hide();
                        ql.Show();
                    }
                    else
                    {
                        MessageBox.Show("Error", "thong bao", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    }
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi ket noi");
                }
            }

            SqlConnection connn = new SqlConnection(@"Data Source=ADMIN\NGAN1605;Initial Catalog=QuanLyTTLLSV;Integrated Security=True");
            if (rdSV.Checked == true)
            {
                try
                {
                    connn.Open();
                    string Tk = txtTK.Text;
                    string Mk = txtMK.Text;
                    string sql = "select * from SinhVien where Id_SV  = '" + Tk + "' and MatKhau = '" + Mk + "'";
                    SqlCommand cmd = new SqlCommand(sql, connn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read() == true)
                    {

                        TrangChuSV sv = new TrangChuSV();
                        this.Hide();
                        sv.Show();
                    }
                    else
                    {
                        MessageBox.Show("Error", "thong bao", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi ket noi");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
