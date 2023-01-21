using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
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
        SqlCommand command = new SqlCommand(); //DAL DAO
        SqlDataAdapter adapter = new SqlDataAdapter(); //tạo vùng nhớ tránh bị phân mảnh data
        DataSet ds = new DataSet(); //chặt vùng nhớ ra từng dãy data đưa lên lưới hiển thị

        private void Teacher_Load(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Exam_CSharp_09_01_2023.Properties.Settings.Exam_CSharpConnectionString"].ConnectionString;
            command.Connection = con;
            command.CommandText = "select tblStudent.stuId,stuName,stuGender,stuAddress,stuPhone,stuEmail,deptId,examName,examMark,examDate,couName,couSemester from tblStudent left join tblExam on tblStudent.stuId = tblExam.stuId left join tblCourse on tblCourse.couId = tblExam.couId where tblStudent.stuId = tblExam.stuId or tblExam.stuId is null order by tblStudent.stuId"; //cho phép thay đổi nhiều câu
            command.CommandType = CommandType.Text;

            adapter.SelectCommand = command;
            adapter.Fill(ds);

            bindingSource1.DataSource = ds.Tables[0];
            table.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
        }
    }
}
