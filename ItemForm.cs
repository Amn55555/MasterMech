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
    public partial class ItemForm : Form
    {
        ItemClass lObjCustom = new ItemClass();
        SqlConnection lObjConn;
        SqlCommand lObjCmd;
        SqlDataAdapter lObjAdpt;
        DataSet lObjDS;
        SqlDataReader lObjRead;

        String lsConnStr = "";
        String lsQuery = "";
        int gnLevelNo = 0;
        public ItemForm(int inLevelNo)
        {
            InitializeComponent();
            gnLevelNo = inLevelNo;
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            lsConnStr = "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=MechMaster; Data Source=LAPTOP-SQ607JC2\\SQLEXPRESS";
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
        }
        private void FunLevel1_Init()
        {
            lblItemDesc.Visible = false;
            txtItemDesc.Visible = false;
            btnSearch.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;


        }
        private void FunLevel2_Init()
        {
            btnSave.Visible = false;
            btnDelete.Visible = false;
            txtItemDesc.TabIndex = 0;
            txtItemDesc2.TabIndex = 1;

        }
        private void FunLevel3_Init()
        {
            btnSave.Visible = false;
            btnUpdate.Visible = false;
            txtItemDesc.TabIndex = 0;
            txtItemDesc2.TabIndex = 1;
        }

        private void txtItemDesc2_Leave(object sender, EventArgs e)
        {
            if(txtItemDesc2.Text.Equals(""))
            {
                errorProvider1.SetError(txtItemDesc2, "Field Cannot Be Empty ");
                txtItemDesc2.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void cmbItemType_Leave(object sender, EventArgs e)
        {
            if(cmbItemType.Text.Equals(""))
            {
                errorProvider1.SetError(cmbItemType, "Field Cannot Be Empty");
                cmbItemType.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void cmbItemCat_Leave(object sender, EventArgs e)
        {
            if(cmbItemCat.Text.Equals(""))
            {
                errorProvider1.SetError(cmbItemCat, "Field Cannot Be Empty");
                cmbItemCat.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtItemPrice_Leave(object sender, EventArgs e)
        {
            if(txtItemPrice.Text.Equals(""))
            {
                errorProvider1.SetError(txtItemPrice, "Field Cannot Be Empty");
                txtItemPrice.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtUOM_Leave(object sender, EventArgs e)
        {
            if(txtUOM.Text.Equals(""))
            {
                errorProvider1.SetError(txtUOM, "Field Cannot Be Empty");
                txtUOM.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void cmbStatus_Leave(object sender, EventArgs e)
        {
            if(cmbStatus.Text.Equals(""))
            {
                errorProvider1.SetError(cmbStatus, "Field Cannot Be Empty");
                cmbStatus.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtItemPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtCGST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSGST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtIGST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtNoParts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtReOrderLvl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtQtyInHand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtReOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtItemDesc2.Text.Equals(""))
            {
                errorProvider1.SetError(txtItemDesc2, "Field Cannot Be Empty ");
                txtItemDesc2.Focus();
            }
            if (cmbItemType.Text.Equals(""))
            {
                errorProvider1.SetError(cmbItemType, "Field Cannot Be Empty");
                cmbItemType.Focus();
            }
            if (cmbItemCat.Text.Equals(""))
            {
                errorProvider1.SetError(cmbItemCat, "Field Cannot Be Empty");
                cmbItemCat.Focus();
            }
            if (txtItemPrice.Text.Equals(""))
            {
                errorProvider1.SetError(txtItemPrice, "Field Cannot Be Empty");
                txtItemPrice.Focus();
            }
            if (txtUOM.Text.Equals(""))
            {
                errorProvider1.SetError(txtUOM, "Field Cannot Be Empty");
                txtUOM.Focus();
            }
            if (cmbStatus.Text.Equals(""))
            {
                errorProvider1.SetError(cmbStatus, "Field Cannot Be Empty");
                cmbStatus.Focus();
            }
            else
            {
                errorProvider1.Clear();
                lObjCustom.ItemDesc = txtItemDesc2.Text;
                lObjCustom.ItemType = cmbItemType.Text;
                lObjCustom.ItemCatg = cmbItemCat.Text;
                lObjCustom.ItemPrice =  Convert.ToDouble(txtItemPrice.Text);
                lObjCustom.ItemUOM = txtUOM.Text;
                lObjCustom.ItemSts = cmbStatus.Text;
                lObjCustom.CGSTRate = Convert.ToDouble(txtCGST.Text);
                lObjCustom.SGSTRate = Convert.ToDouble(txtSGST.Text);
                lObjCustom.IGSTRate = Convert.ToDouble(txtIGST.Text);
                lObjCustom.UPCCode = txtUPC.Text;
                lObjCustom.HSNCode = txtHSN.Text;
                lObjCustom.SACCode = txtSAC.Text;
                lObjCustom.QtyHand = Convert.ToDouble(txtQtyInHand.Text);
                lObjCustom.ReOrderLvl = Convert.ToDouble(txtReOrderLvl.Text);
                lObjCustom.ReOrderQty = Convert.ToDouble(txtReOrder.Text);
                lObjCustom.NoOfParts = Convert.ToInt32(txtNoParts.Text);
                lObjCustom.ItemRemarks = txtRemarks.Text;
                lObjCustom.save(lsConnStr);
                MessageBox.Show("REGISTER SUCCESSFUL");

                txtItemDesc2.Text = "";
                cmbItemType.Text = "";
                cmbItemCat.Text = "";
                txtItemPrice.Text = "";
                txtUOM.Text = "";
                cmbStatus.Text = "";
                txtCGST.Text = "";
                txtSGST.Text = "";
                txtIGST.Text = "";
                txtUPC.Text = "";
                txtHSN.Text = "";
                txtSAC.Text = "";
                txtQtyInHand.Text = "";
                txtReOrderLvl.Text = "";
                txtReOrder.Text = "";
                txtNoParts.Text = "";
                txtRemarks.Text = "";
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            lObjCustom.ItemNo = Convert.ToInt32(txtItemNo.Text);
            lObjCustom.ItemDesc2 = txtItemDesc2.Text;
            lObjCustom.ItemType = cmbItemType.Text;
            lObjCustom.ItemCatg = cmbItemCat.Text;
            lObjCustom.ItemPrice = Convert.ToDouble(txtItemPrice.Text); // For Update
            lObjCustom.ItemUOM = txtUOM.Text;
            lObjCustom.ItemSts = cmbStatus.Text;
            lObjCustom.CGSTRate = Convert.ToDouble(txtCGST.Text);
            lObjCustom.SGSTRate = Convert.ToDouble(txtSGST.Text);
            lObjCustom.IGSTRate = Convert.ToDouble(txtIGST.Text);
            lObjCustom.UPCCode = txtUPC.Text;
            lObjCustom.HSNCode = txtHSN.Text;
            lObjCustom.SACCode = txtSAC.Text;
            lObjCustom.QtyHand = Convert.ToDouble(txtQtyInHand.Text);
            lObjCustom.ReOrderLvl = Convert.ToDouble(txtReOrderLvl.Text);
            lObjCustom.ReOrderQty = Convert.ToDouble(txtReOrder.Text);
            lObjCustom.NoOfParts = Convert.ToInt32(txtNoParts.Text);
            lObjCustom.ItemRemarks = txtRemarks.Text;
            lObjCustom.Update(lsConnStr);
            MessageBox.Show("Updated Successfully");

            txtItemNo.Text = "";
            txtItemDesc2.Text = "";
            cmbItemType.Text = "";
            cmbItemCat.Text = "";
            txtItemPrice.Text = "";
            txtUOM.Text = "";
            cmbStatus.Text = "";
            txtQtyInHand.Text = "";
            txtReOrder.Text = "";
            txtCGST.Text = "";
            txtSGST.Text = "";
            txtIGST.Text = "";
            txtUPC.Text = "";
            txtHSN.Text = "";
            txtSAC.Text = "";
            txtNoParts.Text = "";
            txtRemarks.Text = "";
            txtCreated.Text = "";
            txtCreatedBy.Text = "";
            txtModified.Text = "";
            txtModifiedBy.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool lbSearch = lObjCustom.Search(lsConnStr, txtItemDesc.Text);

            if (!lbSearch)
            {
                txtItemNo.Text = "";
                txtItemDesc2.Text = "";
                cmbItemType.Text = "";
                cmbItemCat.Text = "";
                txtItemPrice.Text = "";
                txtUOM.Text = "";
                cmbStatus.Text = "";
                txtQtyInHand.Text = "";
                txtReOrder.Text = "";
                txtCGST.Text = "";
                txtSGST.Text = "";
                txtIGST.Text = "";
                txtUPC.Text = "";
                txtHSN.Text = "";
                txtSAC.Text = "";
                txtNoParts.Text = "";
                txtRemarks.Text = "";
                txtCreated.Text = "";
                txtCreatedBy.Text = "";
                txtModified.Text = "";
                txtModifiedBy.Text = "";
            }
            else
            {
                txtItemNo.Text = lObjCustom.ItemNo.ToString();
                txtItemDesc2.Text = lObjCustom.ItemDesc2;
                cmbItemType.Text = lObjCustom.ItemType;
                cmbItemCat.Text = lObjCustom.ItemCatg;
                txtItemPrice.Text = Convert.ToString(lObjCustom.ItemPrice);
                txtUOM.Text = lObjCustom.ItemUOM;
                cmbStatus.Text = lObjCustom.ItemSts;
                txtQtyInHand.Text = Convert.ToString(lObjCustom.QtyHand);
                txtReOrderLvl.Text = Convert.ToString(lObjCustom.ReOrderLvl);
                txtReOrder.Text = Convert.ToString(lObjCustom.ReOrderQty);
                txtCGST.Text = Convert.ToString(lObjCustom.CGSTRate);
                txtSGST.Text = Convert.ToString(lObjCustom.SGSTRate);
                txtIGST.Text = Convert.ToString(lObjCustom.IGSTRate);
                txtUPC.Text = lObjCustom.UPCCode;
                txtHSN.Text = lObjCustom.HSNCode;
                txtSAC.Text = lObjCustom.SACCode;
                txtNoParts.Text = Convert.ToString(lObjCustom.NoOfParts);
                txtRemarks.Text = lObjCustom.ItemRemarks;
                txtCreated.Text = Convert.ToString(lObjCustom.Created);
                txtCreatedBy.Text = lObjCustom.CreatedBy;
                txtModified.Text = Convert.ToString(lObjCustom.Modified);
                txtModifiedBy.Text = lObjCustom.ModifiedBy;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want delete?", "Permanent Deletion", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) // For delete
            {
                lObjCustom.ItemNo = Convert.ToInt32(txtItemNo.Text);
                lObjCustom.Delete(lsConnStr);
                MessageBox.Show("Deleted SuccessFully");
            }
            else if (dialogResult == DialogResult.No)
            {

            }
            txtItemNo.Text = "";
            txtItemDesc2.Text = "";
            cmbItemType.Text = "";
            cmbItemCat.Text = "";
            txtItemPrice.Text = "";
            txtUOM.Text = "";
            cmbStatus.Text = "";
            txtQtyInHand.Text = "";
            txtReOrder.Text = "";
            txtCGST.Text = "";
            txtSGST.Text = "";
            txtIGST.Text = "";
            txtUPC.Text = "";
            txtHSN.Text = "";
            txtSAC.Text = "";
            txtNoParts.Text = "";
            txtRemarks.Text = "";
            txtCreated.Text = "";
            txtCreatedBy.Text = "";
            txtModified.Text = "";
            txtModifiedBy.Text = "";
        }
    }
    
}
