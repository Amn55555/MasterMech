using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MasterMech
{
    public partial class Home : Form
    {
        SqlConnection lObjConn;
        SqlCommand lObjCmd;
        SqlDataAdapter lObjAdpt;
        DataSet lObjDS;
        SqlDataReader lObjRead;

        String lsConnStr = "";
        String lsQuery = "";

        public Home()
        {
            InitializeComponent();
        }
        private void Home_Load(object sender, EventArgs e)
        {
            lsConnStr = "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=MechMaster; Data Source=LAPTOP-SQ607JC2\\SQLEXPRESS";
            lObjConn = new SqlConnection(lsConnStr);
            lObjConn.Open();
            lsQuery = "select * from UserDtls where UserName = @username";
            lObjCmd = new SqlCommand();
            lObjCmd.CommandType = CommandType.Text;
            lObjCmd.Parameters.AddWithValue("@username", SqlDbType.VarChar).Value = Login.SetValueForText1;
            lObjCmd.CommandText = lsQuery;
            lObjCmd.Connection = lObjConn;
            lObjRead = lObjCmd.ExecuteReader();
            
            while (lObjRead.Read())
            {   
                //lastLoginTimeToolStripMenuItem.Text = lObjRead[6].ToString();
                userNameToolStripMenuItem.Text = lObjRead[2].ToString();
            }
            lastLoginTimeToolStripMenuItem.Text = Login.LastLogintime;
        }
        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Customer lObj = new Customer(1);
            lObj.ShowDialog();   
        }
        private void openToolStripMenuItem2_Click(object sender, EventArgs e)
        {   
            Customer lObj = new Customer(2);
            lObj.ShowDialog();
        }
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Customer lObj = new Customer(3);
            lObj.ShowDialog();
        }

        private void newToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ItemForm lObj = new ItemForm(1);
            lObj.ShowDialog();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ItemForm lObj = new ItemForm(2);
            lObj.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemForm lObj = new ItemForm(3);
            lObj.ShowDialog();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invoice lObj = new Invoice(1);
            lObj.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invoice lObj = new Invoice(2);
            lObj.ShowDialog();
            
        }

        private void deletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invoice lObj = new Invoice(3);
            lObj.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserAccount lObj = new UserAccount();
            lObj.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserPasswordChange lObj = new UserPasswordChange();
            lObj.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lObjLog = new Login();
            lObjLog.ShowDialog();
            this.Close();
        }
    }
}
