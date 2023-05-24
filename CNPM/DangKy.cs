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
    public partial class DangKy : Form
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
        }
        public DangKy()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            Application.Exit();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
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
            MessageBox.Show("Đăng ký thành công!!");

        }

        private void DangKy_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            TrangChuSV f = new TrangChuSV();
            f.Show();
            this.Hide();
        }
    }
}
