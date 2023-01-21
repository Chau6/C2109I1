using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Nhớ luôn sài asyne hoặc await để đa luồng

namespace WindowsFormsApp_Net_Framework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e) //phải có await để đa luồng
        {
            //CSharp_Window_FormEntities ef = new CSharp_Window_FormEntities();
            //dataGridView1.DataSource = ef.Students.ToList();

            //using (var ef = new CSharp_Window_FormEntities()) //same try catch, sài xong entity thì giết luôn
            //{
            //    dataGridView1.DataSource = ef.Students.ToList(); //lấy hết
            //}

            using (var ef = new CSharp_Window_FormEntities()) //same try catch, sài xong entity thì giết luôn
            {
                bindingSource1.DataSource = await ef.Students.Select(stu => new
                {
                    stu.ID, stu.FirstName, stu.LastName, stu.Gender, stu.Dob //khai báo tên trường cần show
                }).ToListAsync(); //load đa luồng <= sài thèn này
                bindingNavigator1.BindingSource = bindingSource1;
                dataGridView1.DataSource = bindingSource1;
                txtId.DataBindings.Add("Text", bindingSource1, "ID", true, DataSourceUpdateMode.OnPropertyChanged);
                txtFirstName.DataBindings.Add("Text", bindingSource1, "FirstName", true, DataSourceUpdateMode.OnPropertyChanged);
                txtLastName.DataBindings.Add("Text", bindingSource1, "LastName", true, DataSourceUpdateMode.OnPropertyChanged);
                chkGender.DataBindings.Add("Checked", bindingSource1, "Gender", true, DataSourceUpdateMode.OnPropertyChanged);
                dateTimePicker1.DataBindings.Add("Value", bindingSource1, "Dob", true, DataSourceUpdateMode.OnPropertyChanged);
            }
        }

        private async void toolStripButton1_Click(object sender, EventArgs e) //update
        {
            using (var ef = new CSharp_Window_FormEntities())
            {
                var id = Convert.ToInt32(txtId.Text);
                var obj = await ef.Students.FirstOrDefaultAsync(i => i.ID == id);
                if(obj != null)
                {
                    obj.FirstName = txtFirstName.Text;
                    obj.LastName = txtLastName.Text;
                    obj.Gender = chkGender.Checked;
                    obj.Dob = dateTimePicker1.Value;
                }
                //xong hết update về db
                await ef.SaveChangesAsync();
                bindingSource1.DataSource = await ef.Students.Select(stu => new
                {
                    stu.ID,
                    stu.FirstName,
                    stu.LastName,
                    stu.Gender,
                    stu.Dob //khai báo tên trường cần show
                }).ToListAsync(); //load đa luồng <= sài thèn này
                MessageBox.Show("Success","info");
            } 
        }

        private async void btnAdd_Click(object sender, EventArgs e) //add
        {
            using(var ef = new CSharp_Window_FormEntities())
            {
                var stu1 = new Student();
                stu1.FirstName = txtFirstName.Text;
                stu1.LastName = txtLastName.Text;
                stu1.Gender = chkGender.Checked;
                stu1.Dob = dateTimePicker1.Value;

                ef.Students.Add(stu1);//mới add vào bộ nhớ thôi, chưa add vào db
                await ef.SaveChangesAsync();
                bindingSource1.DataSource = await ef.Students.Select(stu => new
                {
                    stu.ID,
                    stu.FirstName,
                    stu.LastName,
                    stu.Gender,
                    stu.Dob //khai báo tên trường cần show
                }).ToListAsync(); //load đa luồng <= sài thèn này
                MessageBox.Show("Success", "info");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            using (var ef = new CSharp_Window_FormEntities())
            {
                var id = Convert.ToInt32(txtId.Text);
                foreach (var stu1 in ef.Students)
                {
                    if(stu1.ID == id)
                    {
                        ef.Students.Remove(stu1);
                    }
                }
                //ef.Students.RemoveRange(i => ef.Students.Where(t => t.ID == id)); //chưa xong, cần nghiên cứu để xóa != id
                await ef.SaveChangesAsync();
                bindingSource1.DataSource = await ef.Students.Select(stu => new
                {
                    stu.ID,
                    stu.FirstName,
                    stu.LastName,
                    stu.Gender,
                    stu.Dob //khai báo tên trường cần show
                }).ToListAsync(); //load đa luồng <= sài thèn này
                MessageBox.Show("Success", "info");
            }
        }
    }
}
