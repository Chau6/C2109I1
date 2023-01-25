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
    public partial class Show4 : Form
    {
        public Show4()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();

        private void Show4_Load(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Exam_CSharp_09_01_2023.Properties.Settings.Exam_CSharpConnectionString"].ConnectionString;
            command.Connection = con;
            command.CommandText = "select tblStudent.stuId,tblStudent.stuName,tblExam.examMark from tblStudent left join tblExam on tblStudent.stuId = tblExam.stuId where tblExam.examMark = (select max(tblExam.examMark) from tblExam) order by tblStudent.stuId";
            command.CommandType = CommandType.Text;

            adapter.SelectCommand = command;
            ds.Tables.Clear();
            adapter.Fill(ds);

            bindingSource1.DataSource = ds.Tables[0];
            Table.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;

            txtId.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtMark.DataBindings.Clear();

            txtId.DataBindings.Add("Text", bindingSource1, "stuId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtName.DataBindings.Add("Text", bindingSource1, "stuName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMark.DataBindings.Add("Text", bindingSource1, "examMark", true, DataSourceUpdateMode.OnPropertyChanged);
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
