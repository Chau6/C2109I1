using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_CSharp_09_01_2023.Service
{
    internal interface InterfaceAll
    {
        //login
        void btnSignIn_Click(object sender, EventArgs e);
        void chkShowPassword_CheckedChanged(object sender, EventArgs e);
        void btnExit_Click(object sender, EventArgs e);
        void btnReturn_Click(object sender, EventArgs e);
        void btnSub_Click(object sender, EventArgs e);
        void Admin_Load(object sender, EventArgs e);
        void toolStripButton2_Click(object sender, EventArgs e); //update admin
        void toolStripButton3_Click(object sender, EventArgs e); //delete admin
        string RandomString(int length);
        void toolStripButton1_Click(object sender, EventArgs e); //send mail
        void txtSearch_TextChanged(object sender, EventArgs e);
        void table_CellClick(object sender, DataGridViewCellEventArgs e);
        void btnChangePass_Click(object sender, EventArgs e);
        void toolStripButton4_Click(object sender, EventArgs e); //sign out admin
    }
}
