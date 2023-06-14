using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public partial class OrdersTableForm : Form
    {
        public OrdersTableForm()
        {
            InitializeComponent();
        }

        private string _selectedOrderId;

        private const string OrdersQuery = "SELECT orders.Order_Id AS @OrderId, clients.Surname AS @Surname, cars.Brand AS @Brand, cars.Model AS @Model, orders.Reception_Date AS @ReceptionDate, " +
                                           "orders.Completion_Date AS @CompletionDate, orders.Order_Cost AS @Cost, orders.Note AS @Note " +
                                           "FROM carservice.orders, carservice.cars, carservice.clients WHERE cars.Car_Id = orders.Car_Id AND clients.Client_Id = orders.Client_Id";

        private void GetOrders()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(OrdersQuery, connection);
                    command.Parameters.Add("@OrderId", MySqlDbType.VarChar);
                    command.Parameters.Add("@Surname", MySqlDbType.VarChar);
                    command.Parameters.Add("@Brand", MySqlDbType.VarChar);
                    command.Parameters.Add("@Model", MySqlDbType.VarChar);
                    command.Parameters.Add("@ReceptionDate", MySqlDbType.VarChar);
                    command.Parameters.Add("@CompletionDate", MySqlDbType.VarChar);
                    command.Parameters.Add("@Cost", MySqlDbType.VarChar);
                    command.Parameters.Add("@Note", MySqlDbType.VarChar);

                    command.Parameters["@OrderId"].Value = "Код";
                    command.Parameters["@Surname"].Value = "Прізвище";
                    command.Parameters["@Brand"].Value = "Марка";
                    command.Parameters["@Model"].Value = "Модель";
                    command.Parameters["@ReceptionDate"].Value = "Дата замовлення";
                    command.Parameters["@CompletionDate"].Value = "Дата виконання";
                    command.Parameters["@Cost"].Value = "Вартість (грн)";
                    command.Parameters["@Note"].Value = "Примітка";

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        bindingSource1.DataSource = dataTable;
                        bindingNavigator1.BindingSource = bindingSource1;
                        ordersDataGridView.DataSource = bindingSource1;
                    }

                    connection.Close();
                }

                ordersDataGridView.Columns[0].Width = 100;
                ordersDataGridView.Columns[1].Width = 170;
                ordersDataGridView.Columns[2].Width = 170;
                ordersDataGridView.Columns[3].Width = 200;
                ordersDataGridView.Columns[4].Width = 200;
                ordersDataGridView.Columns[5].Width = 200;
                ordersDataGridView.Columns[6].Width = 150;
                ordersDataGridView.Columns[7].Width = 200;

                ordersDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ordersDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ordersDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ordersDataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ordersDataGridView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ordersDataGridView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrdersTableForm_Load(object sender, EventArgs e)
        {
            ordersDataGridView.EnableHeadersVisualStyles = false;
            GetOrders();
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramForm aboutProgramForm = new AboutProgramForm();
            aboutProgramForm.ShowDialog();
        }

        private void ordersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ordersDataGridView.CurrentRow != null)
                _selectedOrderId = ordersDataGridView.CurrentRow.Cells[0].Value.ToString();
        }

        private void printReportButton_Click(object sender, EventArgs e)
        {
            OrderReportForm orderReportForm = new OrderReportForm();
            orderReportForm.SelectedOrderId = _selectedOrderId;
            orderReportForm.ShowDialog();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string SearchOrdersQuery = "SELECT orders.Order_Id AS @OrderId, clients.Surname AS @Surname, cars.Brand AS @Brand, cars.Model AS @Model, orders.Reception_Date AS @ReceptionDate, " +
                                       "orders.Completion_Date AS @CompletionDate, orders.Order_Cost AS @Cost, orders.Note AS @Note " +
                                       "FROM carservice.orders, carservice.cars, carservice.clients WHERE cars.Car_Id = orders.Car_Id AND clients.Client_Id = orders.Client_Id " +
                                       $"AND clients.Surname LIKE '%{searchTextBox.Text}%'";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(SearchOrdersQuery, connection);
                    command.Parameters.Add("@OrderId", MySqlDbType.VarChar);
                    command.Parameters.Add("@Surname", MySqlDbType.VarChar);
                    command.Parameters.Add("@Brand", MySqlDbType.VarChar);
                    command.Parameters.Add("@Model", MySqlDbType.VarChar);
                    command.Parameters.Add("@ReceptionDate", MySqlDbType.VarChar);
                    command.Parameters.Add("@CompletionDate", MySqlDbType.VarChar);
                    command.Parameters.Add("@Cost", MySqlDbType.VarChar);
                    command.Parameters.Add("@Note", MySqlDbType.VarChar);

                    command.Parameters["@OrderId"].Value = "Код";
                    command.Parameters["@Surname"].Value = "Прізвище";
                    command.Parameters["@Brand"].Value = "Марка";
                    command.Parameters["@Model"].Value = "Модель";
                    command.Parameters["@ReceptionDate"].Value = "Дата замовлення";
                    command.Parameters["@CompletionDate"].Value = "Дата виконання";
                    command.Parameters["@Cost"].Value = "Вартість (грн)";
                    command.Parameters["@Note"].Value = "Примітка";

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        bindingSource1.DataSource = dataTable;
                        ordersDataGridView.DataSource = bindingSource1;
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            GetOrders();
            ordersDataGridView.Refresh();
        }

        private const string DeleteOrderQuery = "DELETE FROM carservice.orders WHERE orders.Order_Id = @SelectedOrderId";

        private void deleteRecordButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Видалити вибраний запис?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                    {
                        connection.Open();

                        MySqlCommand command = new MySqlCommand(DeleteOrderQuery, connection);
                        command.Parameters.Add("@SelectedOrderId", MySqlDbType.Int32);
                        command.Parameters["@SelectedOrderId"].Value = _selectedOrderId;
                        command.ExecuteNonQuery();

                        connection.Close();
                    }

                    MessageBox.Show("Запис успішно видалено", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                refreshButton_Click(null, null);
            }
        }

        private void видалилиЗаписToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteRecordButton_Click(null, null);
        }

        private void друкуватиЗвітToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printReportButton_Click(null, null);
        }

        private const string SelectedClientIdQuery = "SELECT orders.Client_Id FROM carservice.orders WHERE orders.Order_Id = @SelectedOrderId";
        private const string SelectedCarIdQuery = "SELECT orders.Car_Id FROM carservice.orders WHERE orders.Order_Id = @SelectedOrderId";

        private string _selectedClientId;
        private string _selectedCarId;

        private void GetClientsCars()
        {
            using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(SelectedClientIdQuery, connection);
                command.Parameters.Add("@SelectedOrderId", MySqlDbType.Int32);
                command.Parameters["@SelectedOrderId"].Value = _selectedOrderId;
                _selectedClientId = command.ExecuteScalar().ToString();

                command = new MySqlCommand(SelectedCarIdQuery, connection);
                command.Parameters.Add("@SelectedOrderId", MySqlDbType.Int32);
                command.Parameters["@SelectedOrderId"].Value = _selectedOrderId;
                _selectedCarId = command.ExecuteScalar().ToString();
                connection.Close();
            }
        }

        private void editRecordButton_Click(object sender, EventArgs e)
        {
            EditOrderForm editOrderForm = new EditOrderForm();
            GetClientsCars();
            editOrderForm.SelectedOrderId = _selectedOrderId;
            editOrderForm.SelectedClientId = _selectedClientId;
            editOrderForm.SelectedCarId = _selectedCarId;
            editOrderForm.ShowDialog();
        }

        private void редагуватиЗаписToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            editRecordButton_Click(null, null);
        }

        private void вихідЗПрограмиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
