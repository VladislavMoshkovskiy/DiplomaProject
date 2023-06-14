using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public partial class StorageTableForm : Form
    {
        public StorageTableForm()
        {
            InitializeComponent();
        }

        private const string GetStorageInfo = "SELECT materials.Material_Id AS @Id, materials.Material_Name AS @Name, materials.Material_Cost AS @Cost, " + 
                                              "materials.Amount AS @Amount, materials.Guarantee AS @Guarantee, materials.Note AS @Note " + 
                                              "FROM carservice.Materials";

        private void StorageTableForm_Load(object sender, EventArgs e)
        {
            storageDataGridView.EnableHeadersVisualStyles = false;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(GetStorageInfo, connection);

                    command.Parameters.Add("@Id", MySqlDbType.VarChar);
                    command.Parameters.Add("@Name", MySqlDbType.VarChar);
                    command.Parameters.Add("@Cost", MySqlDbType.VarChar);
                    command.Parameters.Add("@Amount", MySqlDbType.VarChar);
                    command.Parameters.Add("@Guarantee", MySqlDbType.VarChar);
                    command.Parameters.Add("@Note", MySqlDbType.VarChar);

                    command.Parameters["@Id"].Value = "Код";
                    command.Parameters["@Name"].Value = "Назва запчастини";
                    command.Parameters["@Cost"].Value = "Вартість (грн)";
                    command.Parameters["@Amount"].Value = "Кількість на складі";
                    command.Parameters["@Guarantee"].Value = "Гарантія";
                    command.Parameters["@Note"].Value = "Примітка";

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        bindingSource1.DataSource = dataTable;
                        bindingNavigator1.BindingSource = bindingSource1;
                        storageDataGridView.DataSource = bindingSource1;
                    }

                    connection.Close();

                    storageDataGridView.Columns[0].Width = 50;
                    storageDataGridView.Columns[1].Width = 270;
                    storageDataGridView.Columns[2].Width = 150;
                    storageDataGridView.Columns[3].Width = 250;
                    storageDataGridView.Columns[4].Width = 130;
                    storageDataGridView.Columns[5].Width = 130;

                    storageDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    storageDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    storageDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    storageDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    storageDataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            StorageTableForm_Load(null, null);
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

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text;

            string searchQuery = "SELECT materials.Material_Id AS @Id, materials.Material_Name AS @Name, materials.Material_Cost AS @Cost, " +
                                 "materials.Amount AS @Amount, materials.Guarantee AS @Guarantee, materials.Note AS @Note " +
                                 $"FROM carservice.Materials WHERE materials.Material_Name LIKE '%{searchText}%'";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(searchQuery, connection);

                    command.Parameters.Add("@Id", MySqlDbType.VarChar);
                    command.Parameters.Add("@Name", MySqlDbType.VarChar);
                    command.Parameters.Add("@Cost", MySqlDbType.VarChar);
                    command.Parameters.Add("@Amount", MySqlDbType.VarChar);
                    command.Parameters.Add("@Guarantee", MySqlDbType.VarChar);
                    command.Parameters.Add("@Note", MySqlDbType.VarChar);

                    command.Parameters["@Id"].Value = "Код";
                    command.Parameters["@Name"].Value = "Назва запчастини";
                    command.Parameters["@Cost"].Value = "Вартість (грн)";
                    command.Parameters["@Amount"].Value = "Кількість на складі";
                    command.Parameters["@Guarantee"].Value = "Гарантія";
                    command.Parameters["@Note"].Value = "Примітка";

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        bindingSource1.DataSource = dataTable;
                        bindingNavigator1.BindingSource = bindingSource1;
                        storageDataGridView.DataSource = bindingSource1;
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printReportButton_Click(object sender, EventArgs e)
        {
            StorageReportForm storageReportForm = new StorageReportForm();
            storageReportForm.ShowDialog();
        }

        private void друкуватиЗвітToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printReportButton_Click(null, null);
        }
    }
}
