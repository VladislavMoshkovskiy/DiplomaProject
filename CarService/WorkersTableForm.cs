using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public partial class WorkersTableForm : Form
    {
        public WorkersTableForm()
        {
            InitializeComponent();
        }

        private string _selectedWorkerId;
        public string SelectedWorkerId { get => _selectedWorkerId; set => _selectedWorkerId = value; }

        private const string WorkersInfoQuery = "SELECT workers.Worker_Id AS @Id, workers.Surname AS @Surname, workers.Name AS @Name, workers.Patronymic AS @Patronymic, " +
                                                "workers.Worker_Position AS @Position, workers.Address AS @Address, workers.Phone AS @Phone " +
                                                "FROM carservice.workers";

        private void RefreshWorkers()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(WorkersInfoQuery, connection);

                    command.Parameters.Add("@Id", MySqlDbType.VarChar);
                    command.Parameters.Add("@Surname", MySqlDbType.VarChar);
                    command.Parameters.Add("@Name", MySqlDbType.VarChar);
                    command.Parameters.Add("@Patronymic", MySqlDbType.VarChar);
                    command.Parameters.Add("@Position", MySqlDbType.VarChar);
                    command.Parameters.Add("@Address", MySqlDbType.VarChar);
                    command.Parameters.Add("@Phone", MySqlDbType.VarChar);

                    command.Parameters["@Id"].Value = "Код";
                    command.Parameters["@Surname"].Value = "Прізвище";
                    command.Parameters["@Name"].Value = "Ім'я";
                    command.Parameters["@Patronymic"].Value = "По-батькові";
                    command.Parameters["@Position"].Value = "Посада";
                    command.Parameters["@Address"].Value = "Адреса";
                    command.Parameters["@Phone"].Value = "Телефон";

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        bindingSource1.DataSource = dataTable;
                        bindingNavigator1.BindingSource = bindingSource1;
                        workersDataGridView.DataSource = bindingSource1;
                    }

                    connection.Close();
                }

                workersDataGridView.Columns[0].Width = 100;
                workersDataGridView.Columns[1].Width = 170;
                workersDataGridView.Columns[2].Width = 170;
                workersDataGridView.Columns[3].Width = 170;
                workersDataGridView.Columns[4].Width = 200;
                workersDataGridView.Columns[5].Width = 200;
                workersDataGridView.Columns[6].Width = 150;

                workersDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                workersDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                workersDataGridView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

        private void вихідЗПрограмиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void workersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (workersDataGridView.CurrentRow != null)
                _selectedWorkerId = workersDataGridView.CurrentRow.Cells[0].Value.ToString();
        }

        private void WorkersTableForm_Load(object sender, EventArgs e)
        {
            workersDataGridView.EnableHeadersVisualStyles = false;
            RefreshWorkers();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshWorkers();
            workersDataGridView.Refresh();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            WorkersReportForm workersReportForm = new WorkersReportForm();
            workersReportForm.ShowDialog();
        }

        private void друкуватиЗвітToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printButton_Click(null, null);
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string SearchWorkersQuery = "SELECT workers.Worker_Id AS @Id, workers.Surname AS @Surname, workers.Name AS @Name, workers.Patronymic AS @Patronymic, " +
                                        "workers.Worker_Position AS @Position, workers.Address AS @Address, workers.Phone AS @Phone " +
                                        $"FROM carservice.workers WHERE workers.Surname LIKE '%{searchTextBox.Text}%' OR workers.Name LIKE '%{searchTextBox.Text}%' OR workers.Patronymic LIKE '%{searchTextBox.Text}%'";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(SearchWorkersQuery, connection);

                    command.Parameters.Add("@Id", MySqlDbType.VarChar);
                    command.Parameters.Add("@Surname", MySqlDbType.VarChar);
                    command.Parameters.Add("@Name", MySqlDbType.VarChar);
                    command.Parameters.Add("@Patronymic", MySqlDbType.VarChar);
                    command.Parameters.Add("@Position", MySqlDbType.VarChar);
                    command.Parameters.Add("@Address", MySqlDbType.VarChar);
                    command.Parameters.Add("@Phone", MySqlDbType.VarChar);

                    command.Parameters["@Id"].Value = "Код";
                    command.Parameters["@Surname"].Value = "Прізвище";
                    command.Parameters["@Name"].Value = "Ім'я";
                    command.Parameters["@Patronymic"].Value = "По-батькові";
                    command.Parameters["@Position"].Value = "Посада";
                    command.Parameters["@Address"].Value = "Адреса";
                    command.Parameters["@Phone"].Value = "Телефон";

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        bindingSource1.DataSource = dataTable;
                        workersDataGridView.DataSource = bindingSource1;
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
