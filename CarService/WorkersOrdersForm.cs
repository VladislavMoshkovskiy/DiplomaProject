using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public partial class WorkersOrdersForm : Form
    {
        public WorkersOrdersForm()
        {
            InitializeComponent();
        }

        private const string OrdersInfoQuery = "SELECT order_content.Order_Num AS @OrderNum, order_content.Worker AS @Worker, services.Service_Name AS @Service, " +
                                               "materials.Material_Name AS @Material FROM carservice.order_content, carservice.services, carservice.materials " +
                                               "WHERE services.Service_Id = order_content.Work_Type AND materials.Material_Id = order_content.Materials";

        private void RefreshOrders()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(OrdersInfoQuery, connection);

                    command.Parameters.Add("@OrderNum", MySqlDbType.VarChar);
                    command.Parameters.Add("@Worker", MySqlDbType.VarChar);
                    command.Parameters.Add("@Service", MySqlDbType.VarChar);
                    command.Parameters.Add("@Material", MySqlDbType.VarChar);

                    command.Parameters["@OrderNum"].Value = "Код";
                    command.Parameters["@Worker"].Value = "Виконавець";
                    command.Parameters["@Service"].Value = "Вид роботи";
                    command.Parameters["@Material"].Value = "Запчастини";

                    DataTable dataTable = new DataTable();
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                    {
                        dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        bindingSource1.DataSource = dataTable;
                        bindingNavigator1.BindingSource = bindingSource1;
                        ordersDataGridView.DataSource = bindingSource1;
                    }

                    connection.Close();

                    ordersDataGridView.Columns[0].Width = 100;
                    ordersDataGridView.Columns[1].Width = 250;
                    ordersDataGridView.Columns[2].Width = 300;
                    ordersDataGridView.Columns[3].Width = 300;

                    ordersDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    ordersDataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    ordersDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    ordersDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WorkersOrdersForm_Load(object sender, EventArgs e)
        {
            ordersDataGridView.EnableHeadersVisualStyles = false;
            RefreshOrders();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string SearchOrdersQuery = "SELECT order_content.Order_Num AS @OrderNum, order_content.Worker AS @Worker, services.Service_Name AS @Service, " +
                                       "materials.Material_Name AS @Material FROM carservice.order_content, carservice.services, carservice.materials " +
                                       "WHERE services.Service_Id = order_content.Work_Type AND materials.Material_Id = order_content.Materials " +
                                       $"AND services.Service_Name LIKE '%{searchTextBox.Text}%'";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(SearchOrdersQuery, connection);

                    command.Parameters.Add("@OrderNum", MySqlDbType.VarChar);
                    command.Parameters.Add("@Worker", MySqlDbType.VarChar);
                    command.Parameters.Add("@Service", MySqlDbType.VarChar);
                    command.Parameters.Add("@Material", MySqlDbType.VarChar);

                    command.Parameters["@OrderNum"].Value = "Код";
                    command.Parameters["@Worker"].Value = "Виконавець";
                    command.Parameters["@Service"].Value = "Вид роботи";
                    command.Parameters["@Material"].Value = "Запчастини";

                    DataTable dataTable = new DataTable();
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                    {
                        dataTable = new DataTable();
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

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramForm aboutProgramForm = new AboutProgramForm();
            aboutProgramForm.ShowDialog();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshOrders();
            ordersDataGridView.Refresh();
        }

        private string _selectedWorkerId;
        private string _selectedOrderId;
        private string _selectedServiceId;
        private string _selectedServiceName;

        string addWorkerQuery = "UPDATE carservice.order_content SET order_content.Worker = @Worker WHERE order_content.Order_Num = @OrderNum AND order_content.Work_Type = @ServiceId";
        string getServiceId = "SELECT services.Service_Id FROM carservice.services WHERE services.Service_Name = @ServiceName";

        private void addWorkerButton_Click(object sender, EventArgs e)
        {
            WorkersTableForm workersTableForm = new WorkersTableForm();
            workersTableForm.ShowDialog();
            _selectedWorkerId = workersTableForm.SelectedWorkerId;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    MySqlCommand sqlCommand = new MySqlCommand(getServiceId, connection);
                    sqlCommand.Parameters.Add("@ServiceName", MySqlDbType.VarChar);
                    sqlCommand.Parameters["@ServiceName"].Value = _selectedServiceName;
                    _selectedServiceId = sqlCommand.ExecuteScalar().ToString();

                    using (MySqlCommand command = new MySqlCommand(addWorkerQuery, connection))
                    {
                        command.Parameters.Add("@Worker", MySqlDbType.Int32);
                        command.Parameters.Add("@OrderNum", MySqlDbType.Int32);
                        command.Parameters.Add("@ServiceId", MySqlDbType.Int32);
                        command.Parameters["@Worker"].Value = _selectedWorkerId;
                        command.Parameters["@OrderNum"].Value = _selectedOrderId;
                        command.Parameters["@ServiceId"].Value = _selectedServiceId;

                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RefreshOrders();
            ordersDataGridView.Refresh();
        }

        private void ordersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ordersDataGridView.CurrentRow != null)
            {
                _selectedOrderId = ordersDataGridView.CurrentRow.Cells[0].Value.ToString();
                _selectedServiceName = ordersDataGridView.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void вихідЗПрограмиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
