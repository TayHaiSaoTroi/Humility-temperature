using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoluongcambienForm
{
    public partial class Formdangnhap : Form
    {
        public Formdangnhap()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            txtTentaikhoan.Focus();
            txtMatkhau.Focus();
            txtMatkhau.Focus();
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có chắc muốn thoát hông đó ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            Form1 fm1 = new Form1();
            if (tb == DialogResult.OK)
            {
                fm1.Show();
            }
            this.Hide();
            Formdangnhap fm2 = new DoluongcambienForm.Formdangnhap();
            if (tb == DialogResult.Cancel)
            {
                fm2.Show();
            }

        }
        private void dangnhap()
        {
            if (txtTentaikhoan.Text.Length == 0 && txtMatkhau.Text.Length == 0 && txtMasosinhvien .Text .Length ==0)
                MessageBox.Show("Bạn chưa điền thông tin theo yêu cầu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if (txtTentaikhoan.Text.Length == 0)
                MessageBox.Show("Bạn chưa điền thông tin đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if (txtMasosinhvien.Text.Length == 0)
                MessageBox.Show(" Bạn chưa điền thông tin mã số sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if (txtMatkhau.Text.Length == 0)
                MessageBox.Show("Bạn chưa điền thông tin mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if (txtTentaikhoan.Text == "MinhTan" && txtMasosinhvien.Text == "18118125" && txtMatkhau.Text == "18118125")
                MessageBox.Show("Đăng nhập thành công");
            else
                MessageBox.Show("Mật khẩu sai");
        }

        private void dangnhapbtn_Click(object sender, EventArgs e)
        {
            Form2 fm3 = new Form2();
            if (this.txtTentaikhoan.Text == "MinhTan" && this.txtMasosinhvien.Text == "18118125" && this.txtMatkhau.Text == "18118125")
            {
                fm3.Show();
            }
            dangnhap();
            this.Close();
        }

        private void txtMatkhau_TextChanged(object sender, EventArgs e)
        {
            this.txtMatkhau.PasswordChar = '*';
        }

        private void txtTentaikhoan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
