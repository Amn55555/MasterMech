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
    public partial class DataGridViewForm : Form
    {
        string lsTextFName;
        string lsTextLName;
        string lsTextCity;
        SqlConnection lObjConn;
        SqlCommand lObjCmd;
        SqlDataAdapter lObjAdpt;
        DataSet lObjDS;

        String lsConnStr = "";
        String lsQuery = "";
        public DataGridViewForm(string isTextFName, string isTextLName, string isTextCity)
        {
            InitializeComponent();
            lsTextFName = isTextFName;
            lsTextLName = isTextLName;
            lsTextCity = isTextCity;
        }

       
        public static DataGridViewRow SelectedRow { get; set; }
        

        private void DataGridViewForm_Load(object sender, EventArgs e)
        {
            lsConnStr = "Integrated Security=SSPI; Persist Security Info=False; Initial Catalog=MechMaster; Data Source=LAPTOP-SQ607JC2\\SQLEXPRESS";
            lObjConn = new SqlConnection(lsConnStr);
            lObjConn.Open();

            lsQuery = "select * from Customer where (CustFName=@CustFName or CustLName=@CustLName or CustCity=@CustCity) and Deleted=@Deleted";
            lObjCmd = new SqlCommand();
            lObjCmd.CommandType = CommandType.Text;
            lObjCmd.Parameters.AddWithValue("@CustFName", SqlDbType.VarChar).Value = lsTextFName;
            lObjCmd.Parameters.AddWithValue("@CustLName", SqlDbType.VarChar).Value = lsTextLName;
            lObjCmd.Parameters.AddWithValue("@CustCity", SqlDbType.VarChar).Value = lsTextCity;
            lObjCmd.Parameters.AddWithValue("@Deleted", SqlDbType.VarChar).Value = 'N';
            lObjCmd.CommandText = lsQuery;
            lObjCmd.Connection = lObjConn;
            lObjAdpt = new SqlDataAdapter(lObjCmd);
            lObjDS = new DataSet();
            lObjAdpt.Fill(lObjDS);
            dataGridView1.DataSource = lObjDS.Tables[0];
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedRow = dataGridView1.Rows[e.RowIndex];
                Customer lObjCust = new Customer(0);
                lObjCust.ShowDialog();
            }
        }
    }
}
