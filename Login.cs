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
    public partial class Login : Form
    {
        SqlConnection lObjConn;
        SqlCommand lObjCmd;
        SqlDataAdapter lObjAdpt;
        DataSet lObjDS;
        SqlDataReader lObjRead;

        String lsConnStr = "";
        String lsQuery = "";

        UserDtls lObjUserDtls = new UserDtls();
        public static string SetValueForText1 = "";
        public static string LastLogintime;
        public static string SetValueForText2 = "";

        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            cmbBoxFy.SelectedIndex = 0;
            lsConnStr = "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=MechMaster; Data Source=LAPTOP-SQ607JC2\\SQLEXPRESS";
            lObjConn = new SqlConnection(lsConnStr);
            lObjConn.Open();
        }
       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtLoginPass_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SetValueForText1 = txtUserName.Text;
            SetValueForText2 = txtLoginPass.Text;
            lObjUserDtls.sUserName = txtUserName.Text;
            lObjUserDtls.sPwd = txtLoginPass.Text;

            if ((string.IsNullOrEmpty(txtUserName.Text)) || (string.IsNullOrEmpty(txtLoginPass.Text)))
            //(txtLoginPass.Text == "" || txtUserName.Text == "")
            {
                MessageBox.Show("Fileds cannot be blank");
                return;
            }

            bool lbValidLogin = lObjUserDtls.ValidLogin(lsConnStr);

            if (lbValidLogin)
            {
                lsQuery = "select * from UserDtls where UserName=@Username and Pwd=@Pwd";
                lObjCmd = new SqlCommand();
                lObjCmd.CommandType = CommandType.Text;
                lObjCmd.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = txtUserName.Text;
                lObjCmd.Parameters.AddWithValue("@Pwd", SqlDbType.VarChar).Value = txtLoginPass.Text;
                lObjCmd.CommandText = lsQuery;
                lObjCmd.Connection = lObjConn;
                lObjAdpt = new SqlDataAdapter(lObjCmd);
                lObjDS = new DataSet();
                lObjAdpt.Fill(lObjDS);
                lObjRead = lObjCmd.ExecuteReader();
                while (lObjRead.Read())
                {
                    LastLogintime = lObjRead[6].ToString();
                }
                lObjUserDtls.UpdateLoginTime(lsConnStr, txtUserName.Text);
                this.Hide();
                Home obj = new Home();
                obj.ShowDialog();
            }
            else
            {
                MessageBox.Show("User Name or Password Mismatch");
            }
        }
    }
}