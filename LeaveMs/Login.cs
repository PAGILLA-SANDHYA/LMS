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
    public partial class Login : Form
    {
        Functions Con;
        public Login()
        {
            InitializeComponent();
            Con = new Functions();
        }
        public static int EmpId;
        public static string EmpName = "";
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
           if (UNameTb.Text == "" || PasswordTb.Text == "") 
            {
                MessageBox.Show("Missing Info!!!");
            }else
            {
                if (UNameTb.Text == "Sandhya" && PasswordTb.Text == "5116") 
                {
                 Employees Obj = new Employees();
                  Obj.Show();
                    this.Hide();

                }else 
                
                {
                    try
                    {

                        string Query = "Select * from EmployeeTb1 where EmpName = '{0}' and EmpPass='{1}'";
                        Query = string.Format(Query, UNameTb.Text, PasswordTb.Text);
                        DataTable dt = Con.GetData(Query);
                        if (dt.Rows.Count == 0)

                        {
                            MessageBox.Show("Incorrect Password!!!");
                            UNameTb.Text = "";
                            PasswordTb.Text = "";
                        }
                        else
                        {
                            EmpId = Convert.ToInt32(dt.Rows[0][0].ToString());
                            EmpName = dt.Rows[0][1].ToString();
                            ViewLeave Obj = new ViewLeave();
                            Obj.Show();
                            this.Hide();

                        }




                    }
                    catch (Exception Ex)
                    
                    {

                        MessageBox.Show(Ex.Message);
                    }

                    
                
                }
            }
        }

        private void CloseLb1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
