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
using System.Xml.Linq;

namespace Exam_CSharp_09_01_2023
{
    public partial class Show8 : Form
    {
        public Show8()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();

        private void Show8_Load(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Exam_CSharp_09_01_2023.Properties.Settings.Exam_CSharpConnectionString"].ConnectionString;
            command.Connection = con;
            command.CommandText = "select stuId,stuName,examMark,couName,couSemester ,case when examMark >= 9 then N'Giỏi' when examMark < 9 and examMark >= 7 then N'Khá' when examMark < 7 and examMark >= 5 then N'Trung bình' when examMark < 3 then N'Kém' when examMark is null then N'Chưa thi' else N'Yếu' end as Rating from (select tblStudent.stuId,tblStudent.stuName,tblExam.examMark, tblCourse.couName, tblCourse.couSemester from tblStudent left join tblExam on tblStudent.stuId = tblExam.stuId left join tblCourse on tblExam.couId = tblCourse.couId where tblStudent.stuLevel > 2) result order by stuId";
            command.CommandType = CommandType.Text;

            adapter.SelectCommand = command;
            ds.Tables.Clear();
            adapter.Fill(ds);

            bindingSource1.DataSource = ds.Tables[0];
            Table.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teacher a = new Teacher();
            a.ShowDialog();
            this.Close();
        }
    }
}
