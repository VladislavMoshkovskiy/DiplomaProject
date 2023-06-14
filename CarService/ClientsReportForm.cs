using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public partial class ClientsReportForm : Form
    {
        public ClientsReportForm()
        {
            InitializeComponent();
        }

        private void ClientsReportForm_Load(object sender, EventArgs e)
        {
            CarServiceDataSet carServiceDataSet = new CarServiceDataSet();
            using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
            {
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT * FROM carservice.clients", connection))
                {
                    dataAdapter.Fill(carServiceDataSet, carServiceDataSet.Tables["clients"].TableName);
                }

                ReportDataSource report = new ReportDataSource("ClientsTable", carServiceDataSet.Tables["clients"]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(report);
                this.reportViewer1.LocalReport.Refresh();
            }

            this.reportViewer1.RefreshReport();
        }
    }
}
