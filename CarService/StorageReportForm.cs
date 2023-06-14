using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;

namespace CarService
{
    public partial class StorageReportForm : Form
    {
        public StorageReportForm()
        {
            InitializeComponent();
        }

        private void StorageReportForm_Load(object sender, EventArgs e)
        {
            CarServiceDataSet carServiceDataSet = new CarServiceDataSet();

            using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
            {
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT * FROM carservice.materials", connection))
                {
                    dataAdapter.Fill(carServiceDataSet, carServiceDataSet.Tables["materials"].TableName);
                }

                ReportDataSource report = new ReportDataSource("Storage", carServiceDataSet.Tables["materials"]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(report);
                this.reportViewer1.LocalReport.Refresh();
            }

            this.reportViewer1.RefreshReport();
        }
    }
}
