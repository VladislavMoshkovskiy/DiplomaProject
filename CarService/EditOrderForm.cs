using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public partial class EditOrderForm : Form
    {
        public EditOrderForm()
        {
            InitializeComponent();
        }

        private string _selectedOrderId;
        private string _selectedClientId;
        private string _selectedCarId;

        public string SelectedOrderId { get => _selectedOrderId; set => _selectedOrderId = value; }
        public string SelectedClientId { get => _selectedClientId; set => _selectedClientId = value; }
        public string SelectedCarId { get => _selectedCarId; set => _selectedCarId = value; }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditOrderForm_Load(object sender, EventArgs e)
        {
            string SelectClientInfo = "SELECT clients.Surname, clients.Name, clients.Patronymic FROM carservice.clients " +
                                      $"WHERE clients.Client_Id = {_selectedClientId}";
            string SelectCarInfo = $"SELECT cars.Brand, cars.Model FROM carservice.cars WHERE cars.Car_Id = {_selectedCarId}";

            DataTable clientInfoTable = new DataTable();
            clientInfoTable = DBWork.GetDataTableFromSqlQuery(SelectClientInfo);
            DataTable carInfoTable = new DataTable();
            carInfoTable = DBWork.GetDataTableFromSqlQuery(SelectCarInfo);

            string[] clientInfoList = new string[3];
            string[] carInfoList = new string[2];

            string clientInfo;
            string carInfo;

            for (int i = 0; i < clientInfoTable.Columns.Count; i++)
            {
                clientInfoList[i] = clientInfoTable.Rows[0][i].ToString();
            }

            clientInfo = String.Join(" ", clientInfoList);

            for (int i = 0; i < carInfoTable.Columns.Count; i++)
            {
                carInfoList[i] = carInfoTable.Rows[0][i].ToString();
            }

            carInfo = String.Join(" ", carInfoList);

            clientTextBox.Text = clientInfo;
            carTextBox.Text = carInfo;

            string SelectOrderInfo = "SELECT orders.Reception_Date, orders.Completion_Date, orders.Order_Cost, orders.Note " +
                                     $"FROM carservice.orders WHERE orders.Order_Id = {_selectedOrderId}";

            DataTable orderInfoTable = DBWork.GetDataTableFromSqlQuery(SelectOrderInfo);

            receptionOrderDate.Value = Convert.ToDateTime(orderInfoTable.Rows[0][0]);
            completionOrderDate.Value = Convert.ToDateTime(orderInfoTable.Rows[0][1]);
            costTextBox.Text = orderInfoTable.Rows[0][2].ToString();
        }

        private void editClientClick_Click(object sender, EventArgs e)
        {
            ClientsTableForm clientsTableForm = new ClientsTableForm();
            clientsTableForm.ShowDialog();
            _selectedClientId = clientsTableForm.SelectedClientId;
            RefreshClientInfo();
        }

        private void RefreshClientInfo()
        {
            string SelectClientInfo = "SELECT clients.Surname, clients.Name, clients.Patronymic FROM carservice.clients " +
                                      $"WHERE clients.Client_Id = {_selectedClientId}";

            DataTable clientInfoTable = new DataTable();
            clientInfoTable = DBWork.GetDataTableFromSqlQuery(SelectClientInfo);

            _clientInfoList = new string[3];
            string clientInfo;

            for (int i = 0; i < clientInfoTable.Columns.Count; i++)
            {
                _clientInfoList[i] = clientInfoTable.Rows[0][i].ToString();
            }

            clientInfo = string.Join(" ", _clientInfoList);

            clientTextBox.Text = clientInfo;
        }

        private void RefreshCarInfo()
        {
            string SelectCarInfo = $"SELECT cars.Brand, cars.Model FROM carservice.cars WHERE cars.Car_Id = {_selectedCarId}";

            DataTable carInfoTable = new DataTable();
            carInfoTable = DBWork.GetDataTableFromSqlQuery(SelectCarInfo);

            _carInfoList = new string[2];
            string carInfo;


            for (int i = 0; i < carInfoTable.Columns.Count; i++)
            {
                _carInfoList[i] = carInfoTable.Rows[0][i].ToString();
            }

            carInfo = string.Join(" ", _carInfoList);

            carTextBox.Text = carInfo;
        }

        private void EditOrderForm_Activated(object sender, EventArgs e)
        {
            RefreshClientInfo();
            RefreshCarInfo();
        }

        private void editCarClick_Click(object sender, EventArgs e)
        {
            CarsTableForm carsTableForm = new CarsTableForm();
            carsTableForm.ShowDialog();
            _selectedCarId = carsTableForm.SelectedCarId;
            RefreshCarInfo();
        }

        private string[] _clientInfoList;
        private string[] _carInfoList;

        private const string EditOrderClientInfoQuery = "UPDATE carservice.orders, carservice.clients SET orders.Client_Id = clients.Client_Id " +
                                                        "WHERE clients.Surname = @Surname AND clients.Name = @Name AND Patronymic = @Patronymic AND orders.Order_Id = @SelectedOrderId";
        private const string EditOrderCarInfoQuery = "UPDATE carservice.orders, carservice.cars SET orders.Car_Id = cars.Car_Id WHERE cars.Brand = @Brand AND cars.Model = @Model AND orders.Order_Id = @SelectedOrderId";

        private void editClientButton_Click(object sender, EventArgs e)
        {
            _clientInfoList = new string[3];
            _carInfoList = new string[2];

            _clientInfoList = clientTextBox.Text.Split(' ');
            _carInfoList = carTextBox.Text.Split(' ');

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    MySqlCommand clientCommand = new MySqlCommand(EditOrderClientInfoQuery, connection);
                    clientCommand.Parameters.Add("@Surname", MySqlDbType.VarChar);
                    clientCommand.Parameters.Add("@Name", MySqlDbType.VarChar);
                    clientCommand.Parameters.Add("@Patronymic", MySqlDbType.VarChar);
                    clientCommand.Parameters.Add("@SelectedOrderId", MySqlDbType.Int32);
                    clientCommand.Parameters["@Surname"].Value = _clientInfoList[0];
                    clientCommand.Parameters["@Name"].Value = _clientInfoList[1];
                    clientCommand.Parameters["@Patronymic"].Value = _clientInfoList[2];
                    clientCommand.Parameters["@SelectedOrderId"].Value = _selectedOrderId;

                    MySqlCommand carCommand = new MySqlCommand(EditOrderCarInfoQuery, connection);
                    carCommand.Parameters.Add("@Brand", MySqlDbType.VarChar);
                    carCommand.Parameters.Add("@Model", MySqlDbType.VarChar);
                    carCommand.Parameters.Add("@SelectedOrderId", MySqlDbType.Int32);
                    carCommand.Parameters["@Brand"].Value = _carInfoList[0];
                    carCommand.Parameters["@Model"].Value = _carInfoList[1];
                    carCommand.Parameters["@SelectedOrderId"].Value = _selectedOrderId;

                    DialogResult result = MessageBox.Show("Зберегти зміни?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        clientCommand.ExecuteNonQuery();
                        carCommand.ExecuteNonQuery();
                    }

                    connection.Close();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
