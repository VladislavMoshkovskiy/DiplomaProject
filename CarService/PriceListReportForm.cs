using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;

namespace CarService
{
    public partial class PriceListReportForm : Form
    {
        public PriceListReportForm()
        {
            InitializeComponent();
        }

        private void PriceListReportForm_Load(object sender, EventArgs e)
        {
            CarServiceDataSet carServiceDataSet = new CarServiceDataSet();
            using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
            {
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT * FROM carservice.services", connection))
                {
                    dataAdapter.Fill(carServiceDataSet, carServiceDataSet.Tables["services"].TableName);
                }

                ReportDataSource report = new ReportDataSource("Services", carServiceDataSet.Tables["services"]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(report);
                this.reportViewer1.LocalReport.Refresh();
            }

            this.reportViewer1.RefreshReport();
        }
    }
}
