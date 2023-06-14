using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public partial class ClientOrdersForm : Form
    {
        public ClientOrdersForm()
        {
            InitializeComponent();
        }

        private string _queryClientSurname = "SELECT clients.Surname FROM carservice.clients WHERE clients.Client_Id = @Id";
        private string _queryClientName = "SELECT clients.Name FROM carservice.clients WHERE clients.Client_Id = @Id";
        private string _queryClientPatronymic = "SELECT clients.Patronymic FROM carservice.clients WHERE clients.Client_Id = @Id";
        private string _queryClientPassport = "SELECT clients.Passport FROM carservice.clients WHERE clients.Client_Id = @Id";
        private string _queryClientPhone = "SELECT clients.Phone FROM carservice.clients WHERE clients.Client_Id = @Id";

        private string _selectedClientId;
        private string _selectedOrderId;

        private string _ordersInfoQuery = "SELECT orders.Order_Id AS @OrderId, orders.Car_Id AS @CarId, orders.Reception_Date AS @ReceptionDate, " +
                                          "orders.Completion_Date AS @CompletionDate, orders.Order_Cost AS @OrderCost " +
                                          "FROM carservice.orders WHERE orders.Client_Id = @SelectedClientId";
        private string _orderContentInfoQuery = "SELECT services.Service_Name AS @ServiceName, materials.Material_Name AS @MaterialName " +
                                                "FROM carservice.services, carservice.materials, carservice.order_content WHERE " +
                                                "services.Service_Id = order_content.Work_Type AND materials.Material_Id = order_content.Materials AND order_content.Order_Num = @SelectedOrderId";

        private void addClientButton_Click(object sender, EventArgs e)
        {
            ClientsTableForm clientsTableForm = new ClientsTableForm();
            clientsTableForm.ShowDialog();
            _selectedClientId = clientsTableForm.SelectedClientId;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(_queryClientSurname, connection);
                    command.Parameters.Add("@id", MySqlDbType.Int32);
                    command.Parameters["@id"].Value = _selectedClientId;
                    surnameTextBox.Text = (string)command.ExecuteScalar();
                    command = new MySqlCommand(_queryClientName, connection);
                    command.Parameters.Add("@id", MySqlDbType.Int32);
                    command.Parameters["@id"].Value = _selectedClientId;
                    nameTextBox.Text = (string)command.ExecuteScalar();
                    command = new MySqlCommand(_queryClientPatronymic, connection);
                    command.Parameters.Add("@id", MySqlDbType.Int32);
                    command.Parameters["@id"].Value = _selectedClientId;
                    patronymicTextBox.Text = (string)command.ExecuteScalar();
                    command = new MySqlCommand(_queryClientPassport, connection);
                    command.Parameters.Add("@id", MySqlDbType.Int32);
                    command.Parameters["@id"].Value = _selectedClientId;
                    passportTextBox.Text = (string)command.ExecuteScalar();
                    command = new MySqlCommand(_queryClientPhone, connection);
                    command.Parameters.Add("@id", MySqlDbType.Int32);
                    command.Parameters["@id"].Value = _selectedClientId;
                    phoneTextBox.Text = (string)command.ExecuteScalar();

                    MySqlCommand sqlCommand = new MySqlCommand(_ordersInfoQuery, connection);
                    sqlCommand.Parameters.Add("@OrderId", MySqlDbType.VarChar);
                    sqlCommand.Parameters.Add("@CarId", MySqlDbType.VarChar);
                    sqlCommand.Parameters.Add("@ReceptionDate", MySqlDbType.VarChar);
                    sqlCommand.Parameters.Add("@CompletionDate", MySqlDbType.VarChar);
                    sqlCommand.Parameters.Add("@OrderCost", MySqlDbType.VarChar);
                    sqlCommand.Parameters.Add("@SelectedClientId", MySqlDbType.Int32);
                    sqlCommand.Parameters["@OrderId"].Value = "Код";
                    sqlCommand.Parameters["@CarId"].Value = "Код авто";
                    sqlCommand.Parameters["@ReceptionDate"].Value = "Дата замовлення";
                    sqlCommand.Parameters["@CompletionDate"].Value = "Дата виконання";
                    sqlCommand.Parameters["@OrderCost"].Value = "Вартість";
                    sqlCommand.Parameters["@SelectedClientId"].Value = _selectedClientId;

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCommand))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        ordersDataGridView.DataSource = dataTable;
                    }

                    sqlCommand = new MySqlCommand(_orderContentInfoQuery, connection);
                    sqlCommand.Parameters.Add("@ServiceName", MySqlDbType.VarChar);
                    sqlCommand.Parameters.Add("@MaterialName", MySqlDbType.VarChar);
                    sqlCommand.Parameters.Add("@SelectedOrderId", MySqlDbType.Int32);
                    sqlCommand.Parameters["@ServiceName"].Value = "Назва послуги";
                    sqlCommand.Parameters["@MaterialName"].Value = "Запчастини";
                    sqlCommand.Parameters["@SelectedOrderId"].Value = _selectedOrderId;

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCommand))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        orderContentDataGridView.DataSource = dataTable;
                    }

                    connection.Close();
                }

                ordersDataGridView.Columns[0].Width = 100;
                ordersDataGridView.Columns[1].Width = 100;
                ordersDataGridView.Columns[2].Width = 250;
                ordersDataGridView.Columns[3].Width = 250;
                ordersDataGridView.Columns[4].Width = 130;

                ordersDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ordersDataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ordersDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ordersDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ordersDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                orderContentDataGridView.Columns[0].Width = 350;
                orderContentDataGridView.Columns[1].Width = 350;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClientOrdersForm_Load(object sender, EventArgs e)
        {
            ordersDataGridView.EnableHeadersVisualStyles = false;
            orderContentDataGridView.EnableHeadersVisualStyles = false;
        }

        private void ordersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ordersDataGridView.CurrentRow != null)
                _selectedOrderId = ordersDataGridView.CurrentRow.Cells[0].Value.ToString();

            using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
            {
                connection.Open();

                MySqlCommand sqlCommand = new MySqlCommand(_orderContentInfoQuery, connection);
                sqlCommand = new MySqlCommand(_orderContentInfoQuery, connection);
                sqlCommand.Parameters.Add("@ServiceName", MySqlDbType.VarChar);
                sqlCommand.Parameters.Add("@MaterialName", MySqlDbType.VarChar);
                sqlCommand.Parameters.Add("@SelectedOrderId", MySqlDbType.Int32);
                sqlCommand.Parameters["@ServiceName"].Value = "Назва послуги";
                sqlCommand.Parameters["@MaterialName"].Value = "Запчастини";
                sqlCommand.Parameters["@SelectedOrderId"].Value = _selectedOrderId;

                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCommand))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    orderContentDataGridView.DataSource = dataTable;
                }

                connection.Close();
            }
        }
    }
}
