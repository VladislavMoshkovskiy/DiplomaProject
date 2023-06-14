using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public partial class PriceListForm : Form
    {
        public PriceListForm()
        {
            InitializeComponent();
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramForm aboutProgramForm = new AboutProgramForm();
            aboutProgramForm.ShowDialog();
        }

        private string _selectedServiceId;

        private const string PriceListQuery = "SELECT services.Service_Id AS @Id, services.Service_Name AS @ServiceName, services.Service_Cost AS @ServiceCost, " +
                                              "services.Execution_Time AS @ExecutionTime, services.Note AS @Note " +
                                              "FROM carservice.services";

        private void RefreshPriceList()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(PriceListQuery, connection);

                    command.Parameters.Add("@Id", MySqlDbType.VarChar);
                    command.Parameters.Add("@ServiceName", MySqlDbType.VarChar);
                    command.Parameters.Add("@ServiceCost", MySqlDbType.VarChar);
                    command.Parameters.Add("@ExecutionTime", MySqlDbType.VarChar);
                    command.Parameters.Add("@Note", MySqlDbType.VarChar);

                    command.Parameters["@Id"].Value = "Код";
                    command.Parameters["@ServiceName"].Value = "Назва послуги";
                    command.Parameters["@ServiceCost"].Value = "Вартість (грн)";
                    command.Parameters["@ExecutionTime"].Value = "Час виконання (год)";
                    command.Parameters["@Note"].Value = "Примітка";

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        bindingSource1.DataSource = dataTable;
                        bindingNavigator1.BindingSource = bindingSource1;
                        priceListDataGridView.DataSource = bindingSource1;
                    }

                    priceListDataGridView.Columns[0].Width = 100;
                    priceListDataGridView.Columns[1].Width = 350;
                    priceListDataGridView.Columns[2].Width = 200;
                    priceListDataGridView.Columns[3].Width = 200;
                    priceListDataGridView.Columns[4].Width = 200;

                    priceListDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    priceListDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    priceListDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    priceListDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PriceListForm_Load(object sender, EventArgs e)
        {
            priceListDataGridView.EnableHeadersVisualStyles = false;
            RefreshPriceList();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchServiceQuery = "SELECT services.Service_Id AS @Id, services.Service_Name AS @ServiceName, services.Service_Cost AS @ServiceCost, " +
                                        "services.Execution_Time AS @ExecutionTime, services.Note AS @Note " +
                                        $"FROM carservice.services WHERE services.Service_Name LIKE '%{searchTextBox.Text}%'";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(searchServiceQuery, connection);

                    command.Parameters.Add("@Id", MySqlDbType.VarChar);
                    command.Parameters.Add("@ServiceName", MySqlDbType.VarChar);
                    command.Parameters.Add("@ServiceCost", MySqlDbType.VarChar);
                    command.Parameters.Add("@ExecutionTime", MySqlDbType.VarChar);
                    command.Parameters.Add("@Note", MySqlDbType.VarChar);

                    command.Parameters["@Id"].Value = "Код";
                    command.Parameters["@ServiceName"].Value = "Назва послуги";
                    command.Parameters["@ServiceCost"].Value = "Вартість (грн)";
                    command.Parameters["@ExecutionTime"].Value = "Час виконання (год)";
                    command.Parameters["@Note"].Value = "Примітка";

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        bindingSource1.DataSource = dataTable;
                        priceListDataGridView.DataSource = bindingSource1;
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
            RefreshPriceList();
            priceListDataGridView.Refresh();
        }

        private const string DeleteQuery = "DELETE FROM carservice.services WHERE services.Service_Id = @SelectedServiceId";

        private void deleteRecordButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    DialogResult result = MessageBox.Show("Ви точно бажаєте видалити запис?", "Увага", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        MySqlCommand command = new MySqlCommand(DeleteQuery, connection);
                        command.Parameters.Add("@SelectedId", MySqlDbType.Int32);
                        command.Parameters["@SelectedId"].Value = _selectedServiceId;
                        command.ExecuteNonQuery();

                        MessageBox.Show("Запис видалено", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    priceListDataGridView.Refresh();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                RefreshPriceList();
                priceListDataGridView.Refresh();
            }
        }

        private void priceListDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (priceListDataGridView.CurrentRow != null)
                _selectedServiceId = priceListDataGridView.CurrentRow.Cells[0].Value.ToString();
        }

        private void видалилиЗаписToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteRecordButton_Click(null, null);
        }

        private void вихідЗПрограмиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addRecordButton_Click(object sender, EventArgs e)
        {
            AddServiceForm addServiceForm = new AddServiceForm();
            addServiceForm.ShowDialog();
        }

        private void додатиЗаписToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addRecordButton_Click(null, null);
        }

        private void editRecordButton_Click(object sender, EventArgs e)
        {
            EditServiceForm editServiceForm = new EditServiceForm();
            editServiceForm.SelectedServiceId = _selectedServiceId;
            editServiceForm.ShowDialog();
            RefreshPriceList();
            priceListDataGridView.Refresh();
        }

        private void редагуватиЗаписToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            editRecordButton_Click(null, null);
        }

        private void printReportButton_Click(object sender, EventArgs e)
        {
            PriceListReportForm priceListReportForm = new PriceListReportForm();
            priceListReportForm.ShowDialog();
        }

        private void друкуватиЗвітToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printReportButton_Click(null, null);
        }
    }
}
