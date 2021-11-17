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
    public partial class Invoice : Form
    {
        List<CustomerClss> lObjCustomers = new List<CustomerClss>();
        CustomerClss lObjCustom = new CustomerClss();
        ItemClass lObjItem = new ItemClass();
        InvoiceClass lObjInvoice = new InvoiceClass();
        InvoiceItem lObjInvoiceItem = new InvoiceItem();
        
        SqlConnection lObjConn;
        SqlCommand lObjCmd;
        SqlDataAdapter lObjAdpt;
        DataSet lObjDS;
        SqlDataReader lObjRead;

        String lsConnStr = "";
        String lsQuery = "";

        public static string InvoiceNo;
        private bool mbSameState = true;
        int gnLevelNo = 0;

        private const int COL_SNO = 0;
        private const int COL_ITMNO = 1;
        private const int COL_ITMDSC = 2;
        private const int COL_ITMTYP = 3;
        private const int COL_ITMPRC = 4;
        private const int COL_ITMUOM = 5;
        private const int COL_ITMQTY = 6;
        private const int COL_SGSTP = 7;
        private const int COL_SGSTA = 8;
        private const int COL_CGSTP = 9;
        private const int COL_CGSTA = 10;
        private const int COL_IGSTP = 11;
        private const int COL_IGSTA = 12;
        private const int COL_GRSA = 13;
        private const int COL_DISC = 14;
        private const int COL_NAMT = 15;
        private const int COL_TTAX = 16;
        private const int COL_TAMT = 17;
        private const int COL_ITMC = 18;
        private const int COL_UPCC = 19;
        private const int COL_HSNC = 20;
        private const int COL_SACC = 21;
        private const int COL_STS = 22;
        private const int COL_IISNO = 23;
        public Invoice(int inLevelNo)
        {
            InitializeComponent();
            gnLevelNo = inLevelNo;
        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            lsConnStr = "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=MechMaster; Data Source=LAPTOP-SQ607JC2\\SQLEXPRESS";
            lObjConn = new SqlConnection(lsConnStr);
            lObjConn.Open();
            if (gnLevelNo == 1)
            {
                FunLevel1_Init();
            }
            if (gnLevelNo == 2)
            {
                FunLevel2_Init();
            }
            if (gnLevelNo == 3)
            {
                FunLevel3_Init();
            }
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnCount = 24;
            //dataGridViewLineItem.Columns[COL_MODE].Name = "Mode";
            //dataGridViewLineItem.Columns[COL_MODE].Visible = false;
            dataGridView1.Columns[COL_SNO].Name = "S.No";
            dataGridView1.Columns[COL_SNO].Width = 35;
            dataGridView1.Columns[COL_ITMNO].Name = "Item No";
            dataGridView1.Columns[COL_ITMNO].Width = 70;
            dataGridView1.Columns[COL_ITMNO].DefaultCellStyle.Padding = System.Windows.Forms.Padding.Empty;
            dataGridView1.Columns[COL_ITMDSC].Name = "Desc";
            dataGridView1.Columns[COL_ITMDSC].Width = 150;
            dataGridView1.Columns[COL_ITMTYP].Name = "Type";
            dataGridView1.Columns[COL_ITMTYP].Width = 60;
            dataGridView1.Columns[COL_ITMPRC].Name = "Price";
            dataGridView1.Columns[COL_ITMPRC].Width = 50;
            dataGridView1.Columns[COL_ITMPRC].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[COL_ITMUOM].Name = "UOM";
            dataGridView1.Columns[COL_ITMUOM].Width = 50;
            dataGridView1.Columns[COL_ITMQTY].Name = "Qty";
            dataGridView1.Columns[COL_ITMQTY].Width = 50;
            dataGridView1.Columns[COL_ITMQTY].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[COL_SGSTP].Name = "SGST%";
            dataGridView1.Columns[COL_SGSTP].Width = 50;
            dataGridView1.Columns[COL_SGSTP].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[COL_SGSTP].Visible = mbSameState;
            dataGridView1.Columns[COL_SGSTA].Name = "SGST";
            dataGridView1.Columns[COL_SGSTA].Width = 55;
            dataGridView1.Columns[COL_SGSTA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[COL_SGSTA].Visible = mbSameState;
            dataGridView1.Columns[COL_CGSTP].Name = "CGST%";
            dataGridView1.Columns[COL_CGSTP].Width = 50;
            dataGridView1.Columns[COL_CGSTP].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[COL_CGSTP].Visible = mbSameState;
            dataGridView1.Columns[COL_CGSTA].Name = "CGST";
            dataGridView1.Columns[COL_CGSTA].Width = 55;
            dataGridView1.Columns[COL_CGSTA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[COL_CGSTA].Visible = mbSameState;
            dataGridView1.Columns[COL_IGSTP].Name = "IGST%";
            dataGridView1.Columns[COL_IGSTP].Width = 50;
            dataGridView1.Columns[COL_IGSTP].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[COL_IGSTP].Visible = mbSameState;
            dataGridView1.Columns[COL_IGSTA].Name = "IGST";
            dataGridView1.Columns[COL_IGSTA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[COL_IGSTA].Width = 55;
            dataGridView1.Columns[COL_IGSTA].Visible = mbSameState;
            dataGridView1.Columns[COL_GRSA].Name = "Gross Amt";
            dataGridView1.Columns[COL_GRSA].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[COL_GRSA].Width = 80;
            dataGridView1.Columns[COL_DISC].Name = "Discount";
            dataGridView1.Columns[COL_DISC].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[COL_DISC].Width = 55;
            dataGridView1.Columns[COL_NAMT].Name = "Net Amt";
            dataGridView1.Columns[COL_NAMT].Width = 70;
            dataGridView1.Columns[COL_NAMT].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[COL_TTAX].Name = "Total Tax";
            dataGridView1.Columns[COL_TTAX].Width = 80;
            dataGridView1.Columns[COL_TTAX].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[COL_TAMT].Name = "Total Amt";
            dataGridView1.Columns[COL_TAMT].Width = 80;
            dataGridView1.Columns[COL_TAMT].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[COL_ITMC].Name = "Item Catg";
            dataGridView1.Columns[COL_ITMC].Visible = false;
            dataGridView1.Columns[COL_UPCC].Name = "UPCCode";
            dataGridView1.Columns[COL_UPCC].Visible = false;
            dataGridView1.Columns[COL_HSNC].Name = "HSNCode";
            dataGridView1.Columns[COL_HSNC].Visible = false;
            dataGridView1.Columns[COL_SACC].Name = "SACCode";
            dataGridView1.Columns[COL_SACC].Visible = false;
            dataGridView1.Columns[COL_STS].Name = "Sts";
            dataGridView1.Columns[COL_STS].Visible = false;
            dataGridView1.Columns[COL_IISNO].Name = "InvoiceItemSNo";
            dataGridView1.Columns[COL_IISNO].Visible = false;

        }
        private void FunLevel1_Init()
        {
            lblMobNo.Visible = false;
            txtMobNo.Visible = false;
            btnCustomerSearchOpen.Visible = false;
            btnAdvInvoiceSearch.Visible = false;
            lblInvoiceNo.Visible = false;
            txtInvoiceNo.Visible = false;
            lblInvoiceDate.Visible = false;
            txtInvoiceDate.Visible = false;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnDel.Visible = false;
            btnUpdateOpen.Visible = false;
        }
        private void FunLevel2_Init()
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnDel.Visible = false;
            btnSave.Visible = false;
        }
        private void FunLevel3_Init()
        {
            btnSave.Visible = false;
            btnUpdateOpen.Visible = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnItemSearch_Click(object sender, EventArgs e)
        {
            lObjItem.SearchItem(lsConnStr, txtDescription.Text);
            if (txtDescription.Text == lObjItem.ItemDesc)
            {
                bool lbSearchItem = lObjItem.SearchItem(lsConnStr, txtDescription.Text);
                if (!lbSearchItem)
                {
                    txtItemNo.Text = "";
                    txtDescription.Text = "";
                    txtType2.Text = "";
                    txtPrice.Text = "";
                    txtUOM.Text = "";
                    txtCGSTPercent.Text = "";
                    txtSGSTPercent.Text = "";
                    txtIGSTPercent.Text = "";
                }
                else
                {
                    txtItemNo.Text = lObjItem.ItemNo.ToString();
                    txtDescription.Text = lObjItem.ItemDesc;
                    txtPrice.Text = lObjItem.ItemPrice.ToString();
                    txtUOM.Text = lObjItem.ItemUOM;
                    txtType2.Text = lObjItem.ItemType;
                    txtCGSTPercent.Text = lObjItem.CGSTRate.ToString();
                    txtSGSTPercent.Text = lObjItem.SGSTRate.ToString();
                    txtIGSTPercent.Text = lObjItem.IGSTRate.ToString();
                }
            }
            else
            {
                SearchResultForm lObjSearch = new SearchResultForm(2, txtDescription.Text);
                lObjSearch.ShowDialog();
                txtItemNo.Text = lObjSearch.lsItemNo;
                txtDescription.Text = lObjSearch.lsItemDesc;
                txtPrice.Text = lObjSearch.lsItemPrice;
                txtUOM.Text = lObjSearch.lsItemUOM;
                txtType2.Text = lObjSearch.lsItemType;
                txtSGSTPercent.Text = lObjSearch.lsSGST;
                txtCGSTPercent.Text = lObjSearch.lsCGST;
                txtIGSTPercent.Text = lObjSearch.lsIGST;
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            float lnTotalTax = 0;
            float lnItemDiscount = 0;
            float lnTotalPrice = 0;
            float lnDiscountPrice = 0;
            if (txtDiscount.Text.Length > 0)
            {
                lnItemDiscount = float.Parse(txtDiscount.Text);
            }
            if (txtQty.Text.Length > 0)
            {
                lnTotalPrice = float.Parse(txtPrice.Text) * float.Parse(txtQty.Text);
                lnDiscountPrice = lnTotalPrice - lnItemDiscount;

                if (txtSGSTPercent.Text.Length > 0 && mbSameState)
                    txtSGSTAmt.Text = (lnDiscountPrice * float.Parse(txtSGSTPercent.Text) / 100.0).ToString("F");

                if (txtCGSTPercent.Text.Length > 0 && mbSameState)
                    txtCGSTAmt.Text = (lnDiscountPrice * float.Parse(txtCGSTPercent.Text) / 100.0).ToString("F");

                if (txtIGSTPercent.Text.Length > 0 && mbSameState)
                    txtIGSTAmt.Text = (lnDiscountPrice * float.Parse(txtIGSTPercent.Text) / 100.0).ToString("F");

                txtNetAmount.Text = lnDiscountPrice.ToString("F");
                txtGrossAmount.Text = lnTotalPrice.ToString("F");

                if (txtSGSTAmt.Text.Length > 0 && mbSameState)
                    lnTotalTax = float.Parse(txtSGSTAmt.Text);

                if (txtCGSTAmt.Text.Length > 0 && mbSameState)
                    lnTotalTax += float.Parse(txtCGSTAmt.Text);

                if (txtIGSTAmt.Text.Length > 0 && mbSameState)
                    lnTotalTax += float.Parse(txtIGSTAmt.Text);

                txtTax.Text = lnTotalTax.ToString("F");

                txtTotalAmount.Text = (float.Parse(txtNetAmount.Text) + lnTotalTax).ToString("F");
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtItemNo.Text.Equals(""))
            {
                MessageBox.Show("Item not selected. Please search and select the item using item description and continue.");
                return;
            }

            else if (txtQty.Text.Equals(""))
            {
                MessageBox.Show("Enter Quantity before adding the line");
                txtQty.Focus();
                return;
            }
            else if (LineItemAlreadyPresent())
            {
                MessageBox.Show("Item: " + txtDescription.Text + " already added. Please select the line and update the quantity.");
                return;
            }
            else
            {
                dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, txtItemNo.Text, txtDescription.Text, txtType2.Text,
                                                    txtPrice.Text, txtUOM.Text, int.Parse(txtQty.Text).ToString("F"), txtSGSTPercent.Text, txtSGSTAmt.Text, txtCGSTPercent.Text, txtCGSTAmt.Text,
                                                    txtIGSTPercent.Text, txtIGSTAmt.Text, txtGrossAmount.Text, txtDiscount.Text, txtNetAmount.Text, txtTax.Text, txtTotalAmount.Text);
                UpdateHeader();
            }
        }
        private bool LineItemAlreadyPresent()
        {
            for (int lnCount = 0; lnCount < dataGridView1.Rows.Count; lnCount++)
            {
                if (dataGridView1.Rows[lnCount].Cells[COL_ITMNO].Value.ToString() == txtItemNo.Text)
                    return true;
            }
            return false;
        }
        private void UpdateHeader()
        {
            for (int lnCount = 0; lnCount < dataGridView1.Rows.Count; lnCount++)
            {
                txtPartsTotal.Text = txtPartSGST.Text = txtPartsCGST.Text = txtPartsIGST.Text = "0.00";
                txtLabourTotal.Text = txtLabourSGST.Text = txtLabourCGST.Text = txtLabourIGST.Text = "0.00";
                txtTotalDiscount.Text = txtGrandTotal.Text = "0.00";
                // ignore for deleted items
                //if (dataGridViewLineItem.Rows[lnCount].Cells[COL_MODE].Value == Delete)
                //    continue;

                if (dataGridView1.Rows[lnCount].Cells[COL_ITMTYP].Value.ToString() == "Parts")
                {
                    if (txtPartsTotal.Text != "" && dataGridView1.Rows[lnCount].Cells[COL_NAMT].Value.ToString() != "")
                        txtPartsTotal.Text = (float.Parse(txtPartsTotal.Text) + float.Parse(dataGridView1.Rows[lnCount].Cells[COL_NAMT].Value.ToString())).ToString("F");

                    if (txtPartSGST.Text != "" && dataGridView1.Rows[lnCount].Cells[COL_SGSTA].Value.ToString() != "" && mbSameState)
                        txtPartSGST.Text = (float.Parse(txtPartSGST.Text) + float.Parse(dataGridView1.Rows[lnCount].Cells[COL_SGSTA].Value.ToString())).ToString("F");

                    if (txtPartsCGST.Text != "" && dataGridView1.Rows[lnCount].Cells[COL_CGSTA].Value.ToString() != "" && mbSameState)
                        txtPartsCGST.Text = (float.Parse(txtPartsCGST.Text) + float.Parse(dataGridView1.Rows[lnCount].Cells[COL_CGSTA].Value.ToString())).ToString("F");

                    if (txtPartsIGST.Text != "" && dataGridView1.Rows[lnCount].Cells[COL_IGSTA].Value.ToString() != "" && mbSameState)
                        txtPartsIGST.Text = (float.Parse(txtPartsIGST.Text) + float.Parse(dataGridView1.Rows[lnCount].Cells[COL_IGSTA].Value.ToString())).ToString("F");

                }
                else if (dataGridView1.Rows[lnCount].Cells[COL_ITMTYP].Value.ToString() == "Labour")
                {
                    if (txtLabourTotal.Text != "" && dataGridView1.Rows[lnCount].Cells[COL_NAMT].Value.ToString() != "")
                        txtLabourTotal.Text = (float.Parse(txtLabourTotal.Text) + float.Parse(dataGridView1.Rows[lnCount].Cells[COL_NAMT].Value.ToString())).ToString("F");

                    if (txtLabourSGST.Text != "" && dataGridView1.Rows[lnCount].Cells[COL_SGSTA].Value.ToString() != "" && mbSameState)
                        txtLabourSGST.Text = (float.Parse(txtLabourSGST.Text) + float.Parse(dataGridView1.Rows[lnCount].Cells[COL_SGSTA].Value.ToString())).ToString("F");

                    if (txtLabourCGST.Text != "" && dataGridView1.Rows[lnCount].Cells[COL_CGSTA].Value.ToString() != "" && mbSameState)
                        txtLabourCGST.Text = (float.Parse(txtLabourCGST.Text) + float.Parse(dataGridView1.Rows[lnCount].Cells[COL_CGSTA].Value.ToString())).ToString("F");

                    if (txtLabourIGST.Text != "" && dataGridView1.Rows[lnCount].Cells[COL_IGSTA].Value.ToString() != "" && mbSameState)
                        txtLabourIGST.Text = (float.Parse(txtLabourIGST.Text) + float.Parse(dataGridView1.Rows[lnCount].Cells[COL_IGSTA].Value.ToString())).ToString("F");
                }
                // Suumation of Item Discount
                if (txtTotalDiscount.Text != "" && dataGridView1.Rows[lnCount].Cells[COL_DISC].Value.ToString() != "")
                    txtTotalDiscount.Text = (float.Parse(txtTotalDiscount.Text) + float.Parse(dataGridView1.Rows[lnCount].Cells[COL_DISC].Value.ToString())).ToString("F");
            }
            txtTotalNetAmount.Text = (float.Parse(txtPartsTotal.Text) + float.Parse(txtLabourTotal.Text)).ToString("F");
            txtTotalSGST.Text = (float.Parse(txtPartSGST.Text) + float.Parse(txtLabourSGST.Text)).ToString("F");
            txtTotalCGST.Text = (float.Parse(txtPartsCGST.Text) + float.Parse(txtLabourCGST.Text)).ToString("F");
            txtTotalIGST.Text = (float.Parse(txtPartsIGST.Text) + float.Parse(txtLabourIGST.Text)).ToString("F");
            txtTotalTax.Text = (float.Parse(txtTotalSGST.Text) + float.Parse(txtTotalCGST.Text) + float.Parse(txtTotalIGST.Text)).ToString("F");
            txtGrandTotal.Text = (float.Parse(txtTotalNetAmount.Text) + float.Parse(txtTotalTax.Text)).ToString("F");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateCustomerData())
            {
                return;
            }
            InvoiceClass lObjInvoice = new InvoiceClass();
            // if (txtInvoiceNo.Text.Length == 0)
            // lObjInvoice.InvoiceSNo = int.Parse(null);
            // else
            // lObjInvoice.InvoiceSNo = int.Parse(txtInvoiceNo.Text);
            if (txtCustNo.Text.Length == 0)
                lObjInvoice.InvoiceCustomer.CustNo = int.Parse(null);
            else
                lObjInvoice.InvoiceCustomer.CustNo = int.Parse(txtCustNo.Text);
            lObjInvoice.InvoiceCustomer.CustFName = txtFirstName.Text;
            lObjInvoice.InvoiceCustomer.CustLName = txtLastName.Text;
            lObjInvoice.InvoiceCustomer.CustMobNo = txtMobNo3.Text;
            lObjInvoice.InvoiceCustomer.CustEmail = txtEid.Text;
            lObjInvoice.InvoiceCustomer.CustSts = cmbStatus.Text;
            lObjInvoice.InvoiceCustomer.CustType = cmbType.Text;
            lObjInvoice.InvoiceCustomer.CustStAddr = txtStreetAdd.Text;
            lObjInvoice.InvoiceCustomer.CustArAddr = txtAreaAdd.Text;
            lObjInvoice.InvoiceCustomer.CustCity = txtCity.Text;
            lObjInvoice.InvoiceCustomer.CustState = txtState.Text;
            lObjInvoice.InvoiceCustomer.CustPinCode = txtPCode.Text;
            lObjInvoice.InvoiceCustomer.CustCountry = txtCountry.Text;
            lObjInvoice.InvoiceCustomer.CustGSTNo = txtGSTNo.Text;
            lObjInvoice.InvoiceCustomer.CustRemarks = txtRemarks.Text;
            lObjInvoice.InvoiceCustomer.CustLastVisit = DateTime.Now;

            lObjInvoice.VehicleRegNo = txtRegNo.Text;
            lObjInvoice.VehicleModel = txtModel.Text;
            lObjInvoice.ChassisNo = txtChasisNo.Text;
            lObjInvoice.EngineNo = txtEngineNo.Text;

            if (txtMileage.Text.Length > 0)
                lObjInvoice.Mileage = int.Parse(txtMileage.Text);
            else
                lObjInvoice.Mileage = int.Parse(null);

            lObjInvoice.ServiceType = cmbServiceType.Text;
            lObjInvoice.ServiceAssoName = txtServiceAsso.Text;
            lObjInvoice.ServiceAssoMobNo = txtServiceAssoMobNo.Text;

            lObjInvoice.PartsTotal = float.Parse(txtPartsTotal.Text);
            lObjInvoice.PartsSGSTTotal = float.Parse(txtSGSTPercent.Text);
            lObjInvoice.PartsCGSTTotal = float.Parse(txtCGSTPercent.Text);
            lObjInvoice.PartsIGSTTotal = float.Parse(txtIGSTPercent.Text);

            lObjInvoice.LabourTotal = float.Parse(txtLabourTotal.Text);
            lObjInvoice.LabourSGSTTotal = float.Parse(txtLabourSGST.Text);
            lObjInvoice.LabourCGSTTotal = float.Parse(txtLabourCGST.Text);
            lObjInvoice.LabourIGSTTotal = float.Parse(txtLabourIGST.Text);

            lObjInvoice.TotalAmount = float.Parse(txtTotalNetAmount.Text);
            lObjInvoice.TotalSGST = float.Parse(txtTotalSGST.Text);
            lObjInvoice.TotalCGST = float.Parse(txtTotalCGST.Text);
            lObjInvoice.TotalIGST = float.Parse(txtTotalIGST.Text);
            lObjInvoice.TotalTax = float.Parse(txtTotalTax.Text);

            lObjInvoice.DiscountAmount = float.Parse(txtTotalDiscount.Text);
            lObjInvoice.InvoiceTotal = float.Parse(txtGrandTotal.Text);
            lObjInvoice.InvoiceRemarks = txtInvoiceRemarks.Text;

            lObjInvoice.Save(lsConnStr);
            lObjInvoiceItem.SearchItem(lsConnStr);
            int InvoiceSno = lObjInvoiceItem.InvoiceSNo;
            lObjItem.SearchItem(lsConnStr, txtItemNo.Text);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string lsQryText = "INSERT INTO [InvoiceItem2122]";
                lsQryText += "(InvoiceSNo,ItemNo,ItemDesc,ItemType,ItemCatg,ItemPrice,ItemUOM,ItemSts,SGSTRate,CGSTRate,IGSTRate,"; // 10
                lsQryText += "UPCCode,HSNCode,SACCode,Qty,SGSTAmount,CGSTAmount,IGSTAmount,DiscountAmount,TotalAmount, Created, CreatedBy, Deleted) VALUES( ";//11
                lsQryText += "@InvoiceSNo,@ItemNo, @ItemDesc, @ItemType, @ItemCatg, @ItemPrice, @ItemUOM, @ItemSts, @SGSTRate, @CGSTRate, @IGSTRate,";//10
                lsQryText += "@UPCCode, @HSNCode, @SACCode, @Qty, @SGSTAmount, @CGSTAmount,@IGSTAmount,@DiscountAmount, @TotalAmount,";//8
                lsQryText += "@Created, @CreatedBy, @Deleted)";//3
                lObjCmd = new SqlCommand();
                lObjCmd.CommandType = CommandType.Text;
                //lObjCmd.Parameters.AddWithValue("@InvoiceItemSNo", SqlDbType.Int).Value = row.Cells[0].Value;
                lObjCmd.Parameters.AddWithValue("@InvoiceSNo", SqlDbType.Int).Value = InvoiceSno;
                lObjCmd.Parameters.AddWithValue("@ItemNo", SqlDbType.Int).Value = row.Cells[1].Value;
                lObjCmd.Parameters.AddWithValue("@ItemDesc", SqlDbType.VarChar).Value = row.Cells[2].Value;
                lObjCmd.Parameters.AddWithValue("@ItemType", SqlDbType.VarChar).Value = row.Cells[3].Value;
                lObjCmd.Parameters.AddWithValue("@ItemCatg", SqlDbType.VarChar).Value = lObjItem.ItemCatg;
                lObjCmd.Parameters.AddWithValue("@ItemPrice", SqlDbType.Float).Value = row.Cells[4].Value;
                lObjCmd.Parameters.AddWithValue("@ItemUOM", SqlDbType.VarChar).Value = row.Cells[5].Value;
                lObjCmd.Parameters.AddWithValue("@ItemSts", SqlDbType.VarChar).Value = lObjItem.ItemSts;
                lObjCmd.Parameters.AddWithValue("@SGSTRate", SqlDbType.Float).Value = row.Cells[7].Value ?? DBNull.Value; ;
                lObjCmd.Parameters.AddWithValue("@CGSTRate", SqlDbType.Float).Value = row.Cells[9].Value ?? DBNull.Value; ;
                lObjCmd.Parameters.AddWithValue("@IGSTRate", SqlDbType.Float).Value = lObjItem.IGSTRate;
                lObjCmd.Parameters.AddWithValue("@UPCCode", SqlDbType.VarChar).Value = lObjItem.UPCCode;
                lObjCmd.Parameters.AddWithValue("@HSNCode", SqlDbType.VarChar).Value = lObjItem.HSNCode;
                lObjCmd.Parameters.AddWithValue("@SACCode", SqlDbType.VarChar).Value = lObjItem.SACCode;
                lObjCmd.Parameters.AddWithValue("@Qty", SqlDbType.Float).Value = row.Cells[6].Value;
                lObjCmd.Parameters.AddWithValue("@SGSTAmount", SqlDbType.Float).Value = row.Cells[8].Value ?? DBNull.Value;
                lObjCmd.Parameters.AddWithValue("@CGSTAmount", SqlDbType.Float).Value = row.Cells[10].Value ?? DBNull.Value;
                lObjCmd.Parameters.AddWithValue("@IGSTAmount", SqlDbType.Float).Value = row.Cells[12].Value ?? DBNull.Value;
                lObjCmd.Parameters.AddWithValue("@DiscountAmount", SqlDbType.Float).Value = txtTotalDiscount.Text;
                lObjCmd.Parameters.AddWithValue("@TotalAmount", SqlDbType.Float).Value = row.Cells[15].Value;
                lObjCmd.Parameters.AddWithValue("@Created", SqlDbType.DateTime).Value = DateTime.Now;
                lObjCmd.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = Login.SetValueForText1;
                lObjCmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = "N";
                lObjCmd.CommandText = lsQryText;
                lObjCmd.Connection = lObjConn;
                lObjCmd.ExecuteNonQuery();
            }
            MessageBox.Show("Invoice Saved");
            lObjInvoiceItem.UpdateItem(lsConnStr);

            txtMobNo.Text = "";
            txtInvoiceNo.Text = "";
            txtInvoiceDate.Text = "";
            txtCustNo.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMobNo3.Text = "";
            txtEid.Text = "";
            txtLastVisited.Text = "";
            txtStreetAdd.Text = "";
            txtAreaAdd.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtPCode.Text = "";
            txtCountry.Text = "";
            cmbType.Text = "";
            cmbStatus.Text = "";
            txtGSTNo.Text = "";
            txtRemarks.Text = "";

            txtItemNo.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtUOM.Text = "";
            txtQty.Text = "";
            txtGrossAmount.Text = "";
            txtType2.Text = "";
            txtDiscount.Text = "";
            txtSGSTPercent.Text = "";
            txtSGSTAmt.Text = "";
            txtCGSTPercent.Text = "";
            txtCGSTAmt.Text = "";
            txtIGSTPercent.Text = "";
            txtIGSTAmt.Text = "";
            txtNetAmount.Text = "";
            txtTax.Text = "";
            txtTotalAmount.Text = "";
            dataGridView1.Rows.Clear();


        }
        private bool ValidateCustomerData()
        {
            bool lbValid = true;

            if (txtFirstName.Text.Length == 0)
            {
                errorProvider1.SetError(txtFirstName, "Field Cannot Be Empty");
                lbValid = false;
            }
            if (txtLastName.Text.Length == 0)
            {
                errorProvider1.SetError(txtLastName, "Field Cannot Be Empty");
                lbValid = false;
            }

            if (txtMobNo3.Text.Length == 0)
            {
                errorProvider1.SetError(txtMobNo3, "Field Cannot Be Empty");
                lbValid = false;
            }

            if (txtEid.Text.Length == 0)
            {
                errorProvider1.SetError(txtEid, "Field Cannot Be Empty");
                lbValid = false;
            }

            if (cmbStatus.Text.Length == 0)
            {
                errorProvider1.SetError(cmbStatus, "Field Cannot Be Empty");
                lbValid = false;
            }

            if (cmbType.Text.Length == 0)
            {
                errorProvider1.SetError(cmbType, "Field Cannot Be Empty");
                lbValid = false;
            }
            return lbValid;
        }

        private void btnCustomerSearchNew_Click(object sender, EventArgs e)
        {
            if (txtMobNo2.Text.Length == 10)
            {
                bool lbSearchCustomer = lObjCustom.searchCustomer(lsConnStr, txtMobNo2.Text);

                if (!lbSearchCustomer)
                {
                    txtCustNo.Text = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtMobNo3.Text = "";
                    txtEid.Text = "";
                    txtLastVisited.Text = "";
                    txtStreetAdd.Text = "";
                    txtAreaAdd.Text = "";
                    txtCity.Text = "";
                    txtState.Text = "";
                    txtPCode.Text = "";
                    txtCountry.Text = "";
                    cmbType.Text = "";
                    cmbStatus.Text = "";
                    txtGSTNo.Text = "";
                    txtRemarks.Text = "";
                }
                else
                {
                    txtCustNo.Text = lObjCustom.CustNo.ToString();
                    txtFirstName.Text = lObjCustom.CustFName;
                    txtLastName.Text = lObjCustom.CustLName;
                    txtMobNo3.Text = lObjCustom.CustMobNo2;
                    txtEid.Text = lObjCustom.CustEmail;
                    txtLastVisited.Text = Convert.ToString(lObjCustom.CustLastVisit);
                    txtStreetAdd.Text = lObjCustom.CustStAddr;
                    txtAreaAdd.Text = lObjCustom.CustArAddr;
                    txtCity.Text = lObjCustom.CustCity;
                    txtState.Text = lObjCustom.CustState;
                    txtPCode.Text = lObjCustom.CustPinCode;
                    txtCountry.Text = lObjCustom.CustCountry;
                    cmbType.Text = lObjCustom.CustType;
                    cmbStatus.Text = lObjCustom.CustState;
                    txtGSTNo.Text = lObjCustom.CustGSTNo;
                    txtRemarks.Text = lObjCustom.CustRemarks;
                }
            }
            else
            {
                SearchResultForm lObjSearch = new SearchResultForm(1, txtMobNo2.Text);
                lObjSearch.ShowDialog();
                txtCustNo.Text = lObjSearch.lsCustNo;
                txtFirstName.Text = lObjSearch.lsCustFName;
                txtLastName.Text = lObjSearch.lsCustLName;
                txtMobNo3.Text = lObjSearch.lsCustMobNo;
                txtEid.Text = lObjSearch.lsCustEmail;
                txtLastVisited.Text = lObjSearch.lsCustLastVisit;
                txtStreetAdd.Text = lObjSearch.lsCustStAddr;
                txtAreaAdd.Text = lObjSearch.lsCustArAddr;
                txtCity.Text = lObjSearch.lsCustCity;
                txtState.Text = lObjSearch.lsCustState;
                txtPCode.Text = lObjSearch.lsCustPinCode;
                txtCountry.Text = lObjSearch.lsCustCountry;
                cmbType.Text = lObjSearch.lsCustType;
                cmbStatus.Text = lObjSearch.lsCustSts;
                txtGSTNo.Text = lObjSearch.lsCustGSTNo;
                txtRemarks.Text = lObjSearch.lsCustRemarks;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtItemNo.Text = row.Cells[1].Value.ToString();
                txtDescription.Text = row.Cells[2].Value.ToString();
                txtPrice.Text = row.Cells[4].Value.ToString();
                txtUOM.Text = row.Cells[5].Value.ToString();
                txtQty.Text = row.Cells[6].Value.ToString();
                txtGrossAmount.Text = row.Cells[13].Value.ToString();
                txtType2.Text = row.Cells[3].Value.ToString();
                txtDiscount.Text = row.Cells[14].Value.ToString();
                txtSGSTPercent.Text = row.Cells[7].Value.ToString();
                txtSGSTAmt.Text = row.Cells[8].Value.ToString();
                txtCGSTPercent.Text = row.Cells[9].Value.ToString();
                txtCGSTAmt.Text = row.Cells[10].Value.ToString();
                txtIGSTPercent.Text = row.Cells[11].Value.ToString();
                txtIGSTAmt.Text = row.Cells[12].Value.ToString();
                txtNetAmount.Text = row.Cells[15].Value.ToString();
                txtTax.Text = row.Cells[16].Value.ToString();
                txtTotalAmount.Text = row.Cells[17].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtItemNo.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtUOM.Text = "";
            txtQty.Text = "";
            txtGrossAmount.Text = "";
            txtType2.Text = "";
            txtDiscount.Text = "";
            txtSGSTPercent.Text = "";
            txtSGSTAmt.Text = "";
            txtCGSTPercent.Text = "";
            txtCGSTAmt.Text = "";
            txtIGSTPercent.Text = "";
            txtIGSTAmt.Text = "";
            txtNetAmount.Text = "";
            txtTax.Text = "";
            txtTotalAmount.Text = "";
        }

        private void btnCustomerSearchOpen_Click(object sender, EventArgs e)
        {
            if (txtMobNo.Text.Length == 10)
            {
                bool lbSearchInvoice = lObjInvoice.SearchInvoice(lsConnStr, txtMobNo.Text);
                if (lbSearchInvoice)
                {
                    txtInvoiceNo.Text = lObjInvoice.InvoiceNo;
                    txtInvoiceDate.Text = lObjInvoice.InvoiceDate.ToString();
                    txtCustNo.Text = lObjInvoice.InvoiceCustomer.CustNo.ToString();
                    txtFirstName.Text = lObjInvoice.InvoiceCustomer.CustFName;
                    txtLastName.Text = lObjInvoice.InvoiceCustomer.CustLName;
                    txtMobNo3.Text = lObjInvoice.InvoiceCustomer.CustMobNo;
                    txtEid.Text = lObjInvoice.InvoiceCustomer.CustEmail;
                    txtLastVisited.Text = lObjInvoice.InvoiceCustomer.CustLastVisit.ToString(); //changes for self
                    txtStreetAdd.Text = lObjInvoice.InvoiceCustomer.CustStAddr;
                    txtAreaAdd.Text = lObjInvoice.InvoiceCustomer.CustArAddr;
                    txtCity.Text = lObjInvoice.InvoiceCustomer.CustCity;
                    txtState.Text = lObjInvoice.InvoiceCustomer.CustState;
                    txtPCode.Text = lObjInvoice.InvoiceCustomer.CustPinCode;
                    txtCountry.Text = lObjInvoice.InvoiceCustomer.CustCountry;
                    cmbType.Text = lObjInvoice.InvoiceCustomer.CustType;
                    cmbStatus.Text = lObjInvoice.InvoiceCustomer.CustSts;
                    txtGSTNo.Text = lObjInvoice.InvoiceCustomer.CustGSTNo;
                    txtRemarks.Text = lObjInvoice.InvoiceCustomer.CustRemarks;
                    txtRegNo.Text = lObjInvoice.VehicleRegNo;
                    txtModel.Text = lObjInvoice.VehicleModel;
                    txtMileage.Text = lObjInvoice.Mileage.ToString();
                    txtChasisNo.Text = lObjInvoice.ChassisNo;
                    txtEngineNo.Text = lObjInvoice.EngineNo;
                    cmbServiceType.Text = lObjInvoice.ServiceType;
                    txtServiceAsso.Text = lObjInvoice.ServiceAssoName;
                    txtServiceAssoMobNo.Text = lObjInvoice.ServiceAssoMobNo;
                    txtPartsTotal.Text = lObjInvoice.PartsTotal.ToString();
                    txtPartsCGST.Text = lObjInvoice.PartsCGSTTotal.ToString();
                    txtPartSGST.Text = lObjInvoice.PartsSGSTTotal.ToString();
                    txtPartsIGST.Text = lObjInvoice.PartsIGSTTotal.ToString();
                    txtLabourTotal.Text = lObjInvoice.LabourTotal.ToString();
                    txtLabourCGST.Text = lObjInvoice.LabourCGSTTotal.ToString();
                    txtLabourSGST.Text = lObjInvoice.LabourSGSTTotal.ToString();
                    txtLabourIGST.Text = lObjInvoice.LabourIGSTTotal.ToString();
                    txtTotalNetAmount.Text = lObjInvoice.TotalAmount.ToString();
                    txtTotalCGST.Text = lObjInvoice.TotalCGST.ToString();
                    txtTotalSGST.Text = lObjInvoice.TotalSGST.ToString();
                    txtTotalIGST.Text = lObjInvoice.TotalIGST.ToString();
                    txtTotalDiscount.Text = lObjInvoice.DiscountAmount.ToString();
                    txtTotalTax.Text = lObjInvoice.TotalTax.ToString();
                    txtGrandTotal.Text = lObjInvoice.GrandTotal.ToString();
                    lObjInvoice.SearchInvoiceItem(lsConnStr, lObjInvoice.InvoiceSNo);
                    foreach (InvoiceItem lObjInvItem in lObjInvoice.InvoiceItems)
                    {
                        dataGridView1.Rows.Add(lObjInvItem.InvoiceItemSNo, lObjInvItem.ItemNo, lObjInvItem.ItemDesc, lObjInvItem.ItemType, lObjInvItem.ItemPrice, lObjInvItem.ItemUOM, lObjInvItem.Qty, lObjInvItem.SGSTRate, lObjInvItem.SGSTAmount, lObjInvItem.CGSTRate, lObjInvItem.CGSTAmount, lObjInvItem.IGSTRate, lObjInvItem.IGSTAmount, "200", lObjInvItem.DiscountAmount, "200", "100", lObjInvItem.TotalAmount);
                    }
                    //lsQuery = "select * from [InvoiceItem2021-22] where InvoiceSNo=@InvoiceSNo and Deleted=@Deleted";
                    //lObjCmd = new SqlCommand();
                    //lObjCmd.CommandType = CommandType.Text;
                    //lObjCmd.Parameters.AddWithValue("@InvoiceSNo", SqlDbType.VarChar).Value = lObjInvoice.InvoiceSNo;
                    //lObjCmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = 'N';
                    //lObjCmd.CommandText = lsQuery;
                    //lObjCmd.Connection = lObjConn;
                    //lObjAdpt = new SqlDataAdapter(lObjCmd);
                    //lObjDS = new DataSet();
                    //lObjAdpt.Fill(lObjDS);
                    //dataGridViewLineItem.DataSource = lObjDS.Tables[0];
                    //foreach (var item in lObjDS.Tables[0].Rows)
                    //{
                    //    dataGridViewLineItem.Rows.Add(lObjDS.Tables[0].Columns[0], lObjDS.Tables[0].Columns[2], lObjDS.Tables[0].Columns[3], lObjDS.Tables[0].Columns[4], lObjDS.Tables[0].Columns[6], lObjDS.Tables[0].Columns[7], "3", lObjDS.Tables[0].Columns[10], lObjDS.Tables[0].Columns[16], lObjDS.Tables[0].Columns[9], lObjDS.Tables[0].Columns[17], lObjDS.Tables[0].Columns[11], lObjDS.Tables[0].Columns[18], "200", lObjDS.Tables[0].Columns[19], "200", "200", lObjDS.Tables[0].Columns[20]);
                    //}               
                }
                else
                {
                    txtInvoiceNo.Text = "";
                    txtInvoiceDate.Text = "";
                    txtCustNo.Text = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtMobNo3.Text = "";
                    txtEid.Text = "";
                    txtLastVisited.Text = "";
                    txtStreetAdd.Text = "";
                    txtAreaAdd.Text = "";
                    txtCity.Text = "";
                    txtState.Text = "";
                    txtPCode.Text = "";
                    txtCountry.Text = "";
                    cmbType.Text = "";
                    cmbStatus.Text = "";
                    txtGSTNo.Text = "";
                    txtRemarks.Text = "";
                    txtRegNo.Text = "";
                    txtModel.Text = "";
                    txtMileage.Text = "";
                    txtChasisNo.Text = "";
                    txtEngineNo.Text = "";
                    cmbServiceType.Text = "";
                    txtServiceAsso.Text = "";
                    txtServiceAssoMobNo.Text = "";
                    txtPartsTotal.Text = "";
                    txtPartsCGST.Text = "";
                    txtPartSGST.Text = "";
                    txtPartsIGST.Text = "";
                    txtLabourTotal.Text = "";
                    txtLabourCGST.Text = "";
                    txtLabourSGST.Text = "";
                    txtLabourIGST.Text = "";
                    txtTotalNetAmount.Text = "";
                    txtTotalCGST.Text = "";
                    txtTotalSGST.Text = "";
                    txtTotalIGST.Text = "";
                    txtTotalDiscount.Text = "";
                    txtTotalTax.Text = "";
                    txtGrandTotal.Text = "";

                }
            }
            else
            {
                SearchResultForm lObjSearch = new SearchResultForm(3, txtMobNo.Text);
                lObjSearch.ShowDialog();
                txtInvoiceNo.Text = lObjSearch.lsInvoiceNo;
                txtInvoiceDate.Text = lObjSearch.lsInvoiceDate;
                txtCustNo.Text = lObjSearch.lsCustNo;
                txtFirstName.Text = lObjSearch.lsCustFName; 
                txtLastName.Text = lObjSearch.lsCustLName;
                txtMobNo3.Text = lObjSearch.lsCustMobNo;
                txtEid.Text = lObjSearch.lsCustEmail;
                txtLastVisited.Text = lObjSearch.lsCustLastVisit;
                txtStreetAdd.Text = lObjSearch.lsCustStAddr;
                txtAreaAdd.Text = lObjSearch.lsCustArAddr;
                txtCity.Text = lObjSearch.lsCustCity;
                txtState.Text = lObjSearch.lsCustState;
                txtPCode.Text = lObjSearch.lsCustPinCode;
                txtCountry.Text = lObjSearch.lsCustCountry;
                cmbType.Text = lObjSearch.lsCustType;
                cmbStatus.Text = lObjSearch.lsCustSts;
                txtGSTNo.Text = lObjSearch.lsCustGSTNo;
                txtRemarks.Text = lObjSearch.lsCustRemarks;
                txtRegNo.Text = lObjSearch.lsVehicleRegNo;
                txtModel.Text = lObjSearch.lsVehicleModel;
                txtChasisNo.Text = lObjSearch.lsChassisNo;
                txtEngineNo.Text = lObjSearch.lsEngineNo;
                txtMileage.Text = lObjSearch.lsMileage;
                cmbServiceType.Text = lObjSearch.lsServiceType;
                txtServiceAsso.Text = lObjSearch.lsServiceAssoName;
                txtServiceAssoMobNo.Text = lObjSearch.lsServiceAssoMobNo;
                txtPartsTotal.Text = lObjSearch.lsPartsTotal;
                txtPartsCGST.Text = lObjSearch.lsPartsCGSTTotal;
                txtPartSGST.Text = lObjSearch.lsPartsSGSTTotal;
                txtPartsIGST.Text = lObjSearch.lsPartsIGSTTotal;
                txtLabourTotal.Text = lObjSearch.lsLabourTotal;
                txtLabourCGST.Text = lObjSearch.lsLabourCGSTTotal;
                txtLabourSGST.Text = lObjSearch.lsLabourSGSTTotal;
                txtLabourIGST.Text = lObjSearch.lsLabourIGSTTotal;
                txtTotalNetAmount.Text = lObjSearch.lsTotalAmount;
                txtTotalCGST.Text = lObjSearch.lsTotalCGST;
                txtTotalSGST.Text = lObjSearch.lsTotalSGST;
                txtTotalIGST.Text = lObjSearch.lsTotalIGST;
                txtTotalDiscount.Text = lObjSearch.lsDiscountAmount;
                txtTotalTax.Text = lObjSearch.lsTotalTax;
                txtGrandTotal.Text = lObjSearch.lsGrandTotal;
                //lObjInvoice.SearchInvoice(lsConnStr,lObjSearch.lsInvoiceSNo);
                lObjInvoice.SearchInvoiceItem(lsConnStr, Convert.ToInt32(lObjSearch.lsInvoiceSNo));
                foreach (InvoiceItem lObjInvItem in lObjInvoice.InvoiceItems)
                {
                    dataGridView1.Rows.Add(lObjInvItem.InvoiceItemSNo, lObjInvItem.ItemNo, lObjInvItem.ItemDesc, lObjInvItem.ItemType, lObjInvItem.ItemPrice, lObjInvItem.ItemUOM, lObjInvItem.Qty, lObjInvItem.SGSTRate, lObjInvItem.SGSTAmount, lObjInvItem.CGSTRate, lObjInvItem.CGSTAmount, lObjInvItem.IGSTRate, lObjInvItem.IGSTAmount, txtTotalAmount.Text.ToString(), lObjInvItem.DiscountAmount, "200", txtTotalTax.Text.ToString(), lObjInvItem.TotalAmount);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[this.dataGridView1.SelectedRows[0].Index];
            newDataRow.Cells[6].Value = txtQty.Text;
            newDataRow.Cells[13].Value = txtGrossAmount.Text;
            newDataRow.Cells[14].Value = txtDiscount.Text;
            newDataRow.Cells[7].Value = txtSGSTPercent.Text;
            newDataRow.Cells[8].Value = txtSGSTAmt.Text;
            newDataRow.Cells[9].Value = txtCGSTPercent.Text;
            newDataRow.Cells[10].Value = txtCGSTAmt.Text;
            newDataRow.Cells[11].Value = txtIGSTPercent.Text;
            newDataRow.Cells[12].Value = txtIGSTAmt.Text;
            newDataRow.Cells[15].Value = txtNetAmount.Text;
            newDataRow.Cells[17].Value = txtTotalAmount.Text;
            newDataRow.Cells[16].Value = txtTax.Text;

            btnDelete.Visible = false;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
        }

        private void btnUpdateOpen_Click(object sender, EventArgs e)
        {
            if (!ValidateCustomerData())
            {
                return;
            }
            if (txtCustNo.Text.Length == 0)
                lObjInvoice.InvoiceCustomer.CustNo = int.Parse(null);
            else
                lObjInvoice.InvoiceNo = txtInvoiceNo.Text;
            lObjInvoice.InvoiceCustomer.CustNo = int.Parse(txtCustNo.Text);
            lObjInvoice.InvoiceCustomer.CustFName = txtFirstName.Text;
            lObjInvoice.InvoiceCustomer.CustLName = txtLastName.Text;
            lObjInvoice.InvoiceCustomer.CustMobNo = txtMobNo3.Text;
            lObjInvoice.InvoiceCustomer.CustEmail = txtEid.Text;
            lObjInvoice.InvoiceCustomer.CustSts = cmbStatus.Text;
            lObjInvoice.InvoiceCustomer.CustType = cmbStatus.Text;
            lObjInvoice.InvoiceCustomer.CustStAddr = txtStreetAdd.Text;
            lObjInvoice.InvoiceCustomer.CustArAddr = txtAreaAdd.Text;
            lObjInvoice.InvoiceCustomer.CustCity = txtCity.Text;
            lObjInvoice.InvoiceCustomer.CustState = txtState.Text;
            lObjInvoice.InvoiceCustomer.CustPinCode = txtPCode.Text;
            lObjInvoice.InvoiceCustomer.CustCountry = txtCountry.Text;
            lObjInvoice.InvoiceCustomer.CustGSTNo = txtGSTNo.Text;
            lObjInvoice.InvoiceCustomer.CustRemarks = txtRemarks.Text;
            lObjInvoice.InvoiceCustomer.CustLastVisit = Convert.ToDateTime(DateTime.Now.ToString());
            lObjInvoice.VehicleRegNo = txtRegNo.Text;
            lObjInvoice.VehicleModel = txtModel.Text;
            lObjInvoice.ChassisNo = txtChasisNo.Text;
            lObjInvoice.EngineNo = txtEngineNo.Text;

            if (txtMileage.Text.Length > 0)
                lObjInvoice.Mileage = int.Parse(txtMileage.Text);
            else
                lObjInvoice.Mileage = int.Parse(null);

            lObjInvoice.ServiceType = cmbServiceType.Text;
            lObjInvoice.ServiceAssoName = txtServiceAsso.Text;
            lObjInvoice.ServiceAssoMobNo = txtServiceAssoMobNo.Text;

            lObjInvoice.PartsTotal = float.Parse(txtPartsTotal.Text);
            lObjInvoice.PartsSGSTTotal = float.Parse(txtPartsCGST.Text);
            lObjInvoice.PartsCGSTTotal = float.Parse(txtPartSGST.Text);
            lObjInvoice.PartsIGSTTotal = float.Parse(txtPartsIGST.Text);

            lObjInvoice.LabourTotal = float.Parse(txtLabourTotal.Text);
            lObjInvoice.LabourSGSTTotal = float.Parse(txtLabourCGST.Text);
            lObjInvoice.LabourCGSTTotal = float.Parse(txtLabourSGST.Text);
            lObjInvoice.LabourIGSTTotal = float.Parse(txtLabourIGST.Text);

            lObjInvoice.TotalAmount = float.Parse(txtTotalNetAmount.Text);
            lObjInvoice.TotalSGST = float.Parse(txtTotalSGST.Text);
            lObjInvoice.TotalCGST = float.Parse(txtTotalCGST.Text);
            lObjInvoice.TotalIGST = float.Parse(txtTotalIGST.Text);

            lObjInvoice.TotalTax = float.Parse(txtTotalTax.Text);
            lObjInvoice.DiscountAmount = float.Parse(txtTotalDiscount.Text);
            lObjInvoice.InvoiceTotal = float.Parse(txtGrandTotal.Text);
            lObjInvoice.InvoiceRemarks = txtInvoiceRemarks.Text;
            InvoiceNo = txtInvoiceNo.Text;
            lObjInvoice.Update(lsConnStr);
            lObjInvoiceItem.searchInvoiceSno(lsConnStr);
            int InvSno = lObjInvoiceItem.InvoiceSNo;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string lsQryText = "UPDATE [InvoiceItem2122] SET ";

                lsQryText += "ItemNo=@ItemNo,ItemDesc=@ItemDesc,ItemType=@ItemType,ItemPrice=@ItemPrice,ItemUOM=@ItemUOM,";
                lsQryText += "SGSTRate=@SGSTRate,CGSTRate=@CGSTRate,IGSTRate=@IGSTRate,"; // 10
                lsQryText += "Qty=@Qty,SGSTAmount=@SGSTAmount,CGSTAmount=@CGSTAmount,";
                lsQryText += "IGSTAmount=@IGSTAmount,DiscountAmount=@DiscountAmount,TotalAmount=@TotalAmount, Modified=@Modified, ModifiedBy=@ModifiedBy ";
                lsQryText += "WHERE InvoiceSNo=@InvoiceSNo and InvoiceItemSNo=@InvoiceItemSNo";//3

                lObjCmd = new SqlCommand();
                lObjCmd.CommandType = CommandType.Text;

                lObjCmd.Parameters.AddWithValue("@ItemNo", SqlDbType.Int).Value = row.Cells[1].Value;
                lObjCmd.Parameters.AddWithValue("@ItemDesc", SqlDbType.VarChar).Value = row.Cells[2].Value;
                lObjCmd.Parameters.AddWithValue("@ItemType", SqlDbType.VarChar).Value = row.Cells[3].Value;
                lObjCmd.Parameters.AddWithValue("@ItemPrice", SqlDbType.Float).Value = row.Cells[4].Value;
                lObjCmd.Parameters.AddWithValue("@ItemUOM", SqlDbType.VarChar).Value = row.Cells[5].Value;
                lObjCmd.Parameters.AddWithValue("@SGSTRate", SqlDbType.Float).Value = (object)row.Cells[7].Value ?? DBNull.Value; ;
                lObjCmd.Parameters.AddWithValue("@CGSTRate", SqlDbType.Float).Value = (object)row.Cells[9].Value ?? DBNull.Value; ;
                lObjCmd.Parameters.AddWithValue("@IGSTRate", SqlDbType.Float).Value = (object)row.Cells[11].Value ?? DBNull.Value; ;
                lObjCmd.Parameters.AddWithValue("@Qty", SqlDbType.Float).Value = row.Cells[6].Value;
                lObjCmd.Parameters.AddWithValue("@SGSTAmount", SqlDbType.Float).Value = (object)row.Cells[8].Value ?? DBNull.Value;
                lObjCmd.Parameters.AddWithValue("@CGSTAmount", SqlDbType.Float).Value = (object)row.Cells[10].Value ?? DBNull.Value;
                lObjCmd.Parameters.AddWithValue("@IGSTAmount", SqlDbType.Float).Value = (object)row.Cells[12].Value ?? DBNull.Value;
                lObjCmd.Parameters.AddWithValue("@DiscountAmount", SqlDbType.Float).Value = (object)row.Cells[14].Value ?? DBNull.Value;
                lObjCmd.Parameters.AddWithValue("@TotalAmount", SqlDbType.Float).Value = row.Cells[17].Value;
                lObjCmd.Parameters.AddWithValue("@Modified", SqlDbType.DateTime).Value = DateTime.Now;
                lObjCmd.Parameters.AddWithValue("@ModifiedBy", SqlDbType.VarChar).Value = Login.SetValueForText1;
                lObjCmd.Parameters.AddWithValue("@InvoiceItemSNo", SqlDbType.Int).Value = row.Cells[0].Value;
                lObjCmd.Parameters.AddWithValue("@InvoiceSNo", SqlDbType.Int).Value = InvSno;

                lObjCmd.CommandText = lsQryText;
                lObjCmd.Connection = lObjConn;
                lObjCmd.ExecuteNonQuery();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            InvoiceNo = txtInvoiceNo.Text;
            bool lbDelete = lObjInvoice.InvoiceDelete(lsConnStr);
            if (lbDelete)
            {
                lObjInvoiceItem.searchDeleteInvoiceSno(lsConnStr);
                lObjInvoiceItem.DeleteItem(lsConnStr);
            }
        }

        
    }
}
