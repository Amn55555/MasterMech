using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MasterMech
{
    class ItemClass
    {
        public int ItemNo;
        public string ItemDesc;
        public string ItemType;
        public string ItemCatg;
        public double ItemPrice;
        public string ItemUOM;
        public string ItemSts;
        public double CGSTRate;
        public double SGSTRate;
        public double IGSTRate;
        public string UPCCode;
        public string HSNCode;
        public string SACCode;
        public double QtyHand;
        public double ReOrderLvl;
        public double ReOrderQty;
        public int NoOfParts;
        public string ItemRemarks;
        public DateTime Created;
        public string CreatedBy;
        public string Modified;
        public string ModifiedBy;
        public char Deleted;
        public DateTime DeletedOn;
        public string DeletedBy;
        public string ItemDesc2;

        SqlConnection lObjConn;
        SqlCommand lObjCmd;
        SqlDataAdapter lObjAdpt;
        DataSet lObjDS;
        SqlDataReader lObjRead;

        String ConnStr = "";
        string UserID;
        String lsQuery = "";

        public ItemClass()
        {

        }
        public ItemClass(string isConnstr, string isUserID)
        {
            ConnStr = isConnstr;
            UserID = isUserID;
        }
        public ItemClass(int isItemNo, string isItemDesc, string isItemType, string isItemCatg, double isItemPrice, string isItemUOM, string isItemSts, double isCGSTRate, double isSGSTRate, double isIGSTRate, string isUPCCode, string isHSNCode, string isSACCode, double isQtyHand, double isReOrderLvl, double isReOrderQty, int isNoOfParts, string isItemRemarks, char isDeleted)
        {
            ItemNo = isItemNo;
            ItemDesc = isItemDesc;
            ItemType = isItemType;
            ItemCatg = isItemCatg;
            ItemPrice = isItemPrice;
            ItemUOM = isItemUOM;
            ItemSts = isItemSts;
            CGSTRate = isCGSTRate;
            SGSTRate = isSGSTRate;
            IGSTRate = isIGSTRate;
            UPCCode = isUPCCode;
            HSNCode = isHSNCode;
            SACCode = isSACCode;
            QtyHand = isQtyHand;
            ReOrderLvl = isReOrderLvl;
            ReOrderQty = isReOrderQty;
            NoOfParts = isNoOfParts;
            ItemRemarks = isItemRemarks;
            Deleted = isDeleted;

        }
        public void save(string isConnStr)
        {
            Login lObjLog = new Login();
            lObjConn = new SqlConnection(isConnStr);
            lObjConn.Open();
            lsQuery = "Insert Into ItemMaster(ItemDesc, ItemType, ItemCatg, ItemPrice, ItemUOM, ItemSts, CGSTRate, SGSTRate, IGSTRate, UPCCode, HSNCode, SACCode, QtyHand, ReOrderLvl, ReOrderQty, NoOfParts, ItemRemarks, Created, CreatedBy, Deleted)values(@ItemDesc, @ItemType, @ItemCatg, @ItemPrice, @ItemUOM, @ItemSts, @CGSTRate, @SGSTRate, @IGSTRate, @UPCCode, @HSNCode, @SACCode, @QtyHand, @ReOrderLvl, @ReOrderQty, @NoOfParts, @ItemRemarks, @Created, @CreatedBy, @Deleted)";
            lObjCmd = new SqlCommand();
            lObjCmd.CommandType = CommandType.Text;
            lObjCmd.Parameters.AddWithValue("@ItemDesc", SqlDbType.VarChar).Value = ItemDesc;
            lObjCmd.Parameters.AddWithValue("@ItemType", SqlDbType.VarChar).Value = ItemType;
            lObjCmd.Parameters.AddWithValue("@Itemcatg", SqlDbType.VarChar).Value = ItemCatg;
            lObjCmd.Parameters.AddWithValue("@ItemPrice", SqlDbType.VarChar).Value = ItemPrice;
            lObjCmd.Parameters.AddWithValue("@ItemUOM", SqlDbType.VarChar).Value = ItemUOM;
            lObjCmd.Parameters.AddWithValue("@ItemSts", SqlDbType.VarChar).Value = ItemSts;
            lObjCmd.Parameters.AddWithValue("@CGSTRate", SqlDbType.VarChar).Value = CGSTRate;
            lObjCmd.Parameters.AddWithValue("@SGSTRate", SqlDbType.VarChar).Value = SGSTRate;
            lObjCmd.Parameters.AddWithValue("@IGSTRate", SqlDbType.VarChar).Value = IGSTRate;
            lObjCmd.Parameters.AddWithValue("@UPCCode", SqlDbType.VarChar).Value = UPCCode;
            lObjCmd.Parameters.AddWithValue("@HSNCode", SqlDbType.VarChar).Value = HSNCode;
            lObjCmd.Parameters.AddWithValue("@SACCode", SqlDbType.VarChar).Value = SACCode;
            lObjCmd.Parameters.AddWithValue("@QtyHand", SqlDbType.VarChar).Value = QtyHand;
            lObjCmd.Parameters.AddWithValue("@ReOrderLvl", SqlDbType.VarChar).Value = ReOrderLvl;
            lObjCmd.Parameters.AddWithValue("@ReOrderQty", SqlDbType.VarChar).Value = ReOrderQty;
            lObjCmd.Parameters.AddWithValue("@NoOfParts", SqlDbType.VarChar).Value = NoOfParts;
            lObjCmd.Parameters.AddWithValue("@ItemRemarks", SqlDbType.VarChar).Value = ItemRemarks;
            lObjCmd.Parameters.AddWithValue("@Created", SqlDbType.VarChar).Value = DateTime.Now;
            lObjCmd.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = Login.SetValueForText1;
            lObjCmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = "N";
            lObjCmd.CommandText = lsQuery;
            lObjCmd.Connection = lObjConn;
            lObjCmd.ExecuteNonQuery();
        }
        public void Update(string isConnStr)
        {
            lObjConn = new SqlConnection(isConnStr);
            lObjConn.Open();
            lsQuery = "update ItemMaster set ItemDesc=@ItemDesc, ItemType=@ItemType, ItemCatg=@itemCatg, ItemPrice=@ItemPrice, ItemUOM=@ItemUOM, ItemSts=@ItemSts, CGSTRate=@CGSTRate, SGSTRate=@SGSTRate, IGSTRate=@IGSTRate, UPCCode=@UPCCode, HSNCode=@HSNCode, SACCode=@SACCode, QtyHand=@QtyHand, ReOrderLvl=@ReOrderLvl, ReOrderQty=@ReOrderQty, NoOfParts=@ReOrderQty, ItemRemarks=@ItemRemarks, Modified=@Modified, ModifiedBy=@ModifiedBy Where ItemNo=@ItemNo";
            lObjCmd = new SqlCommand();
            lObjCmd.CommandType = CommandType.Text;
            lObjCmd.Parameters.AddWithValue("@ItemNo", SqlDbType.VarChar).Value = ItemNo;
            lObjCmd.Parameters.AddWithValue("@ItemDesc", SqlDbType.VarChar).Value = ItemDesc2;
            lObjCmd.Parameters.AddWithValue("@ItemType", SqlDbType.VarChar).Value = ItemType;
            lObjCmd.Parameters.AddWithValue("@ItemCatg", SqlDbType.VarChar).Value = ItemCatg;
            lObjCmd.Parameters.AddWithValue("@ItemPrice", SqlDbType.VarChar).Value = ItemPrice;
            lObjCmd.Parameters.AddWithValue("@ItemUOM", SqlDbType.VarChar).Value = ItemUOM;
            lObjCmd.Parameters.AddWithValue("@ItemSts", SqlDbType.VarChar).Value = ItemSts;
            lObjCmd.Parameters.AddWithValue("@CGSTRate", SqlDbType.VarChar).Value = CGSTRate;
            lObjCmd.Parameters.AddWithValue("@SGSTRate", SqlDbType.VarChar).Value = SGSTRate;
            lObjCmd.Parameters.AddWithValue("@IGSTRate", SqlDbType.VarChar).Value = IGSTRate;
            lObjCmd.Parameters.AddWithValue("@UPCCode", SqlDbType.VarChar).Value = UPCCode;
            lObjCmd.Parameters.AddWithValue("@HSNCode", SqlDbType.VarChar).Value = HSNCode;
            lObjCmd.Parameters.AddWithValue("@SACCode", SqlDbType.VarChar).Value = SACCode;
            lObjCmd.Parameters.AddWithValue("@QtyHand", SqlDbType.VarChar).Value = QtyHand;
            lObjCmd.Parameters.AddWithValue("@ReOrderLvl", SqlDbType.VarChar).Value = ReOrderLvl;
            lObjCmd.Parameters.AddWithValue("@ReOrderQty", SqlDbType.VarChar).Value = ReOrderQty;
            lObjCmd.Parameters.AddWithValue("@NoOfParts", SqlDbType.VarChar).Value = NoOfParts;
            lObjCmd.Parameters.AddWithValue("@ItemRemarks", SqlDbType.VarChar).Value = ItemRemarks;
            lObjCmd.Parameters.AddWithValue("@Modified", SqlDbType.VarChar).Value = DateTime.Now;
            lObjCmd.Parameters.AddWithValue("@ModifiedBy", SqlDbType.VarChar).Value = Login.SetValueForText1;
            lObjCmd.CommandText = lsQuery;
            lObjCmd.Connection = lObjConn;
            lObjCmd.ExecuteNonQuery();
        }
        public bool Search(string isConnStr, string isItemDesc)
        {
            bool lbFlag = true;
            lObjConn = new SqlConnection(isConnStr);
            lObjConn.Open();
            lsQuery = "select * from ItemMaster where ItemDesc=@ItemDesc and Deleted=@Deleted";
            lObjCmd = new SqlCommand();
            lObjCmd.CommandType = CommandType.Text;
            lObjCmd.Parameters.AddWithValue("@ItemDesc", SqlDbType.VarChar).Value = isItemDesc;
            lObjCmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = 'N';
            lObjCmd.CommandText = lsQuery;
            lObjCmd.Connection = lObjConn;
            lObjAdpt = new SqlDataAdapter(lObjCmd);
            lObjDS = new DataSet();
            lObjAdpt.Fill(lObjDS);
            lObjRead = lObjCmd.ExecuteReader();
            while (lObjRead.Read())
            {
                ItemNo = Convert.ToInt32(lObjRead[0]);
                ItemDesc2 = lObjRead[1].ToString();
                ItemType = lObjRead[2].ToString();
                ItemCatg = lObjRead[3].ToString();
                ItemPrice = Convert.ToDouble(lObjRead[4]);
                ItemUOM = lObjRead[5].ToString();
                ItemSts = lObjRead[6].ToString();
                CGSTRate = Convert.ToDouble(lObjRead[7]);
                SGSTRate = Convert.ToDouble(lObjRead[8]);
                IGSTRate = Convert.ToDouble(lObjRead[9]);
                UPCCode = lObjRead[10].ToString();
                HSNCode = lObjRead[11].ToString();
                SACCode = lObjRead[12].ToString();
                QtyHand = Convert.ToDouble(lObjRead[13]);
                ReOrderLvl = Convert.ToDouble(lObjRead[14]);
                ReOrderQty = Convert.ToDouble(lObjRead[15]);
                NoOfParts = Convert.ToInt32(lObjRead[16]);
                ItemRemarks = lObjRead[17].ToString();
                Created = Convert.ToDateTime(lObjRead[18]);
                CreatedBy = lObjRead[19].ToString();
                Modified = lObjRead[20].ToString();
                ModifiedBy = lObjRead[21].ToString();
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
        public void Delete(string isConnStr)
        {
            lObjConn = new SqlConnection(isConnStr);
            lObjConn.Open();
            lsQuery = "update ItemMaster set Deleted=@Deleted,DeletedOn=@DeletedOn,DeletedBy=@DeletedBy where ItemNo=@ItemNo";
            lObjCmd = new SqlCommand();
            lObjCmd.CommandType = CommandType.Text;
            lObjCmd.Parameters.AddWithValue("@ItemNo", SqlDbType.VarChar).Value = ItemNo;
            lObjCmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = "Y";
            lObjCmd.Parameters.AddWithValue("@DeletedOn", SqlDbType.VarChar).Value = DateTime.Now;
            lObjCmd.Parameters.AddWithValue("@DeletedBy", SqlDbType.VarChar).Value = Login.SetValueForText1;
            lObjCmd.CommandText = lsQuery;
            lObjCmd.Connection = lObjConn;
            lObjCmd.ExecuteNonQuery();
        }

        public bool SearchItem(string isConStr, string isItemDesc)
        {
            bool lbFlag = true;
            lObjConn = new SqlConnection(isConStr);
            lObjConn.Open();
            lsQuery = "select * from ItemMaster where ItemDesc=@ItemDesc and Deleted=@Deleted";
            lObjCmd = new SqlCommand();
            lObjCmd.CommandType = CommandType.Text;
            lObjCmd.Parameters.AddWithValue("@ItemDesc", SqlDbType.VarChar).Value = isItemDesc;
            lObjCmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = 'N';
            lObjCmd.CommandText = lsQuery;
            lObjCmd.Connection = lObjConn;
            lObjAdpt = new SqlDataAdapter(lObjCmd);
            lObjDS = new DataSet();
            lObjAdpt.Fill(lObjDS);
            lObjRead = lObjCmd.ExecuteReader();
            while (lObjRead.Read())
            {
                ItemNo = Convert.ToInt32(lObjRead[0]);
                ItemDesc = lObjRead[1].ToString();
                ItemType = lObjRead[2].ToString();
                ItemCatg = lObjRead[3].ToString();
                ItemPrice = Convert.ToDouble(lObjRead[4]);
                ItemUOM = lObjRead[5].ToString();
                ItemSts = lObjRead[6].ToString();
                CGSTRate = Convert.ToDouble(lObjRead[7]);
                SGSTRate = Convert.ToDouble(lObjRead[8]);
                IGSTRate = Convert.ToDouble(lObjRead[9]);
                UPCCode = lObjRead[10].ToString();
                HSNCode = lObjRead[11].ToString();
                SACCode = lObjRead[12].ToString();
                QtyHand = Convert.ToDouble(lObjRead[13]);
                ReOrderLvl = Convert.ToDouble(lObjRead[14]);
                ReOrderQty = Convert.ToDouble(lObjRead[15]);
                NoOfParts = Convert.ToInt32(lObjRead[16]);
                ItemRemarks = lObjRead[17].ToString();
                Created = Convert.ToDateTime(lObjRead[18]);
                CreatedBy = lObjRead[19].ToString();
                Modified = lObjRead[20].ToString();
                ModifiedBy = lObjRead[21].ToString();
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
    }
}
