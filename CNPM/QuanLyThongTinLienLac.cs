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
    public partial class QuanLyThongTinLienLac : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=ADMIN\NGAN1605;Initial Catalog=QuanLyTTLLSV;Integrated Security=True");
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from ThongTinSinhVien";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvQLTTSV.DataSource = table;
        }
        public QuanLyThongTinLienLac()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            Application.Exit();
        }

        private void dgvQLTTSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvQLTTSV.CurrentRow.Index;
            txtMaSV.Text = dgvQLTTSV.Rows[i].Cells[0].Value.ToString();
            txtMaLop.Text = dgvQLTTSV.Rows[i].Cells[1].Value.ToString();
            txtHoTen.Text = dgvQLTTSV.Rows[i].Cells[2].Value.ToString();
            txtNgaySinh.Text = dgvQLTTSV.Rows[i].Cells[3].Value.ToString();
            cbGioiTinh.Text = dgvQLTTSV.Rows[i].Cells[4].Value.ToString();
            txtSDT.Text = dgvQLTTSV.Rows[i].Cells[5].Value.ToString();
            txtEmail.Text = dgvQLTTSV.Rows[i].Cells[6].Value.ToString();
            txtLop.Text = dgvQLTTSV.Rows[i].Cells[7].Value.ToString();
            txtNgayVaoDoan.Text = dgvQLTTSV.Rows[i].Cells[8].Value.ToString();
            txtNoiVao.Text = dgvQLTTSV.Rows[i].Cells[9].Value.ToString();
            txtDiaChi.Text = dgvQLTTSV.Rows[i].Cells[10].Value.ToString();
            txtNoiSinh.Text = dgvQLTTSV.Rows[i].Cells[11].Value.ToString();
            txtNgayVaoTruong.Text = dgvQLTTSV.Rows[i].Cells[12].Value.ToString();
            txtNgayDi.Text = dgvQLTTSV.Rows[i].Cells[13].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO ThongTinSinhVien VALUES('" + txtMaSV.Text + "','" + txtMaLop.Text + "', '" + txtHoTen.Text + "', '" + txtNgaySinh.Text + "', '" + cbGioiTinh.Text + "', '" + txtSDT.Text + "', '" + txtEmail.Text + "', '" + txtLop.Text + "', '" + txtNgayVaoDoan.Text + "','" + txtNoiVao.Text + "', '" + txtDiaChi.Text + "', '" + txtNoiSinh.Text + "','" + txtNgayVaoTruong.Text + "', '" + txtNgayDi.Text + "')";
            command.ExecuteNonQuery();
            loaddata();
            txtMaSV.Text = "";
            txtMaLop.Text = "";
            txtHoTen.Text = "";
            txtNgaySinh.Text = "";
            cbGioiTinh.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtLop.Text = "";
            txtNgayVaoDoan.Text = "";
            txtNoiVao.Text = "";
            txtDiaChi.Text = "";
            txtNoiSinh.Text = "";
            txtNgayVaoTruong.Text = "";
            txtNgayDi.Text = "";
        }

        private void QuanLyThongTinLienLac_Load(object sender, EventArgs e)
        {
            connection.Open();
            loaddata();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "UPDATE ThongTinSinhVien SET Id_Lop = '" + txtMaLop.Text + "', HoTenSV = '" + txtHoTen.Text + "', NgaySinh = '" + txtNgaySinh.Text + "', GioiTinh = '" + cbGioiTinh.Text + "', SoDienThoai = '" + txtSDT.Text + "', " +
            "Email = '" + txtEmail.Text + "', Lop = '" + txtLop.Text + "', NgayVaoDoan = '" + txtNgayVaoDoan.Text + "', NoiVaoDoan = '" + txtNoiVao.Text + "', DiaChiHienTai = '" + txtDiaChi.Text + "', NoiSinh ='" + txtNoiSinh.Text + "', " +
            "NgayVaoTruong ='" + txtNgayVaoTruong.Text + "', NgayDi ='" + txtNgayDi.Text + "'  where Id_SV = '" + txtMaSV.Text + "'";
            command.ExecuteNonQuery();
            loaddata();
            txtMaSV.Text = "";
            txtMaLop.Text = "";
            txtHoTen.Text = "";
            txtNgaySinh.Text = "";
            cbGioiTinh.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtLop.Text = "";
            txtNgayVaoDoan.Text = "";
            txtNoiVao.Text = "";
            txtDiaChi.Text = "";
            txtNoiSinh.Text = "";
            txtNgayVaoTruong.Text = "";
            txtNgayDi.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "DELETE FROM ThongTinSinhVien WHERE Id_SV ='" + txtMaSV.Text + "'";
            command.ExecuteNonQuery();
            loaddata();
            txtMaSV.Text = "";
            txtMaLop.Text = "";
            txtHoTen.Text = "";
            txtNgaySinh.Text = "";
            cbGioiTinh.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtLop.Text = "";
            txtNgayVaoDoan.Text = "";
            txtNoiVao.Text = "";
            txtDiaChi.Text = "";
            txtNoiSinh.Text = "";
            txtNgayVaoTruong.Text = "";
            txtNgayDi.Text = "";
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM ThongTinSinhVien WHERE Id_SV ='" + txtMaSV.Text + "'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvQLTTSV.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrangChuQL f = new TrangChuQL();
            f.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtMaLop_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtNgayVaoTruong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNgayVaoDoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNgayDi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNoiSinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNoiVao_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLop_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNgaySinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
