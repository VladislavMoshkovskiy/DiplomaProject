using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public partial class EditServiceForm : Form
    {
        public EditServiceForm()
        {
            InitializeComponent();
        }

        private string _selectedServiceId;

        public string SelectedServiceId { get => _selectedServiceId; set => _selectedServiceId = value; }

        private string _queryServiceName = "SELECT services.Service_Name FROM carservice.services WHERE services.Service_Id = @Id";
        private string _queryServiceCost = "SELECT services.Service_Cost FROM carservice.services WHERE services.Service_Id = @Id";
        private string _queryServiceExecutionTime = "SELECT services.Execution_Time FROM carservice.services WHERE services.Service_Id = @Id";
        private string _queryServiceNote = "SELECT services.Note FROM carservice.services WHERE services.Service_Id = @Id";

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditServiceForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(_queryServiceName, connection);
                    command.Parameters.Add("@Id", MySqlDbType.Int32);
                    command.Parameters["@Id"].Value = _selectedServiceId;
                    serviceNameTextBox.Text = (string)command.ExecuteScalar();

                    command = new MySqlCommand(_queryServiceCost, connection);
                    command.Parameters.Add("@Id", MySqlDbType.Int32);
                    command.Parameters["@Id"].Value = _selectedServiceId;
                    uint cost = (uint)command.ExecuteScalar();
                    costTextBox.Text = cost.ToString();

                    command = new MySqlCommand(_queryServiceExecutionTime, connection);
                    command.Parameters.Add("@Id", MySqlDbType.Int32);
                    command.Parameters["@Id"].Value = _selectedServiceId;
                    uint executionTime = (uint)command.ExecuteScalar();
                    executionTimeTextBox.Text = executionTime.ToString();

                    command = new MySqlCommand(_queryServiceNote, connection);
                    command.Parameters.Add("@Id", MySqlDbType.Int32);
                    command.Parameters["@Id"].Value = _selectedServiceId;
                    if (command.ExecuteScalar() != DBNull.Value)
                        noteTextBox.Text = (string)command.ExecuteScalar();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string _queryEditService = "UPDATE carservice.services " +
                                           "SET services.Service_Name = @ServiceName, services.Service_Cost = @ServiceCost, services.Execution_Time = @ExecutionTime, " +
                                           "services.Note = @Note WHERE services.Service_Id = @Id";

        private void editServiceButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Зберегти внесені зміни?", "Увага", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                    {
                        connection.Open();

                        MySqlCommand command = new MySqlCommand(_queryEditService, connection);

                        command.Parameters.Add("@ServiceName", MySqlDbType.VarChar);
                        command.Parameters.Add("@ServiceCost", MySqlDbType.Int32);
                        command.Parameters.Add("@ExecutionTime", MySqlDbType.Int32);
                        command.Parameters.Add("@Note", MySqlDbType.VarChar);
                        command.Parameters.Add("@Id", MySqlDbType.Int32);

                        command.Parameters["@ServiceName"].Value = serviceNameTextBox.Text;
                        command.Parameters["@ServiceCost"].Value = costTextBox.Text;
                        command.Parameters["@ExecutionTime"].Value = executionTimeTextBox.Text;
                        command.Parameters["@Note"].Value = noteTextBox.Text;
                        command.Parameters["@Id"].Value = _selectedServiceId;

                        command.ExecuteNonQuery();

                        MessageBox.Show("Зміни успішно внесено", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        connection.Close();

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                EditServiceForm_Load(null, null);
            }
        }
    }
}
