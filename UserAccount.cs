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
    public partial class UserAccount : Form
    {
        SqlConnection lObjConn;
        SqlCommand lObjCmd;
        SqlDataAdapter lObjAdpt;
        DataSet lObjDS;
        SqlDataReader lObjRead;
        String lsConnStr = "";
        String lsQuery = "";
        UserDtlClass lObjUser = new UserDtlClass();
        public UserAccount()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lObjUser.sUserName = txtUserName.Text;
            lObjUser.sMobNo = txtMobNo.Text;
            lObjUser.sEmailID = txtEid.Text;
            lObjUser.UserDtlSave(lsConnStr);

            MessageBox.Show("Updated");
            this.Close();
        }   

        private void UserAccount_Load(object sender, EventArgs e)
        {
            lsConnStr = "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=MechMaster; Data Source=LAPTOP-SQ607JC2\\SQLEXPRESS";
            lObjConn = new SqlConnection(lsConnStr);
            lObjConn.Open();
            lObjUser.SearchUser(lsConnStr);
            txtUserName.Text = lObjUser.sUserName;
            txtMobNo.Text = lObjUser.sMobNo;
            txtEid.Text = lObjUser.sEmailID;
            txtUserType.Text = lObjUser.sUserType;
            txtLastLogin.Text = lObjUser.dLastLoginTime.ToString();
            txtLastPChange.Text = lObjUser.dLastPwdChangeTime.ToString();
            txtCreated.Text = lObjUser.dCreated.ToString();
            txtCreatedBy.Text = lObjUser.sCreatedBy;
            txtModified.Text = lObjUser.dModified.ToString();
            txtModifiedBy.Text = lObjUser.sModifiedBy;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
