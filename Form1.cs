using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi07_TinhToan3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtKq.KeyPress += txtKq_KeyPress; // không cho người dùng nhập ký tự vào txtKq
            txtSo1.KeyPress += txtSo1_KeyPress; // không cho người dùng nhập ký tự vào txtSo1
            txtSo2.KeyPress += txtSo2_KeyPress; // không cho người dùng nhập ký tự vào txtSo2
            txtSo1.Text = txtSo2.Text = "0";
            radCong.Checked = true;             //đầu tiên chọn phép cộng
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có thực sự muốn thoát không?",
                                 "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            
            //lấy giá trị của 2 ô số
            double so1, so2, so1Parsed, so2Parsed, kq = 0;
            //so1 = double.TryParse(txtSo1.Text);
            so2 = double.Parse(txtSo2.Text);

            double.TryParse(txtSo1.Text, out so1);
            
            //Thực hiện phép tính dựa vào phép toán được chọn
            if (radCong.Checked) kq = so1 + so2;
            else if (radTru.Checked) kq = so1 - so2;
            else if (radNhan.Checked) kq = so1 * so2;
            else if (radChia.Checked && so2 != 0) kq = so1 / so2;


            /**
             * Thuan
             * fix loi chia cho so 0
             * **/
            else if (radChia.Checked && so2 == 0)
            {
                DialogResult dr;
                dr = MessageBox.Show("Bạn không thể thực hiện phép tính chia cho 0",
                               "Thông báo", MessageBoxButtons.OK);

            }
            //Hiển thị kết quả lên trên ô kết quả
            txtKq.Text = kq.ToString();
        }

        private void txtKq_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtKq_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        //    if ((e.KeyChar > (char)Keys.D9 || e.KeyChar < (char)Keys.D0) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
        //    {
        //        e.Handled = true;
        //    }
        //    //Edit: Alternative
        //    if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
        //    {
        //        e.Handled = true;
        //    }
        
        }
        private void txtSo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            allowNumberOnly(sender, e);
        }
        private void txtSo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            allowNumberOnly(sender, e);
        }
        private void allowNumberOnly(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > (char)Keys.D9 || e.KeyChar < (char)Keys.D0) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            //Edit: Alternative
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
