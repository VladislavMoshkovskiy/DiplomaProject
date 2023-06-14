using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public partial class OrdersControlForm : Form
    {
        public OrdersControlForm()
        {
            InitializeComponent();
        }

        private string _selectedOrderId;

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramForm aboutProgramForm = new AboutProgramForm();
            aboutProgramForm.ShowDialog();
        }

        private void вихідЗПрограмиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrdersControl()
        {
            for (int i = 0; i < ordersDataGridView.Rows.Count; i++)
            {
                DateTime orderCompletionDate = Convert.ToDateTime(ordersDataGridView.Rows[i].Cells[5].Value);

                if (orderCompletionDate > DateTime.Now)
                {
                    ordersDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.SandyBrown;
                }
                else
                {
                    ordersDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        private void OrdersControlForm_Load(object sender, EventArgs e)
        {
            GetOrders();
        }

        private void OrdersControlForm_Activated(object sender, EventArgs e)
        {
            OrdersControl();
        }

        private void ordersDataGridView_Sorted(object sender, EventArgs e)
        {
            OrdersControl();
        }

        private const string CompleteOrderQuery = "UPDATE carservice.orders SET orders.Completion_Date = @NewDate WHERE orders.Order_Id = @SelectedOrderId";

        private void completeOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(CompleteOrderQuery, connection);
                    command.Parameters.Add("@NewDate", MySqlDbType.DateTime);
                    command.Parameters.Add("@SelectedOrderId", MySqlDbType.Int32);
                    command.Parameters["@NewDate"].Value = DateTime.Now;
                    command.Parameters["@SelectedOrderId"].Value = _selectedOrderId;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            GetOrders();
            OrdersControl();
            ordersDataGridView.Refresh();
        }

        private void ordersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ordersDataGridView.CurrentRow != null)
                _selectedOrderId = ordersDataGridView.CurrentRow.Cells[0].Value.ToString();
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

            OrdersControl();
        }
    }
}
