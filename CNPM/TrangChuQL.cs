using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM
{
    public partial class TrangChuQL : Form
    {
        public TrangChuQL()
        {
            InitializeComponent();
        }

        private void quảnLýThôngTinLiênLạcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyThongTinLienLac f = new QuanLyThongTinLienLac();
            f.Show();
            this.Hide();
        }

        private void quảnLýThôngTinLớpHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyThongTinLopHoc f = new QuanLyThongTinLopHoc();
            f.Show();
            this.Hide();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            DangNhap f = new DangNhap();
            f.Show();
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Khoa f = new Khoa();
            f.Show();
            this.Hide();
        }
    }
}
