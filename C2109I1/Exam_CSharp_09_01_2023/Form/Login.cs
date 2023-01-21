using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_CSharp_09_01_2023
{
    public partial class Login : Form
    {
        public static string UserName = "";

        public Login()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Username đang trống nè @@", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
                return;
            }
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["Exam_CSharp_09_01_2023.Properties.Settings.Exam_CSharpConnectionString"].ConnectionString;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Login";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Connection = con;
                UserName = txtUsername.Text;
                object kq = cmd.ExecuteScalar();
                int code = Convert.ToInt32(kq);
                if (code == 1){
                    MessageBox.Show($"Chào mừng {UserName} đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    Admin a = new Admin();
                    a.ShowDialog();
                    this.Close();
                }
                else if (code == 2){
                    MessageBox.Show($"Chào mừng {UserName} đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    Teacher t = new Teacher();
                    t.ShowDialog();
                    this.Close();
                }
                else if (code == 3){
                    MessageBox.Show($"Chào mừng {UserName} đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    Student s = new Student();
                    s.ShowDialog();
                    this.Close();
                }
                else{
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                    txtUsername.Focus(); //đưa con trỏ chuột lại vị trí này
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi khi truy vấn dữ liệu hoặc kết nối thất bại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                con.Close();
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = (char)0;
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
                Application.Exit();
        }
    }
}
