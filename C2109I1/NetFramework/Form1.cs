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
        SqlDataAdapter adapter = new SqlDataAdapter(); //tạo vùng nhớ tránh bị phân mảnh data
        DataSet ds = new DataSet(); //chặt vùng nhớ ra từng dãy data đưa lên lưới hiển thị

        private void Form1_Load(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["NetFramework.Properties.Settings.CSharp_Window_FormConnectionString"].ConnectionString;

            command.Connection = con;
            //command.CommandText = "select * from Student; select ID,FirstName from Student"; //cho phép thay đổi nhiều câu
            command.CommandText = "GetAllStudent";
           //command.CommandType = CommandType.Text;
           command.CommandType = CommandType.StoredProcedure;

            adapter.SelectCommand = command;
            adapter.Fill(ds);

            //table.DataSource = ds.Tables[0].DefaultView;
            bindingSource1.DataSource = ds.Tables[0];
            table.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;

            TxtFirstName2.DataBindings.Add("Text", bindingSource1, "FirstName", true, DataSourceUpdateMode.OnPropertyChanged); //auto - same table_CellClick but dont need click in row
            LastName.DataBindings.Add("Text", bindingSource1, "LastName", true, DataSourceUpdateMode.OnPropertyChanged);
            ChkGender.DataBindings.Add("Checked", bindingSource1, "Gender", true, DataSourceUpdateMode.OnPropertyChanged);
            Dob.DataBindings.Add("Value", bindingSource1, "Dob", true, DataSourceUpdateMode.OnPropertyChanged);
            TxtID.DataBindings.Add("Text", bindingSource1, "ID", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void LoadData()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["NetFramework.Properties.Settings.CSharp_Window_FormConnectionString"].ConnectionString;

            command.Connection = con;
            //command.CommandText = "select * from Student; select ID,FirstName from Student"; //cho phép thay đổi nhiều câu
            command.CommandText = "GetAllStudent";
            //command.CommandType = CommandType.Text;
            command.CommandType = CommandType.StoredProcedure;

            adapter.SelectCommand = command;
            ds.Tables.Clear();
            adapter.Fill(ds);

            //table.DataSource = ds.Tables[0].DefaultView;
            bindingSource1.DataSource = ds.Tables[0];
            table.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
            TxtFirstName2.DataBindings.Add("Text", bindingSource1, "FirstName", true, DataSourceUpdateMode.OnPropertyChanged); //auto - same table_CellClick but dont need click in row
            LastName.DataBindings.Add("Text", bindingSource1, "LastName", true, DataSourceUpdateMode.OnPropertyChanged);
            ChkGender.DataBindings.Add("Checked", bindingSource1, "Gender", true, DataSourceUpdateMode.OnPropertyChanged);
            Dob.DataBindings.Add("Value", bindingSource1, "Dob", true, DataSourceUpdateMode.OnPropertyChanged);
            TxtID.DataBindings.Add("Text", bindingSource1, "ID", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e) //search
        {
            //ds.Tables[0].DefaultView = select * from Student
            //RowFilter = where => FirstName like => '%character%'
            ds.Tables[0].DefaultView.RowFilter = $"FirstName like '%{toolStripTextBox1.Text}%'"; //lấy data ra
        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e) //get data
        {
            if(e.RowIndex != -1) //ngăn lỗi click trên collumn
            {
                TxtFirstName.Text = table.Rows[e.RowIndex].Cells[1].Value.ToString(); //lấy data when click in row
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            command.CommandText = "UpdateStudent";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@FirstName", TxtFirstName2.Text);
            command.Parameters.AddWithValue("@LastName", LastName.Text);
            command.Parameters.AddWithValue("@Gender", ChkGender.Checked);
            command.Parameters.AddWithValue("@Dob", Dob.Value);
            command.Parameters.AddWithValue("@ID", TxtID.Text);
            con.Open();
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Success", "Info");
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message, "Error");
            }
            finally
            {
                con.Close();
                command.Parameters.Clear(); //k có thì nó add rồi k cho add nữa

                TxtFirstName2.DataBindings.Clear();
                LastName.DataBindings.Clear();
                ChkGender.DataBindings.Clear();
                Dob.DataBindings.Clear();
                TxtID.DataBindings.Clear();
                LoadData();
            }
        }

        private void BtnUpdateByAdapter_Click(object sender, EventArgs e) //<= sài thèn này để update
        {
            bindingSource1.EndEdit();
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            builder.GetUpdateCommand();
            try
            {
                adapter.Update(ds.Tables[0]);
                MessageBox.Show("Success", "Info");
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message, "Error");
            }
        }

        private void BtnCreateByAdapter_Click(object sender, EventArgs e)
        {
            bindingSource1.EndEdit();
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            builder.GetInsertCommand();
            string sql = $"insert into Student (FirstName,LastName,Gender,Dob) values ({TxtFirstName2.Text},{LastName.Text},{ChkGender.Checked},{Dob.Value})";
            try
            {
                con.Open();
                adapter.InsertCommand = new SqlCommand(sql, con);
                adapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Success", "Info");
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message, "Error");
            }
            finally
            {
                con.Close();
            }

        }
    }
}
