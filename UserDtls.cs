using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MasterMech
{
    class UserDtls
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
        DataSet lObjDS;

        String lsConnStr = "";
        String lsQuery = "";

        public UserDtls()
        {
        }

        public UserDtls(string isUserID, string isUserName, string isMobNo, string isEmailID, string isUserType)
        {
            sUserID = isUserID;
            sUserName = isUserName;
            sMobNo = isMobNo;
            sEmailID = isEmailID;
            sUserType = isUserType;
        }

        public bool ValidLogin(string isConStr)
        {
            bool lbFlag = true;

            lObjConn = new SqlConnection(isConStr);
            lObjConn.Open();

            lsQuery = "select * from UserDtls where Username=@UserName and Pwd=@Pwd";
            lObjCmd = new SqlCommand();
            lObjCmd.CommandType = CommandType.Text;
            lObjCmd.Parameters.AddWithValue("@UserName", SqlDbType.VarChar).Value = sUserName;
            lObjCmd.Parameters.AddWithValue("@Pwd", SqlDbType.VarChar).Value = sPwd;

            lObjCmd.CommandText = lsQuery;
            lObjCmd.Connection = lObjConn;
            lObjCmd.ExecuteNonQuery();
            lObjAdpt = new SqlDataAdapter(lObjCmd);
            lObjDS = new DataSet();
            lObjAdpt.Fill(lObjDS);

            if (lObjDS.Tables[0].Rows.Count > 0)
            {
                lbFlag = true;
            }
            else
            {
                lbFlag = false;
            }

            return lbFlag;
        }

        public void UpdateLoginTime(string isConStr, string isUserName)
        {

            lObjConn = new SqlConnection(isConStr);
            lObjConn.Open();

            lsQuery = "update UserDtls set LastLoginTime=@lastlogintime where UserName=@userName";
            lObjCmd = new SqlCommand();
            lObjCmd.CommandType = CommandType.Text;
            lObjCmd.Parameters.AddWithValue("@UserName", SqlDbType.VarChar).Value = sUserName;
            lObjCmd.Parameters.AddWithValue("@lastlogintime", SqlDbType.DateTime).Value = DateTime.Now;

            lObjCmd.CommandText = lsQuery;
            lObjCmd.Connection = lObjConn;
            lObjCmd.ExecuteNonQuery(); 
        }
        
    }
}
