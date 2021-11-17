using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MasterMech
{
    class CustomerClss
    {
        public int? CustNo;
        public string CustFName;
        public string CustLName;
        public string CustMobNo;
        public string CustEmail;
        public string CustSts;
        public string CustType;
        public string CustStAddr;
        public string CustArAddr;
        public string CustCity;
        public string CustState;
        public string CustPinCode;
        public string CustCountry;
        public string CustGSTNo;
        public DateTime? CustLastVisit;
        public string CustRemarks;
        public DateTime? Created;
        public string CreatedBy;
        public string Modified;
        public string ModifiedBy;
        public string Deleted;
        public DateTime? DeletedOn;
        public string DeletedBy;
        public string CustMobNo2;

        SqlConnection lObjConn;
        SqlCommand lObjCmd;
        SqlDataAdapter lObjAdpt;
        DataSet lObjDS;
        SqlDataReader lObjRead;

        String ConnStr = "";
        string UserID;
        String lsQuery = "";

        public CustomerClss()
        {

        }
        public CustomerClss(string isConnStr, string isUserID)
        {
            ConnStr = isConnStr;
            UserID = isUserID;
        }
        public CustomerClss(int isCustNo, string isCustFName, string isCustLName, string isCustMobNo, string isCustMobNo2, string isCustEmail, string isCustSts, string isCustType, string isCustStAddr, string isCustArAddr, string isCustCity, string isCustState, string isCustPinCode, string isCustCountry, string isCustGSTNo, DateTime? isCustLastVisit, string isCustRemarks, string isDeleted)
        {
            CustNo = isCustNo;
            CustFName = isCustFName;
            CustLName = isCustLName;
            CustMobNo = isCustMobNo;
            CustMobNo2 = isCustMobNo2;
            CustEmail = isCustEmail;
            CustSts = isCustSts;
            CustType = isCustType;
            CustStAddr = isCustStAddr;
            CustArAddr = isCustArAddr;
            CustCity = isCustCity;
            CustState = isCustState;
            CustPinCode = isCustPinCode;
            CustCountry = isCustCountry;
            CustGSTNo = isCustGSTNo;
            CustLastVisit = isCustLastVisit;
            CustRemarks = isCustRemarks;
            Deleted = isDeleted;
        }
      
        public bool searchCustomer(string isConnStr, string isCustMobNo)
        {
            bool lbFlag = true;
            lObjConn = new SqlConnection(isConnStr);
            lObjConn.Open();
            lsQuery = "select * from Customer where CustMobNo=@CustMobNo and Deleted=@Deleted";
            lObjCmd = new SqlCommand();
            lObjCmd.CommandType = CommandType.Text;
            lObjCmd.Parameters.AddWithValue("@CustMobNo", SqlDbType.VarChar).Value = isCustMobNo;
            lObjCmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = 'N';
            lObjCmd.CommandText = lsQuery;
            lObjCmd.Connection = lObjConn;
            lObjAdpt = new SqlDataAdapter(lObjCmd);
            lObjDS = new DataSet();
            lObjAdpt.Fill(lObjDS);
            lObjRead = lObjCmd.ExecuteReader();
            while (lObjRead.Read())
            {
                CustNo = Convert.ToInt32(lObjRead[0]);
                CustFName = lObjRead[1].ToString();
                CustLName = lObjRead[2].ToString();
                CustMobNo2 = lObjRead[3].ToString();
                CustEmail = lObjRead[4].ToString();
                CustSts = lObjRead[5].ToString();
                CustType = lObjRead[6].ToString();
                CustStAddr = lObjRead[7].ToString();
                CustArAddr = lObjRead[8].ToString();
                CustCity = lObjRead[9].ToString();
                CustState = lObjRead[10].ToString();
                CustPinCode = lObjRead[11].ToString();
                CustCountry = lObjRead[12].ToString();
                CustGSTNo = lObjRead[13].ToString();
                CustLastVisit = Convert.ToDateTime(lObjRead[14]);
                CustRemarks = lObjRead[15].ToString();
                Created = Convert.ToDateTime(lObjRead[16]);
                CreatedBy = lObjRead[17].ToString();
                Modified = lObjRead[18].ToString();
                ModifiedBy = lObjRead[19].ToString();
            }
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
        public void UpdateCustomer(string isConnStr)
        {
            lObjConn = new SqlConnection(isConnStr);
            lObjConn.Open();
            lsQuery = "update Customer set CustFName=@CustFName,CustLName=@CustLName,CustMobNo=@CustMobNo,CustEmail=@CustEmail,CustSts=@CustSts,CustType=@CustType,CustStAddr=@CustStAddr,CustArAddr=@CustArAddr,CustCity=@CustCity,CustState=@CustState,CustPinCode=@CustPinCode,CustCountry=@CustCountry,CustGSTNo=@CustGSTNo,CustRemarks=@CustRemarks,Modified=@Modified,ModifiedBy=@ModifiedBy where CustNo=@CustNo";
            lObjCmd = new SqlCommand();
            lObjCmd.CommandType = CommandType.Text;
            lObjCmd.Parameters.AddWithValue("@CustNo", SqlDbType.VarChar).Value = CustNo;
            lObjCmd.Parameters.AddWithValue("@CustFName", SqlDbType.VarChar).Value = CustFName;
            lObjCmd.Parameters.AddWithValue("@CustLName", SqlDbType.VarChar).Value = CustLName;
            lObjCmd.Parameters.AddWithValue("@CustMobNo2", SqlDbType.VarChar).Value = CustMobNo2;
            lObjCmd.Parameters.AddWithValue("@CustEmail", SqlDbType.VarChar).Value = CustEmail;
            lObjCmd.Parameters.AddWithValue("@CustSts", SqlDbType.VarChar).Value = CustSts;
            lObjCmd.Parameters.AddWithValue("@CustType", SqlDbType.VarChar).Value = CustType;
            lObjCmd.Parameters.AddWithValue("@CustStAddr", SqlDbType.VarChar).Value = CustStAddr;
            lObjCmd.Parameters.AddWithValue("@CustArAddr", SqlDbType.VarChar).Value = CustArAddr;
            lObjCmd.Parameters.AddWithValue("@CustCity", SqlDbType.VarChar).Value = CustCity;
            lObjCmd.Parameters.AddWithValue("@CustState", SqlDbType.VarChar).Value = CustState;
            lObjCmd.Parameters.AddWithValue("@CustPinCode", SqlDbType.VarChar).Value = CustPinCode;
            lObjCmd.Parameters.AddWithValue("@CustCountry", SqlDbType.VarChar).Value = CustCountry;
            lObjCmd.Parameters.AddWithValue("@CustGSTNo", SqlDbType.VarChar).Value = CustGSTNo;
            lObjCmd.Parameters.AddWithValue("@CustRemarks", SqlDbType.VarChar).Value = CustRemarks;
            lObjCmd.Parameters.AddWithValue("@Modified", SqlDbType.VarChar).Value = DateTime.Now;
            lObjCmd.Parameters.AddWithValue("@ModifiedBy", SqlDbType.VarChar).Value = Login.SetValueForText1;
            lObjCmd.CommandText = lsQuery;
            lObjCmd.Connection = lObjConn;
            lObjCmd.ExecuteNonQuery();
        }
        public void DeleteCustomer(string  isConnStr)
        {
            lObjConn = new SqlConnection(isConnStr);
            lObjConn.Open();
            lsQuery = "update Customer set Deleted=@Deleted,DeletedOn=@DeletedOn,DeletedBy=@DeletedBy where CustNo=@CustNo";
            lObjCmd = new SqlCommand();
            lObjCmd.CommandType = CommandType.Text;
            lObjCmd.Parameters.AddWithValue("@CustNo", SqlDbType.VarChar).Value = CustNo;
            lObjCmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = "Y";
            lObjCmd.Parameters.AddWithValue("@DeletedOn", SqlDbType.VarChar).Value = DateTime.Now;
            lObjCmd.Parameters.AddWithValue("@DeletedBy", SqlDbType.VarChar).Value = Login.SetValueForText1;
            lObjCmd.CommandText = lsQuery;
            lObjCmd.Connection = lObjConn;
            lObjCmd.ExecuteNonQuery();
        }
        public void save(string isConnStr)
        {
            Login lObjLog = new Login();
            lObjConn = new SqlConnection(isConnStr);
            lObjConn.Open();
            lsQuery = "Insert Into Customer(CustFName,CustLName,CustMobNo,CustEmail,CustSts,CustType,CustStAddr,CustArAddr,CustCity,CustState,CustPinCode,CustCountry,CustGSTNo,CustLastVisit,CustRemarks,Created,CreatedBy,Deleted)values(@CustFName,@CustLName,@CustMobNo,@CustEmail,@CustSts,@CustType,@CustStAddr,@CustArAddr,@CustCity,@CustState,@CustPinCode,@CustCountry,@CustGSTNo,@CustLastVisit,@CustRemarks,@Created,@CreatedBy,@Deleted)";
            lObjCmd = new SqlCommand();
            lObjCmd.CommandType = CommandType.Text;
            lObjCmd.Parameters.AddWithValue("@CustFName", SqlDbType.VarChar).Value = CustFName;
            lObjCmd.Parameters.AddWithValue("@CustLName", SqlDbType.VarChar).Value = CustLName;
            lObjCmd.Parameters.AddWithValue("@CustMobNo", SqlDbType.VarChar).Value = CustMobNo;
            lObjCmd.Parameters.AddWithValue("@CustEmail", SqlDbType.VarChar).Value = CustEmail;
            lObjCmd.Parameters.AddWithValue("@CustSts", SqlDbType.VarChar).Value = CustSts;
            lObjCmd.Parameters.AddWithValue("@CustType", SqlDbType.VarChar).Value = CustType;
            lObjCmd.Parameters.AddWithValue("@CustStAddr", SqlDbType.VarChar).Value = CustStAddr;
            lObjCmd.Parameters.AddWithValue("@CustArAddr", SqlDbType.VarChar).Value = CustArAddr;
            lObjCmd.Parameters.AddWithValue("@CustCity", SqlDbType.VarChar).Value = CustCity;
            lObjCmd.Parameters.AddWithValue("@CustState", SqlDbType.VarChar).Value = CustState;
            lObjCmd.Parameters.AddWithValue("@CustPinCode", SqlDbType.VarChar).Value = CustPinCode;
            lObjCmd.Parameters.AddWithValue("@CustCountry", SqlDbType.VarChar).Value = CustCountry;
            lObjCmd.Parameters.AddWithValue("@CustGSTNo", SqlDbType.VarChar).Value = CustGSTNo;
            lObjCmd.Parameters.AddWithValue("@CustLastVisit", SqlDbType.VarChar).Value = CustLastVisit;
            lObjCmd.Parameters.AddWithValue("@CustRemarks", SqlDbType.VarChar).Value = CustRemarks;
            lObjCmd.Parameters.AddWithValue("@Created", SqlDbType.VarChar).Value = DateTime.Now;
            lObjCmd.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = Login.SetValueForText1;
            lObjCmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = "N";
            lObjCmd.CommandText = lsQuery;
            lObjCmd.Connection = lObjConn;
            lObjCmd.ExecuteNonQuery();
        }
        

    } 
}
