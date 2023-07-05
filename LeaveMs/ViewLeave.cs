using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeaveMs
{
    public partial class ViewLeave : Form
    {
        Functions Con;
        public ViewLeave()
        {
            InitializeComponent();
            Con = new Functions();
            EmpIdLb1.Text = Login.EmpId + "";
            EmpNameLb1.Text = Login.EmpName;
            ShowLeaves();
        }

        private void ViewLeave_Load(object sender, EventArgs e)
        {

        }
        private void ShowLeaves()
        {
            string Query = "select * from LeaveTb1 where Employee = {0}";
            Query = string.Format(Query, Login.EmpId);
            LeavesList.DataSource = Con.GetData(Query);
        }

        private void LogoutLb1_Click(object sender, EventArgs e)
        {
           Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
