using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace MasterMech
{
    public partial class Customer : Form
    {
        int gnLevelNo = 0;
        CustomerClss lObjCustom = new CustomerClss();
        SqlConnection lObjConn;
        SqlCommand lObjCmd;
        SqlDataAdapter lObjAdpt;
        DataSet lObjDS;
        SqlDataReader lObjRead;

        String lsConnStr = "";
        String lsQuery = "";
        public Customer(int inLevelNo)
        {
            InitializeComponent();
            gnLevelNo = inLevelNo;
        }
        private void txtFName_Leave(object sender, EventArgs e)
        {
            if (txtFName.Text.Equals(""))
            {
                errorProvider1.SetError(txtFName, "Field Cannot Be Empty ");
                txtFName.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void txtLName_Leave(object sender, EventArgs e)
        {
            if (txtLName.Text.Equals(""))
            {
                errorProvider1.SetError(txtLName, "Field Cannot Be Empty ");
                txtLName.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void txtMobNo2_Leave(object sender, EventArgs e)
        {
            Regex regex1 = new Regex(@"^[0-9]+$");
            Match match1 = regex1.Match(txtMobNo2.Text);

            if (txtMobNo2.Text.Equals(""))
            {
                errorProvider1.SetError(txtMobNo2, "Field Cannot Be Empty ");
                txtMobNo2.Focus();
            }
            else if (txtMobNo2.Text.Length != 10)
            {
                errorProvider1.SetError(txtMobNo2, "Mobile Number Must be 10 Digit ");
                txtMobNo2.Focus();
            }
            else if (match1.Success)
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(txtMobNo2, "Mobile Number Not In Correct Format");
                txtMobNo2.Focus();
            }
        }
        private void txtEid_Leave(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(txtEid.Text);

            if (txtEid.Text.Equals(""))
            {
                errorProvider1.SetError(txtEid, "Field Cannot Be Empty");
                txtEid.Focus();

            }
            else if (match.Success)
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(txtEid, "Email Id Not In Correct Format");
                txtEid.Focus();
            }
        }
        private void cmbStatus_Leave(object sender, EventArgs e)
        {
            if (cmbStatus.Text.Equals(""))
            {
                errorProvider1.SetError(cmbStatus, "Field Cannot Be Empty");
                cmbStatus.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void cmbType_Leave(object sender, EventArgs e)
        {
            if (cmbType.Text.Equals(""))
            {
                errorProvider1.SetError(cmbType, "Field Cannot Be Empty");
                cmbType.Focus();

            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void txtFName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtLName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtMobNo2_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtPCode_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtMobNo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(txtEid.Text);
            Regex regex1 = new Regex(@"^[0-9]+$");
            Match match1 = regex1.Match(txtMobNo2.Text);

            if (txtFName.Text.Equals(""))
            {
                errorProvider1.SetError(txtFName, "Field Cannot Be Empty ");
                txtFName.Focus();
            }
            else if (txtLName.Text.Equals(""))
            {
                errorProvider1.SetError(txtLName, "Field Cannot Be Empty ");
                txtLName.Focus();
            }
            else if (txtMobNo2.Text.Equals(""))
            {
                errorProvider1.SetError(txtMobNo2, "Field Cannot Be Empty");
                txtMobNo2.Focus();
            }
            else if (txtMobNo2.Text.Length != 10)
            {
                errorProvider1.SetError(txtMobNo2, "Mobile Number Must be 10 Digit ");
                txtMobNo2.Focus();
            }
            else if (!match1.Success)
            {
                errorProvider1.SetError(txtMobNo2, "Mobile Number Should be Digit Only");
                txtMobNo2.Focus();
            }
            else if (!match.Success)
            {
                errorProvider1.SetError(txtEid, "Email Id Not In Correct Form");
                txtEid.Focus();
            }
            else if (cmbStatus.Text.Equals(""))
            {
                errorProvider1.SetError(cmbStatus, "Please Select One Of above from Dropdown ");
                cmbStatus.Focus();
            }
            else if (cmbType.Text.Equals(""))
            {
                errorProvider1.SetError(cmbType, "Please Select One Of above from Dropdown");
                cmbType.Focus();
            }
            else
            {
                errorProvider1.Clear();
                lObjCustom.CustFName = txtFName.Text;
                lObjCustom.CustLName = txtLName.Text;
                lObjCustom.CustMobNo = txtMobNo2.Text;
                lObjCustom.CustEmail = txtEid.Text;
                lObjCustom.CustSts = cmbStatus.Text;
                lObjCustom.CustType = cmbType.Text;
                lObjCustom.CustStAddr = txtStAddr.Text;
                lObjCustom.CustArAddr = txtArAddr.Text;
                lObjCustom.CustCity = txtCity.Text;
                lObjCustom.CustState = txtState.Text;
                lObjCustom.CustPinCode = txtPCode.Text;
                lObjCustom.CustCountry = txtCountry.Text;
                lObjCustom.CustGSTNo = txtGSTNo.Text;
                lObjCustom.CustLastVisit = Convert.ToDateTime(dateTimePicker1.Text);
                lObjCustom.CustRemarks = txtRemarks.Text;
                lObjCustom.save(lsConnStr);
                MessageBox.Show("REGISTER SUCCESSFUL");

                txtFName.Text = "";
                txtLName.Text = "";
                txtMobNo2.Text = "";
                txtEid.Text = "";
                cmbStatus.Text = "";
                cmbType.Text = "";
                txtStAddr.Text = "";
                txtArAddr.Text = "";
                txtCity.Text = "";
                txtState.Text = "";
                txtPCode.Text = "";
                txtCountry.Text = "";
                txtGSTNo.Text = "";
                txtRemarks.Text = "";

            }
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            lsConnStr = "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=MechMaster; Data Source=LAPTOP-SQ607JC2\\SQLEXPRESS";
            if(gnLevelNo == 0)
            {
                FunLevel0_Init();
            }
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
        private void FunLevel0_Init()
        {
            txtCustNo.Text = DataGridViewForm.SelectedRow.Cells[0].Value.ToString();
            txtFName.Text = DataGridViewForm.SelectedRow.Cells[1].Value.ToString();
            txtLName.Text = DataGridViewForm.SelectedRow.Cells[2].Value.ToString();
            txtMobNo2.Text = DataGridViewForm.SelectedRow.Cells[3].Value.ToString();
            txtEid.Text = DataGridViewForm.SelectedRow.Cells[4].Value.ToString();
            cmbStatus.Text = DataGridViewForm.SelectedRow.Cells[5].Value.ToString();
            cmbType.Text = DataGridViewForm.SelectedRow.Cells[6].Value.ToString();
            txtStAddr.Text = DataGridViewForm.SelectedRow.Cells[7].Value.ToString();
            txtArAddr.Text = DataGridViewForm.SelectedRow.Cells[8].Value.ToString();
            txtCity.Text = DataGridViewForm.SelectedRow.Cells[9].Value.ToString();
            txtState.Text = DataGridViewForm.SelectedRow.Cells[10].Value.ToString();
            txtPCode.Text = DataGridViewForm.SelectedRow.Cells[11].Value.ToString();
            txtCountry.Text = DataGridViewForm.SelectedRow.Cells[12].Value.ToString();
            txtGSTNo.Text = DataGridViewForm.SelectedRow.Cells[13].Value.ToString();
            dateTimePicker1.Text = DataGridViewForm.SelectedRow.Cells[14].Value.ToString();
            txtRemarks.Text = DataGridViewForm.SelectedRow.Cells[15].Value.ToString();
            txtCreated.Text = DataGridViewForm.SelectedRow.Cells[16].Value.ToString();
            txtCreatedBy.Text = DataGridViewForm.SelectedRow.Cells[17].Value.ToString();
            txtModified.Text = DataGridViewForm.SelectedRow.Cells[18].Value.ToString();
            txtModifiedBy.Text = DataGridViewForm.SelectedRow.Cells[19].Value.ToString();
            btnUpdate.Visible = true;
            btnDelete.Visible = false;
            btnSave.Visible = false;
        }
        private void FunLevel1_Init()
        {
            groupBox3.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            groupBox4.Visible = false;
            lblLastVisited.Visible = false;
            dateTimePicker1.Visible = false;

            requiredFields.Location = new Point(this.Width - 580, 400);
            btnSave.Location = new Point(this.Width - 180, 400);
            btnCancel.Location = new Point(this.Width - 100, 400);
            this.ClientSize = new Size(850, 450);
        }
        private void FunLevel2_Init()
        {
            groupBox3.TabIndex = 0;
            btnSave.Visible = false;
            btnDelete.Visible = false;
        }
        private void FunLevel3_Init()
        {
            groupBox3.TabIndex = 0;
            btnSave.Visible = false;
            btnUpdate.Visible = false;
        }
        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            lObjCustom.CustNo = Convert.ToInt32(txtCustNo.Text);
            lObjCustom.CustFName = txtFName.Text;
            lObjCustom.CustLName = txtLName.Text;
            lObjCustom.CustMobNo = txtMobNo.Text;
            lObjCustom.CustEmail = txtEid.Text; // For Update
            lObjCustom.CustSts = cmbStatus.Text;
            lObjCustom.CustType = cmbType.Text;
            lObjCustom.CustStAddr = txtStAddr.Text;
            lObjCustom.CustArAddr = txtArAddr.Text;
            lObjCustom.CustCity = txtCity.Text;
            lObjCustom.CustState = txtState.Text;
            lObjCustom.CustPinCode = txtPCode.Text;
            lObjCustom.CustCountry = txtCountry.Text;
            lObjCustom.CustGSTNo = txtGSTNo.Text;
            lObjCustom.CustRemarks = txtRemarks.Text;
            lObjCustom.UpdateCustomer(lsConnStr);
            MessageBox.Show("Updated Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want delete?", "Permanent Deletion", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) // For delete
            {
                lObjCustom.CustNo = Convert.ToInt32(txtCustNo.Text);
                lObjCustom.DeleteCustomer(lsConnStr);
                MessageBox.Show("Deleted SuccessFully");
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool lbSearchCustom = lObjCustom.searchCustomer(lsConnStr, txtMobNo.Text);

            if (!lbSearchCustom)
            {
                txtCustNo.Text = "";
                txtFName.Text = "";
                txtLName.Text = "";
                txtMobNo2.Text = "";
                txtEid.Text = "";
                cmbStatus.Text = "";
                cmbType.Text = "";
                txtStAddr.Text = "";
                txtArAddr.Text = "";
                txtCity.Text = "";
                txtState.Text = "";
                txtPCode.Text = "";
                txtCountry.Text = "";
                txtGSTNo.Text = "";
                dateTimePicker1.Text = "";
                txtRemarks.Text = "";
                txtCreated.Text = "";
                txtCreatedBy.Text = "";
                txtModified.Text = "";
                txtModifiedBy.Text = "";
            }
            else
            {
                //lObjCustom.searchCustomer(lsConnStr, txtMobileNo.Text);
                txtCustNo.Text = lObjCustom.CustNo.ToString();
                txtFName.Text = lObjCustom.CustFName;
                txtLName.Text = lObjCustom.CustLName;
                txtMobNo2.Text = lObjCustom.CustMobNo2;
                txtEid.Text = lObjCustom.CustEmail;
                cmbStatus.Text = lObjCustom.CustSts;
                cmbType.Text = lObjCustom.CustType;
                txtStAddr.Text = lObjCustom.CustStAddr;
                txtArAddr.Text = lObjCustom.CustArAddr;
                txtCity.Text = lObjCustom.CustCity;
                txtState.Text = lObjCustom.CustState;
                txtPCode.Text = lObjCustom.CustPinCode;
                txtCountry.Text = lObjCustom.CustCountry;
                txtGSTNo.Text = lObjCustom.CustGSTNo;
                dateTimePicker1.Text = Convert.ToString(lObjCustom.CustLastVisit);
                txtRemarks.Text = lObjCustom.CustRemarks;
                txtCreated.Text = Convert.ToString(lObjCustom.Created);
                txtCreatedBy.Text = lObjCustom.CreatedBy;
                txtModified.Text = Convert.ToString(lObjCustom.Modified);
                txtModifiedBy.Text = lObjCustom.ModifiedBy;
            }
        }

        private void btnAdvSearch_Click(object sender, EventArgs e)
        {
            AdvanceSearch lObjAdv = new AdvanceSearch();
            lObjAdv.ShowDialog();
        }
    }
}
