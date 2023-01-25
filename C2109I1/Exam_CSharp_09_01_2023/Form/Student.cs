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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();

        private void Student_Load(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Exam_CSharp_09_01_2023.Properties.Settings.Exam_CSharpConnectionString"].ConnectionString;

            command.Connection = con;
            command.CommandText = "GetDataStudent";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Username", Login.UserName);

            adapter.SelectCommand = command;
            adapter.Fill(ds);

            bindingSource1.DataSource = ds.Tables[0];
            table.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
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
    }
}
