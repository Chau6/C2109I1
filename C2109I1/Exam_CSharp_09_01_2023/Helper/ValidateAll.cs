using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_CSharp_09_01_2023
{
    public partial class ValidateAll : Form
    {
        public ValidateAll()
        {
            InitializeComponent();
        }

        private void ValidateAll_Load(object sender, EventArgs e)
        {

        }

        public static string DATE = @"^(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$";
        public static string ACC = @"^([a-zA-Z0-9]\s*){8,25}$";
        public static string PASS = @"^((?=.*\d)(?=.*[A-Z])(?=\w*\W).{8,25})$";
        public static string EMAIL = @"^(?=.{1,64}@)[A-Za-z0-9_-]+(\.[A-Za-z0-9_-]+)*@[^-][A-Za-z0-9-]+(\.[A-Za-z0-9-]+)*(\.[A-Za-z]{2,})$";
        public static string PHONE = @"^(84|0[3|5|7|8|9])+([0-9]{8,9})\b$";
        public static string NUM = @"^([1-3]\s*){1}$";
    }
}
