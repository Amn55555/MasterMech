using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MasterMech
{
    class UserDtlClass
    {
        public string sUserID;
        public string sPwd;
        public string sUserName;
        public string sMobNo;
        public string sEmailID;
        public string sUserType;
        public DateTime dLastLoginTime;
        public DateTime dLastPwdChangeTime;
        public string sRemarks;
        public DateTime dCreated;
        public string sCreatedBy;
        public DateTime dModified;
        public string sModifiedBy;
        public string sDeleted;
        public DateTime dDeletedOn;
        public string sDeletedBy;

        SqlConnection lObjConn;
        SqlCommand lObjCmd;
        SqlDataAdapter lObjAdpt;
        SqlDataReader lObjRead;
        DataSet lObjDS;

        string ConnStr;
        string UserID;
        string lsQuery = "";

        public UserDtlClass()
        {

        }
        public UserDtlClass(string isUserID, string isUserName, string isMobNo, string isEmailID, string isUserType)
        {
            sUserID = isUserID;
            sUserName = isUserName;
            sMobNo = isMobNo;
            sEmailID = isEmailID;
            sUserType = isUserType;
        }
        public void UserDtlSave(string isConnStr)
        {
            lObjConn = new SqlConnection(isConnStr);
            lObjConn.Open();
            lsQuery = "Update UserDtls set UserName=@UserName,MobNo=@MobNo,EmailID=@EmailID,Modified=@Modified,ModifiedBy=@ModifiedBy where UserName=@User and Pwd=@Pwd";
            lObjCmd = new SqlCommand();
            lObjCmd.CommandType = CommandType.Text;
            lObjCmd.Parameters.AddWithValue("@UserName", SqlDbType.VarChar).Value = sUserName;
            lObjCmd.Parameters.AddWithValue("@User", SqlDbType.VarChar).Value = Login.SetValueForText1;
            lObjCmd.Parameters.AddWithValue("@Pwd", SqlDbType.VarChar).Value = Login.SetValueForText2;
            lObjCmd.Parameters.AddWithValue("@MobNo", SqlDbType.VarChar).Value = sMobNo;
            lObjCmd.Parameters.AddWithValue("@EmailID", SqlDbType.VarChar).Value = sEmailID;
            lObjCmd.Parameters.AddWithValue("@Modified", SqlDbType.VarChar).Value = DateTime.Now;
            lObjCmd.Parameters.AddWithValue("@ModifiedBy", SqlDbType.VarChar).Value = Login.SetValueForText1;
            lObjCmd.CommandText = lsQuery;
            lObjCmd.Connection = lObjConn;
            lObjCmd.ExecuteNonQuery();
        }
        public void SearchUser(string isConnStr)
        {
            lObjConn = new SqlConnection(isConnStr);
            lObjConn.Open();
            lsQuery = "select * from UserDtls where UserName=@UserName and Pwd=@Pwd";
            lObjCmd = new SqlCommand();
            lObjCmd.CommandType = CommandType.Text;
            lObjCmd.Parameters.AddWithValue("@UserName", SqlDbType.VarChar).Value = Login.SetValueForText1;
            lObjCmd.Parameters.AddWithValue("@Pwd", SqlDbType.VarChar).Value = Login.SetValueForText2;
            lObjCmd.CommandText = lsQuery;
            lObjCmd.Connection = lObjConn;
            lObjAdpt = new SqlDataAdapter(lObjCmd);
            lObjDS = new DataSet();
            lObjAdpt.Fill(lObjDS);
            lObjRead = lObjCmd.ExecuteReader();
            while (lObjRead.Read())
            {
                sUserName = lObjRead[2].ToString();
                sMobNo = lObjRead[3].ToString();
                sEmailID = lObjRead[4].ToString();
                sUserType = lObjRead[5].ToString();
                dLastLoginTime = Convert.ToDateTime(Login.LastLogintime);
                dLastPwdChangeTime = Convert.ToDateTime(lObjRead[7]);
                dCreated = Convert.ToDateTime(lObjRead[9]);
                sCreatedBy = lObjRead[10].ToString();
                dModified = Convert.ToDateTime(lObjRead[11]);
                sModifiedBy = lObjRead[12].ToString();
            }
        }

    }
    
}
