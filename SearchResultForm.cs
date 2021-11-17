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
    public partial class SearchResultForm : Form
    {
        int gnLevelNo = 0;
        string lsSearch;
        public string lsCustNo;
        public string lsCustFName;
        public string lsCustLName;
        public string lsCustMobNo;
        public string lsCustEmail;
        public string lsCustSts;
        public string lsCustType;
        public string lsCustStAddr;
        public string lsCustArAddr;
        public string lsCustCity;
        public string lsCustState;
        public string lsCustPinCode;
        public string lsCustCountry;
        public string lsCustGSTNo;
        public string lsCustLastVisit;
        public string lsCustRemarks;
        public string lsItemNo;
        public string lsItemDesc;
        public string lsItemPrice;
        public string lsItemUOM;
        public string lsItemType;
        public string lsSGST;
        public string lsCGST;
        public string lsIGST;
        public string lsInvoiceNo;
        public string lsInvoiceSNo;
        public string lsInvoiceDate;
        public string lsVehicleRegNo;
        public string lsVehicleModel;
        public string lsChassisNo;
        public string lsEngineNo;
        public string lsMileage;
        public string lsServiceType;
        public string lsServiceAssoName;
        public string lsServiceAssoMobNo;
        public string lsPartsTotal;
        public string lsLabourTotal;
        public string lsPartsCGSTTotal;
        public string lsLabourCGSTTotal;
        public string lsPartsSGSTTotal;
        public string lsLabourSGSTTotal;
        public string lsPartsIGSTTotal;
        public string lsLabourIGSTTotal;
        public string lsTotalSGST;
        public string lsTotalCGST;
        public string lsTotalIGST;
        public string lsTotalTax;
        public string lsTotalAmount;
        public string lsGrandTotal;
        public string lsDiscountAmount;
        public string lsInvoiceTotal;
        public string lsInvoiceRemarks;


        SqlConnection lObjConn;
        SqlCommand lObjCmd;
        SqlDataAdapter lObjAdpt;
        DataSet lObjDS;

        String lsConnStr = "";
        String lsQuery = "";
        public SearchResultForm(int inLevelNo, string isSearch)
        {
            InitializeComponent();
            lsSearch = isSearch;
            gnLevelNo = inLevelNo;
        }

        public static DataGridViewRow SelectedRow { get; set; }
        

        private void SearchResultForm_Load(object sender, EventArgs e)
        {
            lsConnStr = "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=MechMaster; Data Source=LAPTOP-SQ607JC2\\SQLEXPRESS";
            lObjConn = new SqlConnection(lsConnStr);
            lObjConn.Open();
            if (gnLevelNo == 1)
            {
                lsQuery = "select * from Customer where CustMobNo LIKE @CustMobileNo and Deleted=@Deleted";
                lObjCmd = new SqlCommand();
                lObjCmd.CommandType = CommandType.Text;
                lObjCmd.Parameters.AddWithValue("@CustMobileNo", SqlDbType.VarChar).Value = "%" + lsSearch + "%";
                lObjCmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = 'N';
                lObjCmd.CommandText = lsQuery;
                lObjCmd.Connection = lObjConn;
                lObjAdpt = new SqlDataAdapter(lObjCmd);
                lObjDS = new DataSet();
                lObjAdpt.Fill(lObjDS);
                dataGridView1.DataSource = lObjDS.Tables[0];
            }
            if (gnLevelNo == 2)
            {
                lsQuery = "select * from ItemMaster where ItemDesc LIKE @ItemDesc and Deleted=@Deleted";
                lObjCmd = new SqlCommand();
                lObjCmd.CommandType = CommandType.Text;
                lObjCmd.Parameters.AddWithValue("@ItemDesc", SqlDbType.VarChar).Value = "%" + lsSearch + "%";
                lObjCmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = 'N';
                lObjCmd.CommandText = lsQuery;
                lObjCmd.Connection = lObjConn;
                lObjAdpt = new SqlDataAdapter(lObjCmd);
                lObjDS = new DataSet();
                lObjAdpt.Fill(lObjDS);
                dataGridView1.DataSource = lObjDS.Tables[0];
            }
            if (gnLevelNo == 3)
            {
                lsQuery = "select * from [Invoice2122] where CustMobNo LIKE @CustMobNo and Deleted=@Deleted";
                lObjCmd = new SqlCommand();
                lObjCmd.CommandType = CommandType.Text;
                lObjCmd.Parameters.AddWithValue("@CustMobNo", SqlDbType.VarChar).Value = "%" + lsSearch + "%";
                lObjCmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = 'N';
                lObjCmd.CommandText = lsQuery;
                lObjCmd.Connection = lObjConn;
                lObjAdpt = new SqlDataAdapter(lObjCmd);
                lObjDS = new DataSet();
                lObjAdpt.Fill(lObjDS);

                dataGridView1.DataSource = lObjDS.Tables[0];
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedRow = dataGridView1.Rows[e.RowIndex];
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (gnLevelNo == 1)
            {
                lsCustNo = dataGridView1.SelectedCells[0].Value.ToString();
                lsCustFName = dataGridView1.SelectedCells[1].Value.ToString();
                lsCustLName = dataGridView1.SelectedCells[2].Value.ToString();
                lsCustMobNo = dataGridView1.SelectedCells[3].Value.ToString();
                lsCustEmail = dataGridView1.SelectedCells[4].Value.ToString();
                lsCustSts = dataGridView1.SelectedCells[5].Value.ToString();
                lsCustType = dataGridView1.SelectedCells[6].Value.ToString();
                lsCustStAddr = dataGridView1.SelectedCells[7].Value.ToString();
                lsCustArAddr = dataGridView1.SelectedCells[8].Value.ToString();
                lsCustCity = dataGridView1.SelectedCells[9].Value.ToString();
                lsCustState = dataGridView1.SelectedCells[10].Value.ToString();
                lsCustPinCode = dataGridView1.SelectedCells[11].Value.ToString();
                lsCustCountry = dataGridView1.SelectedCells[12].Value.ToString();
                lsCustGSTNo = dataGridView1.SelectedCells[13].Value.ToString();
                lsCustLastVisit = dataGridView1.SelectedCells[14].Value.ToString();
                lsCustRemarks = dataGridView1.SelectedCells[15].Value.ToString();
            }
            if (gnLevelNo == 2)
            {
                lsItemNo = dataGridView1.SelectedCells[0].Value.ToString();
                lsItemDesc = dataGridView1.SelectedCells[1].Value.ToString();
                lsItemPrice = dataGridView1.SelectedCells[4].Value.ToString();
                lsItemUOM = dataGridView1.SelectedCells[5].Value.ToString();
                lsSGST = dataGridView1.SelectedCells[8].Value.ToString();
                lsCGST = dataGridView1.SelectedCells[7].Value.ToString();
                lsIGST = dataGridView1.SelectedCells[9].Value.ToString();
                lsItemType = dataGridView1.SelectedCells[2].Value.ToString();
            }
            if (gnLevelNo == 3)
            {
                lsInvoiceNo = dataGridView1.SelectedCells[0].Value.ToString();
                lsInvoiceSNo = dataGridView1.SelectedCells[1].Value.ToString();
                lsInvoiceDate = dataGridView1.SelectedCells[2].Value.ToString();
                lsCustNo = dataGridView1.SelectedCells[4].Value.ToString();
                lsCustFName = dataGridView1.SelectedCells[5].Value.ToString();
                lsCustLName = dataGridView1.SelectedCells[6].Value.ToString();
                lsCustMobNo = dataGridView1.SelectedCells[7].Value.ToString();
                lsCustEmail = dataGridView1.SelectedCells[8].Value.ToString();
                lsCustSts = dataGridView1.SelectedCells[9].Value.ToString();
                lsCustType = dataGridView1.SelectedCells[10].Value.ToString();
                lsCustStAddr = dataGridView1.SelectedCells[11].Value.ToString();
                lsCustArAddr = dataGridView1.SelectedCells[12].Value.ToString();
                lsCustCity = dataGridView1.SelectedCells[13].Value.ToString();
                lsCustState = dataGridView1.SelectedCells[14].Value.ToString();
                lsCustPinCode = dataGridView1.SelectedCells[15].Value.ToString();
                lsCustCountry = dataGridView1.SelectedCells[16].Value.ToString();
                lsCustGSTNo = dataGridView1.SelectedCells[17].Value.ToString();
                lsCustLastVisit = dataGridView1.SelectedCells[18].Value.ToString();
                lsCustRemarks = dataGridView1.SelectedCells[19].Value.ToString();
                lsVehicleRegNo = dataGridView1.SelectedCells[20].Value.ToString();
                lsVehicleModel = dataGridView1.SelectedCells[21].Value.ToString();
                lsChassisNo = dataGridView1.SelectedCells[22].Value.ToString();
                lsEngineNo = dataGridView1.SelectedCells[23].Value.ToString();
                lsMileage = dataGridView1.SelectedCells[24].Value.ToString();
                lsServiceType = dataGridView1.SelectedCells[25].Value.ToString();
                lsServiceAssoName = dataGridView1.SelectedCells[26].Value.ToString();
                lsServiceAssoMobNo = dataGridView1.SelectedCells[27].Value.ToString();
                lsPartsTotal = dataGridView1.SelectedCells[28].Value.ToString();
                lsLabourTotal = dataGridView1.SelectedCells[29].Value.ToString();
                lsPartsCGSTTotal = dataGridView1.SelectedCells[30].Value.ToString();
                lsLabourCGSTTotal = dataGridView1.SelectedCells[31].Value.ToString();
                lsPartsSGSTTotal = dataGridView1.SelectedCells[32].Value.ToString();
                lsLabourSGSTTotal = dataGridView1.SelectedCells[33].Value.ToString();
                lsPartsIGSTTotal = dataGridView1.SelectedCells[34].Value.ToString();
                lsLabourIGSTTotal = dataGridView1.SelectedCells[35].Value.ToString();
                lsTotalSGST = dataGridView1.SelectedCells[36].Value.ToString();
                lsTotalCGST = dataGridView1.SelectedCells[37].Value.ToString();
                lsTotalIGST = dataGridView1.SelectedCells[38].Value.ToString();
                lsTotalTax = dataGridView1.SelectedCells[39].Value.ToString();
                lsTotalAmount = dataGridView1.SelectedCells[40].Value.ToString();
                lsGrandTotal = dataGridView1.SelectedCells[41].Value.ToString();
                lsDiscountAmount = dataGridView1.SelectedCells[42].Value.ToString();
                lsInvoiceTotal = dataGridView1.SelectedCells[43].Value.ToString();
                lsInvoiceRemarks = dataGridView1.SelectedCells[44].Value.ToString();
                //lsItemNo = dataGridView.SelectedCells[0].Value.ToString();
                //lsItemDesc = dataGridView.SelectedCells[1].Value.ToString();
                //lsItemPrice = dataGridView.SelectedCells[4].Value.ToString();
                //lsItemUOM = dataGridView.SelectedCells[5].Value.ToString();
                //lsSGST = dataGridView.SelectedCells[8].Value.ToString();
                //lsCGST = dataGridView.SelectedCells[7].Value.ToString();
                //lsIGST = dataGridView.SelectedCells[9].Value.ToString();
                //lsItemType = dataGridView.SelectedCells[2].Value.ToString();
            }
            this.Close();
        }
    }
}
