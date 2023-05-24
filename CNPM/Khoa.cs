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
    public partial class Khoa : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=ADMIN\NGAN1605;Initial Catalog=QuanLyTTLLSV;Integrated Security=True");
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Khoa";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvKhoa.DataSource = table;
        }
        public Khoa()
        {
            InitializeComponent();
        }

        private void Khoa_Load(object sender, EventArgs e)
        {
            connection.Open();
            loaddata();
        }

        private void dgvKhoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                int i = dgvKhoa.CurrentRow.Index;
                txtMaKhoa.Text = dgvKhoa.Rows[i].Cells[0].Value.ToString();
                txtTenkhoa.Text = dgvKhoa.Rows[i].Cells[1].Value.ToString();
                txtSoluong.Text = dgvKhoa.Rows[i].Cells[2].Value.ToString();
                txtTruongkhoa.Text = dgvKhoa.Rows[i].Cells[3].Value.ToString();
            }
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Khoa VALUES('" + txtMaKhoa.Text + "', '" + txtTenkhoa.Text + "', " +
                "'" + txtSoluong.Text + "', '" + txtTruongkhoa.Text + "')";
            command.ExecuteNonQuery();
            loaddata();
            txtMaKhoa.Text = "";
            txtTenkhoa.Text = "";
            txtSoluong.Text = "";
            txtTruongkhoa.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "UPDATE Khoa SET TenKhoa = '" + txtTenkhoa.Text + "', SoLop = '" + txtSoluong.Text + "'," +
                " TruongKhoa = '" + txtTruongkhoa.Text + "' WHERE Id_Khoa = '" + txtMaKhoa.Text + "' ";
            command.ExecuteNonQuery();
            loaddata();
            txtMaKhoa.Text = "";
            txtTenkhoa.Text = "";
            txtSoluong.Text = "";
            txtTruongkhoa.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Delete Khoa WHERE Id_Khoa = '" + txtMaKhoa.Text + "' ";
            command.ExecuteNonQuery();
            loaddata();
            txtMaKhoa.Text = "";
            txtTenkhoa.Text = "";
            txtSoluong.Text = "";
            txtTruongkhoa.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            Application.Exit();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Khoa WHERE Id_Khoa ='" + txtMaKhoa.Text + "'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvKhoa.DataSource = table;
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
