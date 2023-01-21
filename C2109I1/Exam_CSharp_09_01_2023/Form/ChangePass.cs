using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_CSharp_09_01_2023
{
    public partial class ChangePass : Form
    {
        public ChangePass()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();

        private void btnReturn_Click(object sender, EventArgs e)
        {//check username's level
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["Exam_CSharp_09_01_2023.Properties.Settings.Exam_CSharpConnectionString"].ConnectionString;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "CheckLevelForm";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", Login.UserName);
                cmd.Connection = con;

                object kq = cmd.ExecuteScalar();
                int check = Convert.ToInt32(kq);
                if (check == 1)
                {
                    this.Hide();
                    Admin a = new Admin();
                    a.ShowDialog();
                    this.Close();
                }
                else if (check == 2)
                {
                    this.Hide();
                    Teacher t = new Teacher();
                    t.ShowDialog();
                    this.Close();
                }
                else if (check == 3)
                {
                    this.Hide();
                    Student t = new Student();
                    t.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi truy vấn dữ liệu hoặc kết nối thất bại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi khi truy vấn dữ liệu hoặc kết nối thất bại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtOldPass.PasswordChar = (char)0;
                txtPasswordNew.PasswordChar = (char)0;
                txtPasswordCheck.PasswordChar = (char)0;
            }
            else
            {
                txtOldPass.PasswordChar = '*';
                txtPasswordNew.PasswordChar = '*';
                txtPasswordCheck.PasswordChar = '*';
            }
        }

        private async void btnSub_Click(object sender, EventArgs e)
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["Exam_CSharp_09_01_2023.Properties.Settings.Exam_CSharpConnectionString"].ConnectionString;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "CheckAccount";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", Login.UserName);
                cmd.Parameters.AddWithValue("@Password", txtOldPass.Text);
                cmd.Connection = con;

                object kq = cmd.ExecuteScalar();
                int check = Convert.ToInt32(kq);
                if (check == 1) //account exists
                {
                    if (!Regex.Match(txtPasswordNew.Text, ValidateAll.PASS).Success)
                    {//không hợp lệ thì
                        MessageBox.Show("Password mới không hợp lệ: (6-25 ký tự và có ít nhất 1 chữ thường, 1 chữ HOA, 1 ký tự đặt biệt và 1 con số)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (txtPasswordNew.Text.Equals(txtPasswordCheck.Text))
                    {
                        using (var ef = new Exam_CSharpEntities())
                        {
                            var acc = Login.UserName;
                            var obj = await ef.tblStudents.FirstOrDefaultAsync(i => i.stuUsername == acc);
                            if (obj != null)
                            {
                                obj.stuPass = txtPasswordNew.Text;
                            }
                            //xong hết update về db
                            await ef.SaveChangesAsync();

                            MessageBox.Show("Cập nhật mật khẩu mới thành công", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtOldPass.Text = "";
                            txtPasswordNew.Text = "";
                            txtPasswordCheck.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới không trùng nhau !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    txtOldPass.Text = "";
                    MessageBox.Show("Mật khẩu cũ không đúng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi khi truy vấn dữ liệu hoặc kết nối thất bại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
