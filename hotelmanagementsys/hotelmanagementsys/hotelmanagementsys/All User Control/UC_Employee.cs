using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotelmanagementsys.All_User_Control
{
    public partial class UC_Employee : UserControl
    {
        function fn = new function();
        public UC_Employee()
        {
            InitializeComponent();
        }
        
        private void UC_Employee_Load(object sender, EventArgs e)
        {
            getMaxID();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "" && txtMobile.Text != "" && txtGender.Text != "" && txtEmail.Text != "" && txtUsername.Text != ""  && txtPassword.Text != "")
            {
                String query;
                String name = txtName.Text;
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String gender = txtGender.Text;
                String email = txtEmail.Text;
                String username = txtUsername.Text;
                String pass = txtPassword.Text;

                query = "insert into employee (ename,mobile,gender,emailid,username,pass) values ('"+name+"',"+mobile+",'"+gender+"','"+email+"','"+username+"','"+pass+"')";
                fn.setData(query, "Employee Registered");

                clearAll();
                getMaxID();

            }
            else
            {
                MessageBox.Show(" Fill all Fields.", "Warning...!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void tabEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            String query;
            if (tabEmployee.SelectedIndex == 1)
            {
                setEmployee(dataGridView1);
            }
            else if (tabEmployee.SelectedIndex == 2)
            {

                setEmployee(dataGridView2);
            }
        }

        public void getMaxID()
        {
            String query;
            query = "select max(eid) from employee";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                labelToSET.Text = (num + 1).ToString();
            }
            
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {  if (txtID.Text != "")
            {
                if (MessageBox.Show("Are you Sure?", "Confirmation.... !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    String query;
                    query = "delete from employee where eid = " + txtID.Text + "";
                    fn.setData(query, "Record Deleted. ");
                    tabEmployee_SelectedIndexChanged(this, null);
                }
            }

        }

        //*************************************************REQUIRED METHOD****************************************************//
        public void clearAll()
        {
            txtName.Clear();
            txtMobile.Clear();
            txtGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
        }

        public void setEmployee(DataGridView dgv)
        {
            String query;
            query = "select * from employee";
            DataSet ds = fn.getData(query);
            dgv.DataSource = ds.Tables[0];
        }

       
    }
}
