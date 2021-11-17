using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MasterMech
{
    class InvoiceItem
    {
		SqlConnection lObjConn;
		SqlCommand lObjCmd;
		SqlDataAdapter lObjAdpt;
		DataSet lObjDS;
		SqlDataReader lObjRead;

		public int? InvoiceItemSNo;
		public int InvoiceSNo;
		public int? ItemNo;
		public string ItemDesc;
		public string ItemType;
		public string ItemCatg;
		public double? ItemPrice;
		public string ItemUOM;
		public string ItemSts;
		public double? CGSTRate;
		public double? SGSTRate;
		public double? IGSTRate;
		public string UPCCode;
		public string HSNCode;
		public string SACCode;
		public double? Qty;
		public double? SGSTAmount;
		public double? CGSTAmount;
		public double? IGSTAmount;
		public double? DiscountAmount;
		public double? TotalAmount;
		public DateTime Created;
		public string CreatedBy;
		public DateTime? Modified;
		public string ModifiedBy;
		public char Deleted;
		DateTime? DeletedOn;
		InvoiceClass lObjInvClss = new InvoiceClass();

		public List<InvoiceItem> InvoiceItems;
		// Supporting propeties
		private string ConnStr;
		private string UserID;

		public InvoiceItem()
        {

        }

		public InvoiceItem(string isConnstr, string isUserID)
        {
			ConnStr = isConnstr;
			UserID = isUserID;
        }

		public void SearchItem(string isConnStr)
        {
			//bool lbFlag = true;
			lObjConn = new SqlConnection(isConnStr);
			lObjConn.Open();
			string lsQuery = "select * from [InVoice2122] where InsertTime=@InsertTime and Deleted=@Deleted";
			lObjCmd = new SqlCommand();
			lObjCmd.CommandType = CommandType.Text;
			lObjCmd.Parameters.AddWithValue("@InsertTime", SqlDbType.VarChar).Value = "R";
			lObjCmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = 'N';
			lObjCmd.CommandText = lsQuery;
			lObjCmd.Connection = lObjConn;
			lObjRead = lObjCmd.ExecuteReader();
			while (lObjRead.Read())
			{
				InvoiceSNo = Convert.ToInt32(lObjRead[1]);
			}
			//if (lObjDS.Tables[0].Rows.Count > 0)
			//{
			//	lbFlag = true;
			//}
			//else
			//{
			//	lbFlag = false;
			//}

			//return lbFlag;
		}
		public void UpdateItem(string isConnStr)
		{
			lObjConn = new SqlConnection(isConnStr);
			lObjConn.Open();
			String lsQuery = "update [InVoice2122] set InsertTime=@InsertTime";
			lObjCmd = new SqlCommand();
			lObjCmd.CommandType = CommandType.Text;
			lObjCmd.Parameters.AddWithValue("@InsertTime", SqlDbType.VarChar).Value = "P";
			lObjCmd.CommandText = lsQuery;
			lObjCmd.Connection = lObjConn;
			lObjCmd.ExecuteNonQuery();
		}
		public void searchInvoiceSno(string isConnStr)
		{
			lObjConn = new SqlConnection(isConnStr);
			lObjConn.Open();
			string lsQuery = "select * from [Invoice2122] where InnvoiceNo=@InnvoiceNo and Deleted=@Deleted";
			lObjCmd = new SqlCommand();
			lObjCmd.CommandType = CommandType.Text;
			lObjCmd.Parameters.AddWithValue("@InnvoiceNo", SqlDbType.VarChar).Value = Invoice.InvoiceNo;
			lObjCmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = 'N';
			lObjCmd.CommandText = lsQuery;
			lObjCmd.Connection = lObjConn;
			lObjRead = lObjCmd.ExecuteReader();
			while (lObjRead.Read())
			{
				InvoiceSNo = Convert.ToInt32(lObjRead[1]);
			}
		}
		public void searchDeleteInvoiceSno(string isConnStr)
		{
			lObjConn = new SqlConnection(isConnStr);
			lObjConn.Open();
			string lsQuery = "select * from [Invoice2122] where InnvoiceNo=@InnvoiceNo and Deleted=@Deleted";
			lObjCmd = new SqlCommand();
			lObjCmd.CommandType = CommandType.Text;
			lObjCmd.Parameters.AddWithValue("@InnvoiceNo", SqlDbType.VarChar).Value = Invoice.InvoiceNo;
			lObjCmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = 'Y';
			lObjCmd.CommandText = lsQuery;
			lObjCmd.Connection = lObjConn;
			lObjRead = lObjCmd.ExecuteReader();
			while (lObjRead.Read())
			{
				InvoiceSNo = Convert.ToInt32(lObjRead[1]);
			}
		}
		public void DeleteItem(string isConStr)
		{
			lObjConn = new SqlConnection(isConStr);
			lObjConn.Open();
			string lsQuery = "update [InvoiceItem2122] set Deleted=@Deleted,DeletedOn=@DeletedOn,DeletedBy=@DeletedBy where InvoiceSNo=@InvoiceSNo";
			lObjCmd = new SqlCommand();
			lObjCmd.CommandType = CommandType.Text;
			lObjCmd.Parameters.AddWithValue("@InvoiceSNo", SqlDbType.VarChar).Value = InvoiceSNo;
			lObjCmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = "Y";
			lObjCmd.Parameters.AddWithValue("@DeletedOn", SqlDbType.VarChar).Value = DateTime.Now;
			lObjCmd.Parameters.AddWithValue("@DeletedBy", SqlDbType.VarChar).Value = Login.SetValueForText1;
			lObjCmd.CommandText = lsQuery;
			lObjCmd.Connection = lObjConn;
			lObjCmd.ExecuteNonQuery();
		}


	}
	
}
