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
    public partial class UserPasswordChange : Form
    {
        SqlConnection lObjConn;
        SqlCommand lObjCmd;
        string lsConnStr = "";
        string lsQuery = "";

        public UserPasswordChange()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lsQuery = "Update UserDtls set Pwd=@Password,LastPwdChangeTime=@LastPwdChangeTime where UserName=@User and Pwd=@Pwd";
            lObjCmd = new SqlCommand();
            lObjCmd.CommandType = CommandType.Text;
            lObjCmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = txtConfirmNPass.Text;
            lObjCmd.Parameters.AddWithValue("@User", SqlDbType.VarChar).Value = Login.SetValueForText1;
            lObjCmd.Parameters.AddWithValue("@Pwd", SqlDbType.VarChar).Value = Login.SetValueForText2;
            lObjCmd.Parameters.AddWithValue("@LastPwdChangeTime", SqlDbType.VarChar).Value = DateTime.Now;
            lObjCmd.CommandText = lsQuery;
            lObjCmd.Connection = lObjConn;
            lObjCmd.ExecuteNonQuery();

            MessageBox.Show("Password Updated");
            this.Close();
        }
        

        private void UserPasswordChange_Load(object sender, EventArgs e)
        {
            lsConnStr = "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=MechMaster; Data Source=LAPTOP-SQ607JC2\\SQLEXPRESS";
            lObjConn = new SqlConnection(lsConnStr);
            lObjConn.Open();
        }
    }
}
