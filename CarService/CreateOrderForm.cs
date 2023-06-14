using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public partial class CreateOrderForm : Form
    {
        public CreateOrderForm()
        {
            InitializeComponent();
        }

        private void CreateOrderForm_Load(object sender, EventArgs e)
        {
            carsDataGridView.EnableHeadersVisualStyles = false;

            orderDateLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            worksComboBox.SelectedIndex = -1;
            materialsComboBox.SelectedIndex = -1;

            DataTable dataTable = DBWork.GetDataTableFromSqlQuery("SELECT services.Service_Id, services.Service_Name FROM carservice.services");
            worksComboBox.DataSource = dataTable;
            worksComboBox.DisplayMember = "Service_Name";
            worksComboBox.ValueMember = "Service_Id";

            dataTable = DBWork.GetDataTableFromSqlQuery("SELECT materials.Material_Id, materials.Material_Name FROM carservice.materials");
            materialsComboBox.DataSource = dataTable;
            materialsComboBox.DisplayMember = "Material_Name";
            materialsComboBox.ValueMember = "Material_Id";

            uint orderNum;

            using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT orders.Order_Id FROM carservice.orders ORDER BY orders.Order_Id DESC LIMIT 1", connection);
                orderNum = (uint)command.ExecuteScalar();

                connection.Close();
            }

            orderNumTextBox.Text = (orderNum + 1).ToString();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearWorksList_Click(object sender, EventArgs e)
        {
            worksListBox.Items.Clear();
            worksComboBox.SelectedIndex = -1;
        }

        private void clearMaterialsList_Click(object sender, EventArgs e)
        {
            materialsListBox.Items.Clear();
            materialsComboBox.SelectedIndex = -1;
        }

        private void worksComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            worksListBox.Items.Add(worksComboBox.Text);

            if (worksListBox.Items.Count > 0)
            {
                _orderHours = GetOrderHours();
                _completionDate = Convert.ToDateTime(orderDateLabel.Text).AddHours(_orderHours);

                completionDateTimePicker.Value = _completionDate;
                orderCostTextBox.Text = GetOrderCost().ToString();
            }
        }

        private void materialsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            materialsListBox.Items.Add(materialsComboBox.Text);

            if (materialsListBox.Items.Count > 0)
                orderCostTextBox.Text = GetOrderCost().ToString();
        }

        private void clearClientsTextBox_Click(object sender, EventArgs e)
        {
            surnameTextBox.Text = string.Empty;
            nameTextBox.Text = string.Empty;
            patronymicTextBox.Text = string.Empty;
            passportTextBox.Text = string.Empty;
            phoneTextBox.Text = string.Empty;
        }

        private string _selectedClientId;

        private string _queryClientSurname = "SELECT clients.Surname FROM carservice.clients WHERE clients.Client_Id = @Id";
        private string _queryClientName = "SELECT clients.Name FROM carservice.clients WHERE clients.Client_Id = @Id";
        private string _queryClientPatronymic = "SELECT clients.Patronymic FROM carservice.clients WHERE clients.Client_Id = @Id";
        private string _queryClientPassport = "SELECT clients.Passport FROM carservice.clients WHERE clients.Client_Id = @Id";
        private string _queryClientPhone = "SELECT clients.Phone FROM carservice.clients WHERE clients.Client_Id = @Id";

        private string _getCarIdQuery = "SELECT orders.Car_Id FROM carservice.orders WHERE orders.Client_Id = @ClientId";

        private const string CarsQuery = "SELECT cars.Car_Id AS @Id, cars.Brand AS @Brand, cars.Model AS @Model, cars.Reg_Number AS @Number, " +
                                         "cars.Color AS @Color, cars.Engine_Capacity AS @Capacity, cars.Fuel_Type AS @Fuel " +
                                         "FROM carservice.cars WHERE cars.Car_Id = @CarId";

        private DataTable _carsListTable;

        private DataTable RemoveDuplicate(DataTable dataTable, int columnId)
        {
            try
            {
                ArrayList UniqueRows = new ArrayList();
                ArrayList DuplicateRows = new ArrayList();

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (UniqueRows.Contains(dataRow[columnId]))
                        DuplicateRows.Add(dataRow);
                    else
                        UniqueRows.Add(dataRow[columnId]);
                }

                foreach (DataRow dataRow in DuplicateRows)
                {
                    dataTable.Rows.Remove(dataRow);
                }

                return dataTable;
            }
            catch
            {
                return null;
            }
        }

        private void RefreshCars()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    MySqlCommand command = new MySqlCommand(_getCarIdQuery, connection);
                    command.Parameters.Add("@ClientId", MySqlDbType.Int32);
                    command.Parameters["@ClientId"].Value = _selectedClientId;

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter())
                    {
                        dataAdapter.SelectCommand = command;
                        _carsListTable = new DataTable();
                        dataAdapter.Fill(_carsListTable);
                    }

                    if (_carsListTable != null)
                    {
                        DataTable dataTable = new DataTable();

                        for (int i = 0; i < _carsListTable.Rows.Count; i++)
                        {
                            command = new MySqlCommand(CarsQuery, connection);

                            command.Parameters.Add("@Id", MySqlDbType.VarChar);
                            command.Parameters.Add("@Brand", MySqlDbType.VarChar);
                            command.Parameters.Add("@Model", MySqlDbType.VarChar);
                            command.Parameters.Add("@Number", MySqlDbType.VarChar);
                            command.Parameters.Add("@Color", MySqlDbType.VarChar);
                            command.Parameters.Add("@Capacity", MySqlDbType.VarChar);
                            command.Parameters.Add("@Fuel", MySqlDbType.VarChar);
                            command.Parameters.Add("@CarId", MySqlDbType.Int32);

                            command.Parameters["@Id"].Value = "Код";
                            command.Parameters["@Brand"].Value = "Марка";
                            command.Parameters["@Model"].Value = "Модель";
                            command.Parameters["@Number"].Value = "Держ. номер";
                            command.Parameters["@Color"].Value = "Колір";
                            command.Parameters["@Capacity"].Value = "Об'єм двигуна";
                            command.Parameters["@Fuel"].Value = "Тип пального";
                            command.Parameters["@CarId"].Value = _carsListTable.Rows[i][0].ToString();

                            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                            dataAdapter.SelectCommand = command;
                            dataAdapter.Fill(dataTable);

                            if ((dataTable.Rows.Count == 0) && (carsDataGridView.DataSource != null))
                            {
                                ((DataTable)carsDataGridView.DataSource).Rows.Clear();
                                carsDataGridView.Refresh();
                            }
                            else
                            {
                                dataTable = RemoveDuplicate(dataTable, 0);
                                carsDataGridView.Refresh();
                                carsDataGridView.DataSource = dataTable;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (carsDataGridView.DataSource != null)
            {
                carsDataGridView.Columns[0].Width = 50;
                carsDataGridView.Columns[1].Width = 150;
                carsDataGridView.Columns[2].Width = 170;
                carsDataGridView.Columns[3].Width = 120;
                carsDataGridView.Columns[4].Width = 120;
                carsDataGridView.Columns[5].Width = 120;
                carsDataGridView.Columns[6].Width = 120;

                carsDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                carsDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                carsDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                carsDataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                carsDataGridView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

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

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RefreshCars();

            carsDataGridView.Refresh();
        }

        private void addCarButton_Click(object sender, EventArgs e)
        {
            AddCarForm addCarForm = new AddCarForm();
            addCarForm.ShowDialog();
        }

        private string _selectedCarId;

        private void CreateOrderForm_Activated(object sender, EventArgs e)
        {
            if (orderCostTextBox.Text != string.Empty)
                orderCostTextBox.Text = GetOrderCost().ToString();
        }

        private string _getOrderHoursQuery = "SELECT services.Execution_Time FROM carservice.services WHERE services.Service_Name = @ServiceName";
        private string _getOrderCostServicesQuery = "SELECT services.Service_Cost FROM carservice.services WHERE services.Service_Name = @ServiceName";
        private string _getOrderCostMaterialsQuery = "SELECT materials.Material_Cost FROM carservice.materials WHERE materials.Material_Name = @MaterialName";

        private uint GetOrderHours()
        {
            uint orderHours = 0;

            using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
            {
                connection.Open();

                for (int i = 0; i < worksListBox.Items.Count; i++)
                {
                    MySqlCommand command = new MySqlCommand(_getOrderHoursQuery, connection);
                    command.Parameters.Add("@ServiceName", MySqlDbType.VarChar);
                    command.Parameters["@ServiceName"].Value = worksListBox.Items[i].ToString();
                    orderHours += (uint)command.ExecuteScalar();
                }

                connection.Close();
            }

            return orderHours;
        }

        private uint GetOrderCost()
        {
            uint servicesCost = 0;

            using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
            {
                connection.Open();

                if (worksListBox.Items.Count > 0)
                {
                    foreach (var item in worksListBox.Items)
                    {
                        MySqlCommand command = new MySqlCommand(_getOrderCostServicesQuery, connection);
                        command.Parameters.Add("@ServiceName", MySqlDbType.VarChar);
                        command.Parameters["@ServiceName"].Value = item.ToString();
                        servicesCost += (uint)command.ExecuteScalar();
                    }
                }

                connection.Close();
            }

            uint materialsCost = 0;

            using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
            {
                connection.Open();

                if (materialsListBox.Items.Count > 0)
                {
                    foreach (var item in materialsListBox.Items)
                    {
                        MySqlCommand command = new MySqlCommand(_getOrderCostMaterialsQuery, connection);
                        command.Parameters.Add("@MaterialName", MySqlDbType.VarChar);
                        command.Parameters["@MaterialName"].Value = item.ToString();
                        materialsCost += (uint)command.ExecuteScalar();
                    }
                }

                connection.Close();
            }

            uint orderCost = servicesCost + materialsCost;

            return orderCost;
        }

        private string _insertOrderQuery = "INSERT INTO carservice.orders (orders.Order_Id, orders.Client_Id, orders.Car_Id, orders.Reception_Date, " + 
                                           "orders.Completion_Date, orders.Order_Cost, orders.Note) " +
                                           "VALUES (@OrderId, @ClientId, @CarId, @ReceptionDate, @CompletionDate, @OrderCost, @Note)";

        private int _orderId;
        private int _clientId;
        private int _carId;
        private DateTime _receptionDate;
        private DateTime _completionDate;
        private uint _orderCost;
        private string _orderNote;

        private uint _orderHours;

        private void CreateOrder()
        {
            _orderId = Convert.ToInt32(orderNumTextBox.Text);
            _clientId = Convert.ToInt32(_selectedClientId);
            _carId = Convert.ToInt32(_selectedCarId);
            _receptionDate = Convert.ToDateTime(orderDateLabel.Text);
            _orderHours = GetOrderHours();
            _completionDate = _receptionDate.AddHours(_orderHours);
            _orderCost = GetOrderCost();
            _orderNote = noteTextBox.Text;

            using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(_insertOrderQuery, connection);

                command.Parameters.Add("@OrderId", MySqlDbType.Int32);
                command.Parameters.Add("@ClientId", MySqlDbType.Int32);
                command.Parameters.Add("@CarId", MySqlDbType.Int32);
                command.Parameters.Add("@ReceptionDate", MySqlDbType.DateTime);
                command.Parameters.Add("@CompletionDate", MySqlDbType.DateTime);
                command.Parameters.Add("@OrderCost", MySqlDbType.Int32);
                command.Parameters.Add("@Note", MySqlDbType.VarChar);

                command.Parameters["@OrderId"].Value = _orderId;
                command.Parameters["@ClientId"].Value = _clientId;
                command.Parameters["@CarId"].Value = _carId;
                command.Parameters["@ReceptionDate"].Value = _receptionDate;
                command.Parameters["@CompletionDate"].Value = _completionDate;
                command.Parameters["@OrderCost"].Value = _orderCost;
                command.Parameters["@Note"].Value = _orderNote;

                command.ExecuteNonQuery();

                connection.Close();
            }

            orderCostTextBox.Text = GetOrderCost().ToString();
        }

        private string _insertOrderContentQuery = "INSERT INTO carservice.order_content (order_content.Order_Num, order_content.Work_Type, order_content.Materials) " +
                                                  "VALUES (@OrderNum, @WorkType, @Materials)";

        private string _selectServiceId = "SELECT services.Service_Id FROM carservice.services WHERE services.Service_Name = @ServiceName";
        private string _selectMaterialsId = "SELECT materials.Material_Id FROM carservice.materials WHERE materials.Material_Name = @MaterialName";

        private uint _orderNumber;
        private uint _workId;
        private uint _materialId;

        private void CreateOrderContent()
        {
            _orderNumber = Convert.ToUInt32(orderNumTextBox.Text);

            using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
            {
                connection.Open();

                MySqlCommand command;

                for (int i = 0; i < worksListBox.Items.Count; i++)
                {
                    command = new MySqlCommand(_selectServiceId, connection);
                    command.Parameters.Add("@ServiceName", MySqlDbType.VarChar);
                    command.Parameters["@ServiceName"].Value = worksListBox.Items[i].ToString();
                    _workId = (uint)command.ExecuteScalar();

                    command = new MySqlCommand(_selectMaterialsId, connection);
                    command.Parameters.Add("@MaterialName", MySqlDbType.VarChar);
                    command.Parameters["@MaterialName"].Value = materialsListBox.Items[i].ToString();
                    _materialId = (uint)command.ExecuteScalar();

                    command = new MySqlCommand(_insertOrderContentQuery, connection);
                    command.Parameters.Add("@OrderNum", MySqlDbType.Int32);
                    command.Parameters.Add("@WorkType", MySqlDbType.Int32);
                    command.Parameters.Add("@Materials", MySqlDbType.Int32);
                    command.Parameters["@OrderNum"].Value = _orderNumber;
                    command.Parameters["@WorkType"].Value = _workId;
                    command.Parameters["@Materials"].Value = _materialId;

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        private void createOrderButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Оформити замовлення?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {
                    CreateOrder();
                    CreateOrderContent();

                    MessageBox.Show("Замовлення успішно оформлено", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult res = MessageBox.Show("Сформувати чек зараз?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        OrderReportForm orderReportForm = new OrderReportForm();
                        orderReportForm.SelectedOrderId = orderNumTextBox.Text;
                        orderReportForm.ShowDialog();
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void carsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (carsDataGridView.CurrentRow != null)
                _selectedCarId = carsDataGridView.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
