using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public partial class AddServiceForm : Form
    {
        public AddServiceForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private const string Query = "INSERT INTO carservice.services (Service_Name, Service_Cost, Execution_Time, Note) " +
                                     "VALUES (@ServiceName, @ServiceCost, @ExecutionTime, @Note)";

        private void addClientButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(Query, connection);

                    command.Parameters.Add("@ServiceName", MySqlDbType.VarChar);
                    command.Parameters.Add("@ServiceCost", MySqlDbType.Int32);
                    command.Parameters.Add("@ExecutionTime", MySqlDbType.Int32);
                    command.Parameters.Add("@Note", MySqlDbType.VarChar);

                    command.Parameters["@ServiceName"].Value = serviceNameTextBox.Text;
                    command.Parameters["@ServiceCost"].Value = costTextBox.Text;
                    command.Parameters["@ExecutionTime"].Value = executionTimeTextBox.Text;
                    command.Parameters["@Note"].Value = noteTextBox.Text;

                    command.ExecuteNonQuery();

                    connection.Close();

                    MessageBox.Show("Запис додано успішно", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    serviceNameTextBox.Text = string.Empty;
                    costTextBox.Text = string.Empty;
                    executionTimeTextBox.Text = string.Empty;
                    noteTextBox.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
