using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public partial class ClientsTableForm : Form
    {
        private string _selectedClientId;
        private DataTable dataTable;

        public string SelectedClientId { get => _selectedClientId; }

        public ClientsTableForm()
        {
            InitializeComponent();
        }

        private const string ClientsQuery = "SELECT clients.Client_Id AS @Id, clients.Surname AS @Surname, clients.Name " +
                                            "AS @Name, clients.Patronymic AS @Patronymic, clients.Passport AS @Passport, " +
                                            "clients.Phone AS @Phone FROM carservice.clients";

        private void RefreshClients()
        {
            try
            {
                if (clientsDataGridView.CurrentRow != null)
                    _selectedClientId = clientsDataGridView.CurrentRow.Cells[0].Value.ToString();

                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(ClientsQuery, connection);

                    command.Parameters.Add("@Id", MySqlDbType.VarChar);
                    command.Parameters.Add("@Surname", MySqlDbType.VarChar);
                    command.Parameters.Add("@Name", MySqlDbType.VarChar);
                    command.Parameters.Add("@Patronymic", MySqlDbType.VarChar);
                    command.Parameters.Add("@Passport", MySqlDbType.VarChar);
                    command.Parameters.Add("@Phone", MySqlDbType.VarChar);

                    command.Parameters["@Id"].Value = "Код";
                    command.Parameters["@Surname"].Value = "Прізвище";
                    command.Parameters["@Name"].Value = "Ім'я";
                    command.Parameters["@Patronymic"].Value = "По-батькові";
                    command.Parameters["@Passport"].Value = "Паспорт";
                    command.Parameters["@Phone"].Value = "Телефон";

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                    {
                        dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        bindingSource1.DataSource = dataTable;
                        bindingNavigator1.BindingSource = bindingSource1;
                        clientsDataGridView.DataSource = bindingSource1;
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            clientsDataGridView.Columns[0].Width = 100;
            clientsDataGridView.Columns[1].Width = 250;
            clientsDataGridView.Columns[2].Width = 250;
            clientsDataGridView.Columns[3].Width = 250;
            clientsDataGridView.Columns[4].Width = 130;
            clientsDataGridView.Columns[5].Width = 130;

            clientsDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clientsDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clientsDataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void ClientsTableForm_Load(object sender, EventArgs e)
        {
            clientsDataGridView.EnableHeadersVisualStyles = false;
            RefreshClients();
        }

        private string searchQuery;

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text;

            string SearchNameQuery = "SELECT clients.Client_Id AS @Id, clients.Surname AS @Surname, clients.Name " +
                                     "AS @Name, clients.Patronymic AS @Patronymic, clients.Passport AS @Passport, " +
                                     "clients.Phone AS @Phone FROM carservice.clients " +
                                     $"WHERE clients.Surname LIKE '%{searchText}%'";

            string SearchPassportQuery = "SELECT clients.Client_Id AS @Id, clients.Surname AS @Surname, clients.Name " +
                                         "AS @Name, clients.Patronymic AS @Patronymic, clients.Passport AS @Passport, " +
                                         "clients.Phone AS @Phone FROM carservice.clients " +
                                         $"WHERE clients.Passport LIKE '%{searchText}%'";

            string SearchPhoneQuery = "SELECT clients.Client_Id AS @Id, clients.Surname AS @Surname, clients.Name " +
                                      "AS @Name, clients.Patronymic AS @Patronymic, clients.Passport AS @Passport, " +
                                      "clients.Phone AS @Phone FROM carservice.clients " +
                                      $"WHERE clients.Phone LIKE '%{searchText}%'";

            if (surnameSearchRadioButton.Checked)
                searchQuery = SearchNameQuery;
            else if (passportSearchRadioButton.Checked)
                searchQuery = SearchPassportQuery;
            else if (phoneSearchRadioButton.Checked)
                searchQuery = SearchPhoneQuery;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    MySqlCommand command = new MySqlCommand(searchQuery, connection);

                    command.Parameters.Add("@Id", MySqlDbType.VarChar);
                    command.Parameters.Add("@Surname", MySqlDbType.VarChar);
                    command.Parameters.Add("@Name", MySqlDbType.VarChar);
                    command.Parameters.Add("@Patronymic", MySqlDbType.VarChar);
                    command.Parameters.Add("@Passport", MySqlDbType.VarChar);
                    command.Parameters.Add("@Phone", MySqlDbType.VarChar);

                    command.Parameters["@Id"].Value = "Код";
                    command.Parameters["@Surname"].Value = "Прізвище";
                    command.Parameters["@Name"].Value = "Ім'я";
                    command.Parameters["@Patronymic"].Value = "По-батькові";
                    command.Parameters["@Passport"].Value = "Паспорт";
                    command.Parameters["@Phone"].Value = "Телефон";

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                    {
                        dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        bindingSource1.DataSource = dataTable;
                        clientsDataGridView.DataSource = bindingSource1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshClients();
            clientsDataGridView.Refresh();
        }

        private void addRecordButton_Click(object sender, EventArgs e)
        {
            AddClientForm addClientForm = new AddClientForm();
            addClientForm.ShowDialog();

            RefreshClients();
            clientsDataGridView.Refresh();
        }

        private void ClientsTableForm_Activated(object sender, EventArgs e)
        {
            RefreshClients();
            clientsDataGridView.Refresh();
        }

        private const string DeleteQuery = "DELETE FROM carservice.clients WHERE clients.Client_Id = @SelectedId";

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
                        command.Parameters["@SelectedId"].Value = _selectedClientId;
                        command.ExecuteNonQuery();

                        MessageBox.Show("Запис видалено", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    clientsDataGridView.Refresh();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                RefreshClients();
            }
        }

        private void printReportButton_Click(object sender, EventArgs e)
        {
            ClientsReportForm clientsReportForm = new ClientsReportForm();
            clientsReportForm.ShowDialog();
        }

        private void editRecordButton_Click(object sender, EventArgs e)
        {
            EditClientForm editClientForm = new EditClientForm();
            editClientForm.SelectedClientId = _selectedClientId;
            editClientForm.ShowDialog();
        }

        private void вихідЗПрограмиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void друкуватиЗвітToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientsReportForm clientsReportForm = new ClientsReportForm();
            clientsReportForm.ShowDialog();
        }

        private void додатиЗаписToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addRecordButton_Click(null, null);
        }

        private void видалилиЗаписToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteRecordButton_Click(null, null);
        }

        private void редагуватиЗаписToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            editRecordButton_Click(null, null);
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramForm aboutProgramForm = new AboutProgramForm();
            aboutProgramForm.ShowDialog();
        }

        private void clientsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (clientsDataGridView.CurrentRow != null)
                _selectedClientId = clientsDataGridView.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
