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
    public partial class Show7 : Form
    {
        public Show7()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teacher a = new Teacher();
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
                    using (SqlCommand cmd = new SqlCommand("select stuId,stuName,examMark from (select tblStudent.stuId,tblStudent.stuName,examMark, DENSE_RANK() over(order by tblExam.examMark asc) as R from tblExam left join tblStudent on tblStudent.stuId = tblExam.stuId) result where result.R  like @stuUsername order by stuId", con))
                    {
                        cmd.Parameters.AddWithValue("stuUsername", string.Format("%{0}%", txtSearch.Text));
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        Table.DataSource = dt;
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

        private void Table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) //ngăn lỗi click trên collumn
            {
                txtId.Text = Table.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = Table.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtMark.Text = Table.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }
    }
}
