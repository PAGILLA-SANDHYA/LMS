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
    public partial class Employees : Form
    {
        Functions Con;
        public Employees()
        {
            InitializeComponent();
            Con = new Functions();
            ShowEmployee();
        }
        private void ShowEmployee()
        {
            string Query = "select * from EmployeeTb1";
            EmployeeList.DataSource = Con.GetData(Query);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Employees_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == ""||EmpPhoneTb.Text == ""||PasswordTb.Text == "" || EmpGenCb.SelectedIndex == -1 )
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = EmpGenCb.SelectedItem.ToString();
                    string Phone = EmpPhoneTb.Text;
                    string Pass = PasswordTb.Text;
                    string Add = AddTb.Text;

                    String Query = "insert into EmployeeTb1 values('{0}','{1}' ,'{2}' ,'{3}' ,'{4}')";
                    Query = string.Format(Query, Name, Gender, Phone, Pass, Add );
                    Con.SetData(Query);
                    ShowEmployee();
                    MessageBox.Show("Employee Added!!!");
                    EmpNameTb.Text = "";
                    EmpPhoneTb.Text = "";
                    PasswordTb.Text = "";
                    AddTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }
        int Key = 0;
        private void EmployeeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmployeeList.SelectedRows[0].Cells[1].Value.ToString();
            EmpGenCb.Text = EmployeeList.SelectedRows[0].Cells[2].Value.ToString();
            EmpPhoneTb.Text = EmployeeList.SelectedRows[0].Cells[3].Value.ToString();
            PasswordTb.Text = EmployeeList.SelectedRows[0].Cells[4].Value.ToString();
           AddTb.Text = EmployeeList.SelectedRows[0].Cells[5].Value.ToString();
            if (EmpNameTb.Text == "")
            {

                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(EmployeeList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || PasswordTb.Text == "" || EmpGenCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = EmpGenCb.SelectedItem.ToString();
                    string Phone = EmpPhoneTb.Text;
                    string Pass = PasswordTb.Text;
                    string Add = AddTb.Text;

                    String Query = "update EmployeeTb1 set EmpName = '{0}' ,EmpGen = '{1}' , EmpPhone ='{2}' ,EmpPass = '{3}' ,EmpAdd = '{4}' where EmpId = {5}";
                    Query = string.Format(Query, Name, Gender, Phone, Pass, Add,Key);
                    Con.SetData(Query);
                    ShowEmployee();
                    MessageBox.Show("Employee Updated!!!");
                    EmpNameTb.Text = "";
                    EmpPhoneTb.Text = "";
                    PasswordTb.Text = "";
                    AddTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || PasswordTb.Text == "" || EmpGenCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                   
                    String Query = "delete from EmployeeTb1  where EmpId = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    ShowEmployee();
                    MessageBox.Show("Employee Deleted!!!");
                    EmpNameTb.Text = "";
                    EmpPhoneTb.Text = "";
                    PasswordTb.Text = "";
                    AddTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }

        private void CategoryLb1_Click(object sender, EventArgs e)
        {
            Categories Obj = new Categories();
            Obj.Show();
            this.Hide();
        }

        private void LeaveLb1_Click(object sender, EventArgs e)
        {
            Leaves Obj = new Leaves();
            Obj.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
                 
        }
    }
}
