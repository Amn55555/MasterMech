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
    public partial class AdvanceSearch : Form
    {

        public AdvanceSearch()
        {
            InitializeComponent();
        }

        private void AdvanceSearch_Load(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string lsTextFName = "";
            string lsTextLName = "";
            string lsTextCity = "";
            lsTextFName = txtFName.Text;
            lsTextLName = txtLName.Text;
            lsTextCity = textCity.Text;
            this.Hide();
            DataGridViewForm lObjSearch = new DataGridViewForm(lsTextFName, lsTextLName, lsTextCity);
            lObjSearch.ShowDialog();
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }

}
