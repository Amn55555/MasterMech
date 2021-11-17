using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MasterMech
{
    class InvoiceClass
    {
		// Involice Table Fields
		public string InvoiceNo;
		public int InvoiceSNo;
		public DateTime InvoiceDate;
		public string InvoiceSts;
		public CustomerClss InvoiceCustomer;
		public string VehicleRegNo;
		public string VehicleModel;
		public string ChassisNo;
		public string EngineNo;
		public int? Mileage;
		public string ServiceType;
		public string ServiceAssoName;
		public string ServiceAssoMobNo;
		public double? PartsTotal;
		public double? LabourTotal;
		public double? PartsCGSTTotal;
		public double? LabourCGSTTotal;
		public double? PartsSGSTTotal;
		public double? LabourSGSTTotal;
		public double? PartsIGSTTotal;
		public double? LabourIGSTTotal;
		public double? TotalSGST;
		public double? TotalCGST;
		public double? TotalIGST;
		public double? TotalTax;
		public double? TotalAmount;
		public double? GrandTotal;
		public double? DiscountAmount;
		public double? InvoiceTotal;
		public string InvoiceRemarks;
		public DateTime Created;
		public string CreatedBy;
		public DateTime? Modified;
		public string ModifiedBy;
		public char Deleted;
		public DateTime? DeletedOn;

		SqlConnection lObjConn;
		SqlCommand cmd;
		SqlDataAdapter lObjAdpt;
		SqlDataReader lObjRead;
		DataSet lObjDS;
		SqlTransaction InvoiceTrans;
		public DateTime lObjCreate;

		public List<InvoiceItem> InvoiceItems;

		private string ConnStr;
		private string UserID;

		public InvoiceClass()
        {
			InvoiceCustomer = new CustomerClss();
			InvoiceItems = new List<InvoiceItem>();
		}

		public InvoiceClass(string isConStr, string isUserID)
        {
			ConnStr = isConStr;
			UserID = isUserID;
        }
		public void Save(string isConnStr)
        {
			Login lObjLog = new Login();
			lObjConn = new SqlConnection(isConnStr);
			lObjConn.Open();
			string lsQryText = "INSERT INTO [Invoice2122]";

			lsQryText += "(InvoiceDate, InvoiceSts, CustNo, CustFName, CustLName, CustMobNo, CustEmail, CustSts, CustType, CustStAddr, CustArAddr, CustCity,"; // 11
			lsQryText += "CustState, CustPinCode, CustCountry, CustGSTNo, CustLastVisit, CustRemarks, VehicleRegNo, VehicleModel, ChassisNo,";//9
			lsQryText += "EngineNo, Mileage, ServiceType, ServiceAssoName, ServiceAssoMobNo, PartsTotal, LabourTotal, PartsCGSTTotal, LabourCGSTTotal,";//9
			lsQryText += "PartsSGSTTotal, LabourSGSTTotal, PartsIGSTTotal, LabourIGSTTotal, TotalSGST, TotalCGST, TotalIGST, TotalTax, TotalAmount,";//9
			lsQryText += "GrandTotal, DiscountAmount, InvoiceTotal, InvoiceRemarks, Created, CreatedBy, Deleted,InsertTime) OUTPUT INSERTED.InvoiceSNo VALUES( ";//7

			lsQryText += "@InvoiceDate, @InvoiceSts, @CustNo, @CustFName, @CustLName, @CustMobNo, @CustEmail, @CustSts, @CustType, @CustStAddr, @CustArAddr, @CustCity,";//11
			lsQryText += "@CustState, @CustPinCode, @CustCountry, @CustGSTNo, @CustlLastVisit, @CustRemarks, @VehicleRegNo, @VehicleModel, @ChassisNo,";//9
			lsQryText += "@EngineNo, @Mileage, @ServiceType, @ServiceAssoName, @ServiceAssoMobNo, @PartsTotal, @LabourTotal, @PartsCGSTTotal, @LabourCGSTTotal,";//9
			lsQryText += "@PartsSGSTTotal,@LabourSGSTTotal,@PartsIGSTTotal,@LabourIGSTTotal,@TotalSGST,@TotalCGST, @TotalIGST, @TotalTax, @TotalAmount,";//9
			lsQryText += "@GrandTotal, @DiscountAmount, @InvoiceTotal, @InvoiceRemarks,@Created, @CreatedBy, @Deleted,@InsertTime)";//7

			cmd = new SqlCommand();
			cmd.CommandType = CommandType.Text;

			cmd.Parameters.AddWithValue("@InvoiceDate", SqlDbType.DateTime).Value = DateTime.Now;
			cmd.Parameters.AddWithValue("@InvoiceSts", SqlDbType.VarChar).Value = "SAVED";
			cmd.Parameters.AddWithValue("@CustNo", SqlDbType.Int).Value = InvoiceCustomer.CustNo;
			cmd.Parameters.AddWithValue("@CustFName", SqlDbType.VarChar).Value = InvoiceCustomer.CustFName;
			cmd.Parameters.AddWithValue("@CustLName", SqlDbType.VarChar).Value = InvoiceCustomer.CustLName;
			cmd.Parameters.AddWithValue("@CustMobNo", SqlDbType.VarChar).Value = InvoiceCustomer.CustMobNo;
			cmd.Parameters.AddWithValue("@CustEmail", SqlDbType.VarChar).Value = InvoiceCustomer.CustEmail;
			cmd.Parameters.AddWithValue("@CustSts", SqlDbType.VarChar).Value = InvoiceCustomer.CustSts;
			cmd.Parameters.AddWithValue("@CustType", SqlDbType.VarChar).Value = InvoiceCustomer.CustType;
			cmd.Parameters.AddWithValue("@CustStAddr", SqlDbType.VarChar).Value = (object)InvoiceCustomer.CustStAddr ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@CustArAddr", SqlDbType.VarChar).Value = (object)InvoiceCustomer.CustArAddr ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@CustCity", SqlDbType.VarChar).Value = (object)InvoiceCustomer.CustCity ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@CustState", SqlDbType.VarChar).Value = (object)InvoiceCustomer.CustState ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@CustPinCode", SqlDbType.VarChar).Value = (object)InvoiceCustomer.CustPinCode ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@CustCountry", SqlDbType.VarChar).Value = (object)InvoiceCustomer.CustCountry ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@CustGSTNo", SqlDbType.VarChar).Value = (object)InvoiceCustomer.CustGSTNo ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@CustlLastVisit", SqlDbType.DateTime).Value = DateTime.Now;
			cmd.Parameters.AddWithValue("@CustRemarks", SqlDbType.VarChar).Value = (object)InvoiceCustomer.CustRemarks ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@VehicleRegNo", SqlDbType.VarChar).Value = (object)VehicleRegNo ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@VehicleModel", SqlDbType.VarChar).Value = (object)VehicleModel ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@ChassisNo", SqlDbType.VarChar).Value = (object)ChassisNo ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@EngineNo", SqlDbType.VarChar).Value = (object)EngineNo ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@Mileage", SqlDbType.Int).Value = (object)Mileage ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@ServiceType", SqlDbType.VarChar).Value = (object)ServiceType ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@ServiceAssoName", SqlDbType.VarChar).Value = (object)ServiceAssoName ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@ServiceAssoMobNo", SqlDbType.VarChar).Value = (object)ServiceAssoMobNo ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@PartsTotal", SqlDbType.Float).Value = (object)PartsTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@LabourTotal", SqlDbType.Float).Value = (object)LabourTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@PartsCGSTTotal", SqlDbType.Float).Value = (object)PartsCGSTTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@LabourCGSTTotal", SqlDbType.Float).Value = (object)LabourCGSTTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@PartsSGSTTotal", SqlDbType.Float).Value = (object)PartsSGSTTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@LabourSGSTTotal", SqlDbType.Float).Value = (object)LabourSGSTTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@PartsIGSTTotal", SqlDbType.Float).Value = (object)PartsIGSTTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@LabourIGSTTotal", SqlDbType.Float).Value = (object)LabourIGSTTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@TotalSGST", SqlDbType.Float).Value = (object)TotalSGST ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@TotalCGST", SqlDbType.Float).Value = (object)TotalCGST ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@TotalIGST", SqlDbType.Float).Value = (object)TotalIGST ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@TotalTax", SqlDbType.Float).Value = (object)TotalTax ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@TotalAmount", SqlDbType.Float).Value = (object)TotalAmount ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@GrandTotal", SqlDbType.Float).Value = (object)GrandTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@DiscountAmount", SqlDbType.Float).Value = (object)DiscountAmount ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@InvoiceTotal", SqlDbType.Float).Value = (object)InvoiceTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@InvoiceRemarks", SqlDbType.VarChar).Value = (object)InvoiceRemarks ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@Created", SqlDbType.DateTime).Value = DateTime.Now;
			cmd.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = Login.SetValueForText1;
			cmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = "N";
			cmd.Parameters.AddWithValue("@InsertTime", SqlDbType.VarChar).Value = "R";
			cmd.CommandText = lsQryText;
			cmd.Connection = lObjConn;
			cmd.ExecuteNonQuery();
			lObjCreate = DateTime.Now;
		}
		public void SearchInvoiceItem(string isConnStr, int isInvoiceSNo)
        {
			lObjConn = new SqlConnection(isConnStr);
			lObjConn.Open();
			string lsQuery = "select * from [InvoiceItem2122] where InvoiceSNo=@InvoiceSNo and Deleted=@Deleted";
			cmd = new SqlCommand();
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.AddWithValue("@InvoiceSNo", SqlDbType.VarChar).Value = isInvoiceSNo;
			cmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = 'N';
			cmd.CommandText = lsQuery;
			cmd.Connection = lObjConn;
			lObjRead = cmd.ExecuteReader();
			while (lObjRead.Read())
			{
				InvoiceItem lObjInvoiceItem = new InvoiceItem();
				lObjInvoiceItem.InvoiceItemSNo = Convert.ToInt32(lObjRead[0]);
				InvoiceSNo = Convert.ToInt32(lObjRead[1]);
				lObjInvoiceItem.ItemNo = Convert.ToInt32(lObjRead[2]);
				lObjInvoiceItem.ItemDesc = lObjRead[3].ToString();
				lObjInvoiceItem.ItemType = lObjRead[4].ToString();
				lObjInvoiceItem.ItemCatg = lObjRead[5].ToString();
				lObjInvoiceItem.ItemPrice = Convert.ToDouble(lObjRead[6]);
				lObjInvoiceItem.ItemUOM = lObjRead[7].ToString();
				lObjInvoiceItem.ItemSts = lObjRead[8].ToString();
				lObjInvoiceItem.CGSTRate = Convert.ToDouble(lObjRead[9]);
				lObjInvoiceItem.SGSTRate = Convert.ToDouble(lObjRead[10]);
				lObjInvoiceItem.IGSTRate = Convert.ToDouble(lObjRead[11]);
				lObjInvoiceItem.UPCCode = lObjRead[12].ToString();
				lObjInvoiceItem.HSNCode = lObjRead[13].ToString();
				lObjInvoiceItem.SACCode = lObjRead[14].ToString();
				lObjInvoiceItem.Qty = Convert.ToDouble(lObjRead[15]);
				lObjInvoiceItem.SGSTAmount = Convert.ToDouble(lObjRead[16]);
				lObjInvoiceItem.CGSTAmount = Convert.ToDouble(lObjRead[17]);
				lObjInvoiceItem.IGSTAmount = Convert.ToDouble(lObjRead[18]);
				lObjInvoiceItem.DiscountAmount = Convert.ToDouble(lObjRead[19]);
				lObjInvoiceItem.TotalAmount = Convert.ToDouble(lObjRead[20]);
				InvoiceItems.Add(lObjInvoiceItem);
			}
			lObjRead.Close();
		}
		public bool SearchInvoice(String isConnStr, string isbtnCustomerSearchOpen)
        {
			bool lbFlag = true;
			lObjConn = new SqlConnection(isConnStr);
			lObjConn.Open();
			string lsQryText = "SELECT * FROM [Invoice2122] where CustMobNo=@CustMobNo";
			cmd = new SqlCommand();
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.AddWithValue("@CustMobNo", SqlDbType.VarChar).Value = isbtnCustomerSearchOpen;
			cmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = 'N';
			cmd.CommandText = lsQryText;
			cmd.Connection = lObjConn;
			lObjAdpt = new SqlDataAdapter(cmd);
			lObjDS = new DataSet();
			lObjAdpt.Fill(lObjDS);  
			lObjRead = cmd.ExecuteReader();
			while (lObjRead.Read())
			{
				InvoiceNo = lObjRead[0].ToString();
				InvoiceSNo = Convert.ToInt32(lObjRead[1]);
				InvoiceDate = Convert.ToDateTime(lObjRead[2]);
				InvoiceSts = lObjRead[3].ToString();
				InvoiceCustomer.CustNo = Convert.ToInt32(lObjRead[4]);
				InvoiceCustomer.CustFName = lObjRead[5].ToString();
				InvoiceCustomer.CustLName = lObjRead[6].ToString();
				InvoiceCustomer.CustMobNo = lObjRead[7].ToString();
				InvoiceCustomer.CustEmail = lObjRead[8].ToString();
				InvoiceCustomer.CustSts = lObjRead[9].ToString();
				InvoiceCustomer.CustType = lObjRead[10].ToString();
				InvoiceCustomer.CustStAddr = lObjRead[11].ToString();
				InvoiceCustomer.CustArAddr = lObjRead[12].ToString();
				InvoiceCustomer.CustCity = lObjRead[13].ToString();
				InvoiceCustomer.CustState = lObjRead[14].ToString();
				InvoiceCustomer.CustPinCode = lObjRead[15].ToString();
				InvoiceCustomer.CustCountry = lObjRead[16].ToString();
				InvoiceCustomer.CustGSTNo = lObjRead[17].ToString();
				InvoiceCustomer.CustLastVisit = Convert.ToDateTime(lObjRead[18].ToString());
				InvoiceCustomer.CustRemarks = lObjRead[19].ToString();
				VehicleRegNo = lObjRead[20].ToString();
				VehicleModel = lObjRead[21].ToString();
				ChassisNo = lObjRead[22].ToString();
				EngineNo = lObjRead[23].ToString();
				Mileage = Convert.ToInt32(lObjRead[24]);
				ServiceType = lObjRead[25].ToString();
				ServiceAssoName = lObjRead[26].ToString();
				ServiceAssoMobNo = lObjRead[27].ToString();
				PartsTotal = Convert.ToDouble(lObjRead[28]);
				LabourTotal = Convert.ToDouble(lObjRead[29]);
				PartsCGSTTotal = Convert.ToDouble(lObjRead[30]);
				LabourCGSTTotal = Convert.ToDouble(lObjRead[31]);
				PartsSGSTTotal = Convert.ToDouble(lObjRead[32]);
				LabourSGSTTotal = Convert.ToDouble(lObjRead[33]);
				PartsIGSTTotal = Convert.ToDouble(lObjRead[34]);
				LabourIGSTTotal = Convert.ToDouble(lObjRead[35]);
				TotalSGST = Convert.ToDouble(lObjRead[36]);
				TotalCGST = Convert.ToDouble(lObjRead[37]);
				TotalIGST = Convert.ToDouble(lObjRead[38]);
				TotalTax = Convert.ToDouble(lObjRead[39]);
				TotalAmount = Convert.ToDouble(lObjRead[40]);
				GrandTotal = Convert.ToDouble(lObjRead[41]);
				DiscountAmount = Convert.ToDouble(lObjRead[42]);
				InvoiceTotal = Convert.ToDouble(lObjRead[43]);
				InvoiceRemarks = lObjRead[44].ToString();
				Created = Convert.ToDateTime(lObjRead[45]);
				CreatedBy = lObjRead[46].ToString();
				Modified = Convert.ToDateTime(lObjRead[47].ToString());
				ModifiedBy = lObjRead[48].ToString();
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
		public void Update(string isConnStr)
        {
			lObjConn = new SqlConnection(isConnStr);
			lObjConn.Open();
			string lsQryText = "UPDATE [Invoice2122] SET ";

			lsQryText += "CustNo = @CustNo, CustFName = @CustFName, CustLName=@CustLName, CustMobNo=@CustMobNo, CustEmail=@CustEmail,";
			lsQryText += "CustSts=@CustSts, CustType=@CustType, CustStAddr=@CustStAddr, CustArAddr=@CustArAddr, CustCity=@CustCity,"; // 11
			lsQryText += "CustState=@CustState, CustPinCode=@CustPinCode, CustCountry=@CustCountry, CustGSTNo=@CustGSTNo, CustLastVisit= @CustlLastVisit,";
			lsQryText += "CustRemarks=@CustRemarks, VehicleRegNo=@VehicleRegNo, VehicleModel=@VehicleModel, ChassisNo=@ChassisNo,";//9
			lsQryText += "EngineNo=@EngineNo, Mileage=@Mileage, ServiceType=@ServiceType, ServiceAssoName=@ServiceAssoName, ServiceAssoMobNo=@ServiceAssoMobNo,";
			lsQryText += "PartsTotal=@PartsTotal, LabourTotal=@LabourTotal, PartsCGSTTotal=@PartsCGSTTotal, LabourCGSTTotal=@LabourCGSTTotal,";//9
			lsQryText += "PartsSGSTTotal=@PartsSGSTTotal, LabourSGSTTotal=@LabourSGSTTotal, PartsIGSTTotal=@PartsIGSTTotal, LabourIGSTTotal=@LabourIGSTTotal,";
			lsQryText += "TotalSGST=@TotalSGST, TotalCGST=@TotalCGST, TotalIGST=@TotalIGST, TotalTax=@TotalTax, TotalAmount=@TotalAmount,";//9
			lsQryText += "GrandTotal=@GrandTotal, DiscountAmount=@DiscountAmount, InvoiceTotal=@InvoiceTotal, InvoiceRemarks=@InvoiceRemarks, Modified=@Modified, ModifiedBy=@ModifiedBy ";//7
			lsQryText += "WHERE InnvoiceNo= @InnvoiceNo";

			cmd.CommandText = lsQryText;
			cmd.CommandType = CommandType.Text;

			cmd.Parameters.AddWithValue("@CustNo", SqlDbType.Int).Value = InvoiceCustomer.CustNo;
			cmd.Parameters.AddWithValue("@CustFName", SqlDbType.VarChar).Value = InvoiceCustomer.CustFName;
			cmd.Parameters.AddWithValue("@CustLName", SqlDbType.VarChar).Value = InvoiceCustomer.CustLName;
			cmd.Parameters.AddWithValue("@CustMobNo", SqlDbType.VarChar).Value = InvoiceCustomer.CustMobNo;
			cmd.Parameters.AddWithValue("@CustEmail", SqlDbType.VarChar).Value = InvoiceCustomer.CustEmail;
			cmd.Parameters.AddWithValue("@CustSts", SqlDbType.VarChar).Value = InvoiceCustomer.CustSts;
			cmd.Parameters.AddWithValue("@CustType", SqlDbType.VarChar).Value = InvoiceCustomer.CustType;
			cmd.Parameters.AddWithValue("@CustStAddr", SqlDbType.VarChar).Value = (object)InvoiceCustomer.CustStAddr ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@CustArAddr", SqlDbType.VarChar).Value = (object)InvoiceCustomer.CustArAddr ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@CustCity", SqlDbType.VarChar).Value = (object)InvoiceCustomer.CustCity ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@CustState", SqlDbType.VarChar).Value = (object)InvoiceCustomer.CustState ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@CustPinCode", SqlDbType.VarChar).Value = (object)InvoiceCustomer.CustPinCode ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@CustCountry", SqlDbType.VarChar).Value = (object)InvoiceCustomer.CustCountry ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@CustGSTNo", SqlDbType.VarChar).Value = (object)InvoiceCustomer.CustGSTNo ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@CustlLastVisit", SqlDbType.DateTime).Value = DateTime.Now;
			cmd.Parameters.AddWithValue("@CustRemarks", SqlDbType.VarChar).Value = (object)InvoiceCustomer.CustRemarks ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@VehicleRegNo", SqlDbType.VarChar).Value = (object)VehicleRegNo ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@VehicleModel", SqlDbType.VarChar).Value = (object)VehicleModel ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@ChassisNo", SqlDbType.VarChar).Value = (object)ChassisNo ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@EngineNo", SqlDbType.VarChar).Value = (object)EngineNo ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@Mileage", SqlDbType.Int).Value = (object)Mileage ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@ServiceType", SqlDbType.VarChar).Value = (object)ServiceType ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@ServiceAssoName", SqlDbType.VarChar).Value = (object)ServiceAssoName ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@ServiceAssoMobNo", SqlDbType.VarChar).Value = (object)ServiceAssoMobNo ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@PartsTotal", SqlDbType.Float).Value = (object)PartsTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@LabourTotal", SqlDbType.Float).Value = (object)LabourTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@PartsCGSTTotal", SqlDbType.Float).Value = (object)PartsCGSTTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@LabourCGSTTotal", SqlDbType.Float).Value = (object)LabourCGSTTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@PartsSGSTTotal", SqlDbType.Float).Value = (object)PartsSGSTTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@LabourSGSTTotal", SqlDbType.Float).Value = (object)LabourSGSTTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@PartsIGSTTotal", SqlDbType.Float).Value = (object)PartsIGSTTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@LabourIGSTTotal", SqlDbType.Float).Value = (object)LabourIGSTTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@TotalSGST", SqlDbType.Float).Value = (object)TotalSGST ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@TotalCGST", SqlDbType.Float).Value = (object)TotalCGST ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@TotalIGST", SqlDbType.Float).Value = (object)TotalIGST ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@TotalTax", SqlDbType.Float).Value = (object)TotalTax ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@TotalAmount", SqlDbType.Float).Value = (object)TotalAmount ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@GrandTotal", SqlDbType.Float).Value = (object)GrandTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@DiscountAmount", SqlDbType.Float).Value = (object)DiscountAmount ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@InvoiceTotal", SqlDbType.Float).Value = (object)InvoiceTotal ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@InvoiceRemarks", SqlDbType.VarChar).Value = (object)InvoiceRemarks ?? DBNull.Value;
			cmd.Parameters.AddWithValue("@Modified", SqlDbType.DateTime).Value = DateTime.Now;
			cmd.Parameters.AddWithValue("@ModifiedBy", SqlDbType.VarChar).Value = Login.SetValueForText1;

			cmd.Parameters.AddWithValue("@InnvoiceNo", SqlDbType.Int).Value = InvoiceNo;

			cmd.ExecuteNonQuery();

		}
		public bool InvoiceDelete(string isConnStr)
        {
			bool lbFlag = true;
			lObjConn = new SqlConnection(isConnStr);
			lObjConn.Open();
			string lsQuery = "update [Invoice2122] set Deleted=@Deleted,DeletedOn=@DeletedOn,DeletedBy=@DeletedBy where InnvoiceNo=@InnvoiceNo";
			cmd = new SqlCommand();
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.AddWithValue("@InnvoiceNo", SqlDbType.VarChar).Value = Invoice.InvoiceNo;
			cmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = "Y";
			cmd.Parameters.AddWithValue("@DeletedOn", SqlDbType.VarChar).Value = DateTime.Now;
			cmd.Parameters.AddWithValue("@DeletedBy", SqlDbType.VarChar).Value = Login.SetValueForText1;
			cmd.CommandText = lsQuery;
			cmd.Connection = lObjConn;
			int rowsAffected = cmd.ExecuteNonQuery();
			if (rowsAffected > 0)
			{
				lbFlag = true;
			}
			else
			{
				lbFlag = false;
			}

			return lbFlag;
		}
	}
}
