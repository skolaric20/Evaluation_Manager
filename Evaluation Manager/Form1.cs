using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluation_Manager
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            public static Teacher LoggedTeacher { get; set; }

        LoggedTeacher = TeacherRepository.GetTeacher(txtUsername.Text); 
            if (LoggedTeacher != null && LoggedTeacher.CheckPassword(txtPassword.Text)) 
            {
                FrmStudents frmStudents = new FrmStudents();
        Hide();
        frmStudents.ShowDialog();
                Close();
    }
            else
            {
                MessageBox.Show("Neispravni podaci");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
