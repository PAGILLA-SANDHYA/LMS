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
    public partial class Categories : Form
    {
        Functions Con;
        public Categories()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCategories();
        }
        private void ShowCategories()
        {
            string Query = "select * from CategoryTb1";
            CategoriesList.DataSource = Con.GetData(Query);
        }
        private void Categories_Load(object sender, EventArgs e)
        {
      
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
              if(CapNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");

                }else
                {
                   string Category = CapNameTb.Text;
                    String Query = "insert into CategoryTb1 values('{0}')";
                    Query = string.Format(Query, Category); 
                    Con.SetData(Query);
                    ShowCategories();
                    CapNameTb.Text = "";
                }
            }
            catch (Exception Ex)  
            {
                MessageBox.Show(Ex.Message);
            
            }
        }
        int Key = 0;
        private void CategoriesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
               CapNameTb.Text = CategoriesList.SelectedRows[0].Cells[1].Value.ToString();   
                if(CapNameTb.Text == "")
            {

                Key = 0;
            }else
            {
                Key = Convert.ToInt32(CategoriesList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (CapNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    string Category = CapNameTb.Text;
                    String Query = "Update CategoryTb1 set CatName = '{0}' where CatId = {1}";
                    Query = string.Format(Query, Category,Key);
                    Con.SetData(Query);
                    ShowCategories();
                    CapNameTb.Text = "";
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
                if (Key == 0 )
                {
                    MessageBox.Show("Missing Data!!!");

                }
                else
                {
                    string Category = CapNameTb.Text;
                    String Query = "delete from CategoryTb1 where  CatId ={0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    ShowCategories();
                    CapNameTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }

        private void EmpLb1_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void LeavesLb1_Click(object sender, EventArgs e)
        {
            Leaves Obj = new Leaves();
            Obj.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            {
                Login Obj = new Login();
                Obj.Show();
                this.Hide();
            }
        }
    }
}
