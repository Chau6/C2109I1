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
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();

        private void Teacher_Load(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Exam_CSharp_09_01_2023.Properties.Settings.Exam_CSharpConnectionString"].ConnectionString;
            command.Connection = con;
            command.CommandText = "select tblStudent.stuId,stuName,stuGender,stuDob,stuAddress,stuPhone,stuEmail,deptId,couName,couSemester,examName,examMark,examDate,tblCourse.couId from tblStudent left join tblExam on tblStudent.stuId = tblExam.stuId left join tblCourse on tblCourse.couId = tblExam.couId where tblStudent.stuId = tblExam.stuId or tblExam.stuId is null and stuLevel = 3 order by tblStudent.stuId";
            command.CommandType = CommandType.Text;

            adapter.SelectCommand = command;
            ds.Tables.Clear();
            adapter.Fill(ds);

            bindingSource1.DataSource = ds.Tables[0];
            table.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;

            txtId.DataBindings.Clear();
            txtName.DataBindings.Clear();
            rdbMale.DataBindings.Clear();
            dob.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtDeptId.DataBindings.Clear();
            txtCouName.DataBindings.Clear();
            txtCouSemester.DataBindings.Clear();
            txtExamName.DataBindings.Clear();
            txtExamMark.DataBindings.Clear();
            examDate.DataBindings.Clear();
            txtCouId.DataBindings.Clear();
            txtSearch.Text = string.Empty;

            txtId.DataBindings.Add("Text", bindingSource1, "stuId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtName.DataBindings.Add("Text", bindingSource1, "stuName", true, DataSourceUpdateMode.OnPropertyChanged);
            rdbMale.DataBindings.Add("Checked", bindingSource1, "stuGender", true, DataSourceUpdateMode.OnPropertyChanged);
            dob.DataBindings.Add("Value", bindingSource1, "stuDob", true, DataSourceUpdateMode.OnPropertyChanged);
            txtAddress.DataBindings.Add("Text", bindingSource1, "stuAddress", true, DataSourceUpdateMode.OnPropertyChanged);
            txtPhone.DataBindings.Add("Text", bindingSource1, "stuPhone", true, DataSourceUpdateMode.OnPropertyChanged);
            txtEmail.DataBindings.Add("Text", bindingSource1, "stuEmail", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDeptId.DataBindings.Add("Text", bindingSource1, "deptId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCouName.DataBindings.Add("Text", bindingSource1, "couName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCouSemester.DataBindings.Add("Text", bindingSource1, "couSemester", true, DataSourceUpdateMode.OnPropertyChanged);
            txtExamName.DataBindings.Add("Text", bindingSource1, "examName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtExamMark.DataBindings.Add("Text", bindingSource1, "examMark", true, DataSourceUpdateMode.OnPropertyChanged);
            examDate.DataBindings.Add("Value", bindingSource1, "examDate", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCouId.DataBindings.Add("Text", bindingSource1, "couId", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Teacher_Load(sender, e);
        }

        private void rdbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMale.Checked == false)
            {
                rdbFemale.Checked = true;
            }
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn đăng xuất khỏi tài khoản hiện tại ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Hide();
                Login a = new Login();
                a.ShowDialog();
                this.Close();
            }
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePass a = new ChangePass();
            a.ShowDialog();
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["Exam_CSharp_09_01_2023.Properties.Settings.Exam_CSharpConnectionString"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                using (DataTable dt = new DataTable())
                {
                    using (SqlCommand cmd = new SqlCommand("select tblStudent.stuId,stuName,stuGender,stuDob,stuAddress,stuPhone,stuEmail,deptId,couName,couSemester,examName,examMark,examDate,tblCourse.couId from tblStudent left join tblExam on tblStudent.stuId = tblExam.stuId left join tblCourse on tblCourse.couId = tblExam.couId where tblStudent.stuLevel > 2 and tblStudent.stuId like @stuUsername or tblStudent.stuLevel > 2 and tblStudent.stuName like @stuUsername", con))
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
        {
            if (e.RowIndex != -1) //ngăn lỗi click trên collumn
            {
                txtId.Text = table.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = table.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (table.Rows[e.RowIndex].Cells[2].Value.ToString().Equals("True"))
                {
                    rdbMale.Checked = true;
                    rdbFemale.Checked = false;
                }
                else
                {
                    rdbMale.Checked = false;
                    rdbFemale.Checked = true;
                }
                dob.Text = table.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtAddress.Text = table.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtPhone.Text = table.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtEmail.Text = table.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtDeptId.Text = table.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtCouName.Text = table.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtCouSemester.Text = table.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtExamName.Text = table.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtExamMark.Text = table.Rows[e.RowIndex].Cells[11].Value.ToString();
                if (examDate.Text == null)
                {
                    examDate.Text = table.Rows[e.RowIndex].Cells[12].Value.ToString();
                }
                txtCouId.Text = table.Rows[e.RowIndex].Cells[13].Value.ToString();
            }
        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            using (var ef = new Exam_CSharpEntities())
            {
                if (txtName.Text == "" || txtAddress.Text == "" || txtPhone.Text == "" || txtEmail.Text == "" || txtDeptId.Text == "")
                {
                    MessageBox.Show("Bạn quên chưa nhập nội dung rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!Regex.Match(txtName.Text, ValidateAll.CHAR).Success)
                {//không hợp lệ thì
                    MessageBox.Show("Tên có chứa ký tự số không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Regex.Match(txtPhone.Text, ValidateAll.PHONE).Success)
                {//không hợp lệ thì
                    MessageBox.Show("Số điện thoại có chứa ký tự không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Regex.Match(txtEmail.Text, ValidateAll.EMAIL).Success)
                {//không hợp lệ thì
                    MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Regex.Match(txtDeptId.Text, ValidateAll.NUMBER).Success)
                {//không hợp lệ thì
                    MessageBox.Show("Dept Id có chứa ký tự không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var stu = new tblStudent();
                stu.stuName = txtName.Text;
                stu.stuDob = dob.Value;
                stu.stuGender = rdbMale.Checked ? true : false;
                stu.stuAddress = txtAddress.Text;
                stu.stuPhone = txtPhone.Text;
                stu.stuEmail = txtEmail.Text;
                stu.stuLevel = 3; //teacher không coi được level mà system auto choose
                stu.deptId = Convert.ToByte(txtDeptId.Text);
                stu.createAt = DateTime.Now;
                ef.tblStudents.Add(stu);//mới add vào bộ nhớ thôi, chưa add vào db

                if (txtCouName.Text == "" || txtCouSemester.Text == "")
                {
                    MessageBox.Show("Bạn quên chưa nhập nội dung rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!Regex.Match(txtCouName.Text, ValidateAll.CHAR).Success)
                {//không hợp lệ thì
                    MessageBox.Show("Tên có chứa ký tự số không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Regex.Match(txtCouSemester.Text, ValidateAll.NUM).Success)
                {//không hợp lệ thì
                    MessageBox.Show("Học kì có chứa ký tự không hợp lệ: 1-3", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var cou = new tblCourse();
                cou.couName = txtCouName.Text;
                cou.couSemester = Convert.ToByte(txtCouSemester.Text);
                ef.tblCourses.Add(cou);

                await ef.SaveChangesAsync(); //add student and course
                MessageBox.Show("Thêm dữ liệu học sinh thành công", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Teacher_Load(sender, e);
            }
        }


        private async void btnInsertExam_Click(object sender, EventArgs e)
        {
            using (var ef = new Exam_CSharpEntities())
            {
                try
                {
                    if (txtExamName.Text == "" || txtExamMark.Text == "")
                    {
                        MessageBox.Show("Bạn quên chưa nhập nội dung rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (!Regex.Match(txtExamName.Text, ValidateAll.CHAR).Success)
                    {//không hợp lệ thì
                        MessageBox.Show("Tên bài kiểm tra có chứa ký tự số không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!Regex.Match(txtExamMark.Text, ValidateAll.POINT).Success)
                    {//không hợp lệ thì
                        MessageBox.Show("Điểm có chứa ký tự không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var exam = new tblExam();
                    exam.examName = txtExamName.Text;
                    exam.examMark = Convert.ToInt32(txtExamMark.Text);
                    exam.examDate = DateTime.Parse(examDate.Text);
                    exam.stuId = Convert.ToByte(txtId.Text);
                    exam.couId = Convert.ToByte(Convert.ToInt32(txtId.Text) - 2);
                    ef.tblExams.Add(exam);
                }
                catch (Exception)
                {
                    MessageBox.Show("Exam chưa có dữ liệu hoặc do bạn quên chưa thêm couName trong table Course", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                await ef.SaveChangesAsync(); //add exam
                MessageBox.Show("Thêm dữ liệu học sinh thành công", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Teacher_Load(sender, e);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var ef = new Exam_CSharpEntities())
            {
                var id = Convert.ToInt32(txtId.Text);
                var obj = await ef.tblStudents.FirstOrDefaultAsync(i => i.stuId == id);
                if (obj != null)
                {
                    if (txtName.Text == "" || txtAddress.Text == "" || txtPhone.Text == "" || txtEmail.Text == "" || txtDeptId.Text == "")
                    {
                        MessageBox.Show("Bạn quên chưa nhập nội dung rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (!Regex.Match(txtName.Text, ValidateAll.CHAR).Success)
                    {//không hợp lệ thì
                        MessageBox.Show("Tên có chứa ký tự số không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!Regex.Match(txtPhone.Text, ValidateAll.PHONE).Success)
                    {//không hợp lệ thì
                        MessageBox.Show("Số điện thoại có chứa ký tự không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!Regex.Match(txtEmail.Text, ValidateAll.EMAIL).Success)
                    {//không hợp lệ thì
                        MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!Regex.Match(txtDeptId.Text, ValidateAll.NUMBER).Success)
                    {//không hợp lệ thì
                        MessageBox.Show("Dept Id có chứa ký tự không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    obj.stuName = txtName.Text;
                    obj.stuDob = DateTime.Parse(dob.Text);
                    obj.stuGender = rdbMale.Checked == true ? true : false;
                    obj.stuAddress = txtAddress.Text;
                    obj.stuPhone = txtPhone.Text;
                    obj.stuEmail = txtEmail.Text;
                    obj.deptId = Convert.ToByte(txtDeptId.Text);
                }
                try
                {
                    var couId = Convert.ToInt32(txtCouId.Text);
                    var obj3 = await ef.tblCourses.FirstOrDefaultAsync(i => i.couId == couId);
                    if (obj3 != null)
                    {
                        if (txtCouName.Text == "" || txtCouSemester.Text == "")
                        {
                            MessageBox.Show("Bạn quên chưa nhập nội dung rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (!Regex.Match(txtCouName.Text, ValidateAll.CHAR).Success)
                        {//không hợp lệ thì
                            MessageBox.Show("Tên khóa học có chứa ký tự số không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (!Regex.Match(txtCouSemester.Text, ValidateAll.NUM).Success)
                        {//không hợp lệ thì
                            MessageBox.Show("Học kì có chứa ký tự không hợp lệ: 1-3", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        obj3.couName = txtCouName.Text;
                        obj3.couSemester = Convert.ToByte(txtCouSemester.Text);
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Lỗi do chưa có dữ liệu, bạn hãy thêm dữ liệu trước rồi mới cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    var obj2 = await ef.tblExams.FirstOrDefaultAsync(i => i.stuId == id);
                    if (obj2 != null)
                    {
                        if (txtExamName.Text == "" || txtExamMark.Text == "")
                        {
                            MessageBox.Show("Bạn quên chưa nhập nội dung rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (!Regex.Match(txtExamName.Text, ValidateAll.CHAR).Success)
                        {//không hợp lệ thì
                            MessageBox.Show("Tên bài kiểm tra có chứa ký tự số không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (!Regex.Match(txtExamMark.Text, ValidateAll.POINT).Success)
                        {//không hợp lệ thì
                            MessageBox.Show("Điểm có chứa ký tự không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        obj2.examName = txtExamName.Text;
                        obj2.examMark = Convert.ToByte(txtExamMark.Text);
                        obj2.examDate = DateTime.Parse(examDate.Text);
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Lỗi do chưa có dữ liệu, bạn hãy thêm dữ liệu trước rồi mới cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //xong hết update về db
                await ef.SaveChangesAsync();
                MessageBox.Show("Cập nhật những ô có dữ liệu thành công", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Teacher_Load(sender, e);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắn chắn muốn xóa ? Bạn sẽ không thể hoàn tác !!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                try
                {
                    using (var ef = new Exam_CSharpEntities())
                    {
                        var id = Convert.ToInt32(txtId.Text);
                        foreach (var exam in ef.tblExams)
                        {
                            if (exam.stuId == id)
                            {
                                ef.tblExams.Remove(exam);
                            }
                        }
                        await ef.SaveChangesAsync();
                        foreach (var stu1 in ef.tblStudents)
                        {
                            if (stu1.stuId == id)
                            {
                                ef.tblStudents.Remove(stu1);
                            }
                        }
                        foreach (var cou in ef.tblCourses)
                        {
                            if (cou.couId == (id - 2))
                            {
                                ef.tblCourses.Remove(cou);
                            }
                        }
                        await ef.SaveChangesAsync();

                        MessageBox.Show("Success", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Teacher_Load(sender, e);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi do khóa ngoại, hãy xóa từ bảng exam trước rồi thử lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Teacher_Load(sender, e);
                }
            }
        }

        private void show1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Show1 a = new Show1();
            a.ShowDialog();
            this.Close();
        }

        private void Show2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Show2 a = new Show2();
            a.ShowDialog();
            this.Close();
        }

        private void Show3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Show3 a = new Show3();
            a.ShowDialog();
            this.Close();
        }

        private void Show4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Show4 a = new Show4();
            a.ShowDialog();
            this.Close();
        }

        private void Show5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Show5 a = new Show5();
            a.ShowDialog();
            this.Close();
        }

        private void Show6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Show6 a = new Show6();
            a.ShowDialog();
            this.Close();
        }

        private void Show7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Show7 a = new Show7();
            a.ShowDialog();
            this.Close();
        }

        private void Show8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Show8 a = new Show8();
            a.ShowDialog();
            this.Close();
        }

        private void Show9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Show9 a = new Show9();
            a.ShowDialog();
            this.Close();
        }
    }
}
