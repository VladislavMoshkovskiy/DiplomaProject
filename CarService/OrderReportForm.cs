using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public partial class OrderReportForm : Form
    {
        public OrderReportForm()
        {
            InitializeComponent();
        }

        private string _selectedOrderId;
        private string _selectedClientId;
        private string _selectedCarId;
        private DataTable _selectedServicesIdTable;
        private DataTable _selectedMaterialsIdTable;

        private void GetTableServicesId()
        {
            using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
            {
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter())
                {
                    MySqlCommand command = new MySqlCommand(GetServicesId, connection);
                    command.Parameters.Add("@OrderId", MySqlDbType.Int32);
                    command.Parameters["@OrderId"].Value = _selectedOrderId;
                    dataAdapter.SelectCommand = command;
                    _selectedServicesIdTable = new DataTable();
                    dataAdapter.Fill(_selectedServicesIdTable);
                }
            }
        }

        private void GetTableMaterialsId()
        {
            using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
            {
                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(GetMaterialsId, connection))
                {
                    MySqlCommand command = new MySqlCommand(GetMaterialsId, connection);
                    command.Parameters.Add("@OrderId", MySqlDbType.Int32);
                    command.Parameters["@OrderId"].Value = _selectedOrderId;
                    dataAdapter.SelectCommand = command;
                    _selectedMaterialsIdTable = new DataTable();
                    dataAdapter.Fill(_selectedMaterialsIdTable);
                }
            }
        }

        public string SelectedOrderId { get => _selectedOrderId; set => _selectedOrderId = value; }

        private const string GetClientId = "SELECT orders.Client_Id FROM carservice.orders WHERE orders.Order_Id = @OrderId";
        private const string GetCarId = "SELECT orders.Car_Id FROM carservice.orders WHERE orders.Order_Id = @OrderId";
        private const string GetServicesId = "SELECT order_content.Work_Type FROM carservice.order_content WHERE order_content.Order_Num = @OrderId";
        private const string GetMaterialsId = "SELECT order_content.Materials FROM carservice.order_content WHERE order_content.Order_Num = @OrderId";

        private const string GetOrderInfo = "SELECT orders.Order_Id, orders.Reception_Date, orders.Completion_Date, orders.Order_Cost, orders.Note " + 
                                                 "FROM carservice.orders WHERE orders.Order_Id = @OrderId";
        private const string GetClientsInfo = "SELECT clients.Surname, clients.Name, clients.Patronymic FROM carservice.clients " + 
                                              "WHERE clients.Client_Id = @ClientId";
        private const string GetCarsInfo = "SELECT cars.Brand, cars.Model, cars.Reg_Number FROM carservice.cars WHERE cars.Car_Id = @CarId";
        private const string GetOrderContent = "SELECT services.Service_Name, services.Service_Cost, materials.Material_Name, materials.Material_Cost " + 
                                               "FROM carservice.services, carservice.materials WHERE (services.Service_Id = @ServiceId) AND (materials.Material_Id = @MaterialId)";

        private void OrderReportForm_Load(object sender, EventArgs e)
        {
            CarServiceDataSet carServiceDataSet = new CarServiceDataSet();
            carServiceDataSet.EnforceConstraints = false;
            using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(GetOrderInfo, connection);
                command.Parameters.Add("@OrderId", MySqlDbType.Int32);
                command.Parameters["@OrderId"].Value = _selectedOrderId;

                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter())
                {
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(carServiceDataSet, carServiceDataSet.Tables["orders"].TableName);
                }

                command = new MySqlCommand(GetClientId, connection);
                command.Parameters.Add("@OrderId", MySqlDbType.Int32);
                command.Parameters["@OrderId"].Value = _selectedOrderId;
                _selectedClientId = command.ExecuteScalar().ToString();

                command = new MySqlCommand(GetClientsInfo, connection);
                command.Parameters.Add("@ClientId", MySqlDbType.Int32);
                command.Parameters["@ClientId"].Value = _selectedClientId;

                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter())
                {
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(carServiceDataSet, carServiceDataSet.Tables["clients"].TableName);
                }

                command = new MySqlCommand(GetCarId, connection);
                command.Parameters.Add("@OrderId", MySqlDbType.Int32);
                command.Parameters["@OrderId"].Value = _selectedOrderId;
                _selectedCarId = command.ExecuteScalar().ToString();

                command = new MySqlCommand(GetCarsInfo, connection);
                command.Parameters.Add("@CarId", MySqlDbType.Int32);
                command.Parameters["@CarId"].Value = _selectedCarId;

                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter())
                {
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(carServiceDataSet, carServiceDataSet.Tables["cars"].TableName);
                }

                GetTableServicesId();
                GetTableMaterialsId();

                OrderContentDataSet orderContentDataSet = new OrderContentDataSet();

                if ((_selectedServicesIdTable != null) && (_selectedMaterialsIdTable != null))
                {
                    for (int i = 0; i < _selectedServicesIdTable.Rows.Count; i++)
                    {
                        MySqlCommand command1 = new MySqlCommand(GetOrderContent, connection);
                        command1.Parameters.Add("@ServiceId", MySqlDbType.Int32);
                        command1.Parameters.Add("@MaterialId", MySqlDbType.Int32);
                        command1.Parameters["@ServiceId"].Value = _selectedServicesIdTable.Rows[i][0];
                        command1.Parameters["@MaterialId"].Value = _selectedMaterialsIdTable.Rows[i][0];
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                        dataAdapter.SelectCommand = command1;
                        dataAdapter.Fill(orderContentDataSet, orderContentDataSet.Tables["Order_Content"].TableName);
                    }
                }

                ReportDataSource report1 = new ReportDataSource("Orders", carServiceDataSet.Tables["orders"]);
                ReportDataSource report2 = new ReportDataSource("Clients", carServiceDataSet.Tables["clients"]);
                ReportDataSource report3 = new ReportDataSource("Cars", carServiceDataSet.Tables["cars"]);
                ReportDataSource report4 = new ReportDataSource("OrderContentQuery", orderContentDataSet.Tables["Order_Content"]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(report1);
                this.reportViewer1.LocalReport.DataSources.Add(report2);
                this.reportViewer1.LocalReport.DataSources.Add(report3);
                this.reportViewer1.LocalReport.DataSources.Add(report4);
                this.reportViewer1.LocalReport.Refresh();

                connection.Close();
            }

            this.reportViewer1.RefreshReport();
        }
    }
}
