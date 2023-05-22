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
    public partial class FrmStudents : Form
    {
        public FrmStudents()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void btnEvaluateStudent_Click(object sender, EventArgs e)
        {
            Student student = dgvStudents.CurrentRow.DataBoundItem as Student;
            if (student != null)
            {
                var FrmEvaluation = new FrmEvaluation(student);
                FrmEvaluation.ShowDialog();
            }
}
