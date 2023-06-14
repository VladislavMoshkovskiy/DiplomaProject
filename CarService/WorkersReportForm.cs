using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public partial class WorkersReportForm : Form
    {
        public WorkersReportForm()
        {
            InitializeComponent();
        }

        private void WorkersReportForm_Load(object sender, EventArgs e)
        {
            CarServiceDataSet carServiceDataSet = new CarServiceDataSet();
            using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
            {
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT * FROM carservice.workers", connection))
                {
                    dataAdapter.Fill(carServiceDataSet, carServiceDataSet.Tables["workers"].TableName);
                }

                ReportDataSource report = new ReportDataSource("Workers", carServiceDataSet.Tables["workers"]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(report);
                this.reportViewer1.LocalReport.Refresh();
            }

            this.reportViewer1.RefreshReport();
        }
    }
}
