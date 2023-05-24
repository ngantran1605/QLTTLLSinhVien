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
    public partial class QuanLyThongTinLopHoc : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=ADMIN\NGAN1605;Initial Catalog=QuanLyTTLLSV;Integrated Security=True");
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();


        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from LopHoc";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvQLLH.DataSource = table;
        }
        public QuanLyThongTinLopHoc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrangChuQL f = new TrangChuQL();
            f.Show();
            this.Hide();
        }

        private void QuanLyThongTinLopHoc_Load(object sender, EventArgs e)
        {
            connection.Open();
            loaddata();
        }

        private void dgvQLLH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                int i = dgvQLLH.CurrentRow.Index;
                txtMaLop.Text = dgvQLLH.Rows[i].Cells[0].Value.ToString();
                txtMaKhoa.Text = dgvQLLH.Rows[i].Cells[1].Value.ToString();
                txtTenLop.Text = dgvQLLH.Rows[i].Cells[2].Value.ToString();
                txtTenGV.Text = dgvQLLH.Rows[i].Cells[3].Value.ToString();
                txtSDTGV.Text = dgvQLLH.Rows[i].Cells[4].Value.ToString();
                txtEmailGV.Text = dgvQLLH.Rows[i].Cells[5].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO LopHoc VALUES('" + txtMaLop.Text + "', '" + txtMaKhoa.Text + "', " +
                "'" + txtTenLop.Text + "', '" + txtTenGV.Text + "', '" + txtSDTGV.Text + "', '" + txtEmailGV.Text + "')";
            command.ExecuteNonQuery();
            loaddata();
            txtMaLop.Text = "";
            txtMaKhoa.Text = "";
            txtTenLop.Text = "";
            txtTenGV.Text = "";
            txtSDTGV.Text = "";
            txtEmailGV.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "UPDATE LopHoc SET Id_Khoa = '" + txtMaKhoa.Text + "', TenLop = '" + txtTenLop.Text + "', TenGV = '" + txtTenGV.Text + "'," +
                " SoDienThoaiGV = '" + txtSDTGV.Text + "',EmailGV = '" + txtEmailGV.Text + "' WHERE Id_Lop = '" + txtMaLop.Text + "' ";
            command.ExecuteNonQuery();
            loaddata();
            txtMaLop.Text = "";
            txtMaKhoa.Text = "";
            txtTenLop.Text = "";
            txtTenGV.Text = "";
            txtSDTGV.Text = "";
            txtEmailGV.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "DELETE FROM LopHoc WHERE Id_Lop ='" + txtMaLop.Text + "'";
            command.ExecuteNonQuery();
            loaddata();
            txtMaLop.Text = "";
            txtMaKhoa.Text = "";
            txtTenLop.Text = "";
            txtTenGV.Text = "";
            txtSDTGV.Text = "";
            txtEmailGV.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            Application.Exit();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM LopHoc WHERE Id_Lop ='" + txtMaLop.Text + "'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvQLLH.DataSource = table;
        }
    }
}
