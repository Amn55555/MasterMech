using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterMech
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }
        private void SplashForm_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;     
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();   
        }
        private void SplashForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            this.Hide();
            Login lObjLogin = new Login();
            lObjLogin.ShowDialog();
        }
    }
}
