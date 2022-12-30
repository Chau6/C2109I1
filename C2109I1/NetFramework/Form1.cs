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

namespace NetFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection();
        SqlCommand command = new SqlCommand(); //DAL DAO
        SqlDataAdapter adapter= new SqlDataAdapter(); //tạo vùng nhớ tránh bị phân mảnh data
        DataSet ds = new DataSet(); //chặt vùng nhớ ra từng dãy data đưa lên lưới hiển thị

        private void Form1_Load(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["NetFramework.Properties.Settings.CSharp_Window_FormConnectionString"].ConnectionString;

            command.Connection = con;
            command.CommandText = "select * from Student";
            command.CommandType = CommandType.Text;

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            table.DataSource = ds.Tables[0].DefaultView;
        }
    }
}
