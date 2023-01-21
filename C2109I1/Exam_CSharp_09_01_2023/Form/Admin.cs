using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Text.RegularExpressions;

namespace Exam_CSharp_09_01_2023
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();

        private async void Admin_Load(object sender, EventArgs e)
        {
            using (var ef = new Exam_CSharpEntities()) //same try catch, sài xong entity thì giết luôn
            {
                bindingSource1.DataSource = await ef.tblStudents.Select(stu => new
                {//khai báo tên trường cần show
                    stu.stuId,
                    stu.stuUsername,
                    stu.stuName,
                    stu.stuPhone,
                    stu.stuEmail,
                    stu.stuLevel
                }).ToListAsync(); //load đa luồng <= sài thèn này
                bindingNavigator1.BindingSource = bindingSource1;
                table.DataSource = bindingSource1;

                txtStuId.DataBindings.Clear();
                txtUsername.DataBindings.Clear();
                txtStuName.DataBindings.Clear();
                txtPhone.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtLevel.DataBindings.Clear();
                txtSearch.Text = string.Empty;

                txtStuId.DataBindings.Add("Text", bindingSource1, "stuId", true, DataSourceUpdateMode.OnPropertyChanged);
                txtUsername.DataBindings.Add("Text", bindingSource1, "stuUsername", true, DataSourceUpdateMode.OnPropertyChanged);
                txtStuName.DataBindings.Add("Text", bindingSource1, "stuName", true, DataSourceUpdateMode.OnPropertyChanged);
                txtPhone.DataBindings.Add("Text", bindingSource1, "stuPhone", true, DataSourceUpdateMode.OnPropertyChanged);
                txtEmail.DataBindings.Add("Text", bindingSource1, "stuEmail", true, DataSourceUpdateMode.OnPropertyChanged);
                txtLevel.DataBindings.Add("Text", bindingSource1, "stuLevel", true, DataSourceUpdateMode.OnPropertyChanged);
            }
        }

        private async void toolStripButton2_Click(object sender, EventArgs e)
        {//update
            try //check username have exists ?
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["Exam_CSharp_09_01_2023.Properties.Settings.Exam_CSharpConnectionString"].ConnectionString;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "CheckUpdateUsername";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Connection = con;

                object kq = cmd.ExecuteScalar();
                int check = Convert.ToInt32(kq);
                if (check == 2) //account not exists
                {
                    using (var ef = new Exam_CSharpEntities())
                    {
                        var id = Convert.ToInt32(txtStuId.Text);
                        var obj = await ef.tblStudents.FirstOrDefaultAsync(i => i.stuId == id);
                        if (obj != null)
                        {
                            if (txtUsername.Text == "")
                            {
                                MessageBox.Show("Bạn quên chưa nhập nội dung rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtUsername.Focus();
                                return;
                            }

                            if (txtLevel.Text == "")
                            {
                                MessageBox.Show("Bạn quên chưa nhập nội dung rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtLevel.Focus();
                                return;
                            }

                            if (!Regex.Match(txtUsername.Text, ValidateAll.ACC).Success)
                            {//không hợp lệ thì
                                MessageBox.Show("Username không hợp lệ: (8-25 character)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (!Regex.Match(txtLevel.Text, ValidateAll.NUM).Success)
                            {//không hợp lệ thì
                                MessageBox.Show("Level không hợp lệ: (1-3)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            obj.stuUsername = txtUsername.Text;
                            obj.stuLevel = (byte?)Convert.ToInt32(txtLevel.Text);
                        }
                        //xong hết update về db
                        await ef.SaveChangesAsync();
                        bindingSource1.DataSource = await ef.tblStudents.Select(stu => new
                        {
                            stu.stuId,
                            stu.stuUsername,
                            stu.stuName,
                            stu.stuPhone,
                            stu.stuEmail,
                            stu.stuLevel
                        }).ToListAsync(); //load đa luồng <= sài thèn này
                        MessageBox.Show("Success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Admin_Load(sender, e);
                    }
                }
                else //account exists
                {
                    MessageBox.Show("Update thất bại do Username đã tồn tại trong hệ thống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async void toolStripButton3_Click(object sender, EventArgs e)
        {//delete
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
                if (check != Convert.ToInt32(txtLevel.Text))
                {
                    DialogResult dg = MessageBox.Show("Bạn có chắn chắn muốn xóa ? Bạn sẽ không thể hoàn tác !!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dg == DialogResult.Yes)
                    {
                        using (var ef = new Exam_CSharpEntities())
                        {
                            var id = Convert.ToInt32(txtStuId.Text);
                            foreach (var stu1 in ef.tblStudents)
                            {
                                if (stu1.stuId == id)
                                {
                                    ef.tblStudents.Remove(stu1);
                                }
                            }
                            await ef.SaveChangesAsync();
                            bindingSource1.DataSource = await ef.tblStudents.Select(stu => new
                            {
                                stu.stuId,
                                stu.stuUsername,
                                stu.stuName,
                                stu.stuPhone,
                                stu.stuEmail,
                                stu.stuLevel
                            }).ToListAsync(); //load đa luồng <= sài thèn này
                            MessageBox.Show("Success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Admin_Load(sender, e);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền xóa admin này !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private async void toolStripButton1_Click(object sender, EventArgs e)
        {//send password by gmail
            try
            {
                var randomPass = RandomString(8);
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("tanchau0602@gmail.com");
                mail.To.Add($"{txtEmail.Text}");
                mail.Subject = "Your password";
                mail.Body = $"Hello {txtStuName.Text}" +
                    $"\nThis is your username: {txtUsername.Text}" +
                    $"\nAnd this is your password: {randomPass}";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("tanchau0602@gmail.com", "suhqecqjaquuvluj");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Gửi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                using (var ef = new Exam_CSharpEntities())
                {
                    var id = Convert.ToInt32(txtStuId.Text);
                    var obj = await ef.tblStudents.FirstOrDefaultAsync(i => i.stuId == id);
                    if (obj != null)
                    {
                        obj.stuPass = randomPass;
                    }
                    //xong hết update về db
                    await ef.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {//search
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["Exam_CSharp_09_01_2023.Properties.Settings.Exam_CSharpConnectionString"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                using (DataTable dt = new DataTable("tblStudent"))
                {
                    using (SqlCommand cmd = new SqlCommand("select stuId,stuUsername,stuName,stuPhone,stuEmail,stuLevel from tblStudent where stuUsername like @stuUsername or stuId like @stuUsername", con))
                    {
                        cmd.Parameters.AddWithValue("stuUsername", string.Format("%{0}%", txtSearch.Text));
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        table.DataSource = dt;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi khi truy vấn dữ liệu hoặc kết nối thất bại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {//get data when click in table
            if (e.RowIndex != -1) //ngăn lỗi click trên collumn
            {
                txtStuId.Text = table.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtUsername.Text = table.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtStuName.Text = table.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPhone.Text = table.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtEmail.Text = table.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtLevel.Text = table.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePass a = new ChangePass();
            a.ShowDialog();
            this.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {//sign out
            DialogResult dg = MessageBox.Show("Bạn có muốn đăng xuất khỏi tài khoản hiện tại ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Hide();
                Login a = new Login();
                a.ShowDialog();
                this.Close();
            }
        }
    }
}
