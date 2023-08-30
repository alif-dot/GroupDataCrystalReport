using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupDataCrystalReport
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public Form1()
        {
            InitializeComponent();
        }

        public void BindReport()
        {
            SqlCommand com = new SqlCommand("sp_Students", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds, "StudentInfo");

            CrystalReport1 rpt = new CrystalReport1();
            rpt.SetDataSource(ds);

            frmReport frm = new frmReport();
            frm.crystalReportViewer1.ReportSource = rpt;
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindReport();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
