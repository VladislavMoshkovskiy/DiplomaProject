using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public partial class EditClientForm : Form
    {
        private static string _selectedClientId;

        public string SelectedClientId { get => _selectedClientId; set => _selectedClientId = value; }

        public EditClientForm()
        {
            InitializeComponent();
        }

        private string _queryClientSurname = "SELECT clients.Surname FROM carservice.clients WHERE clients.Client_Id = @Id";
        private string _queryClientName = "SELECT clients.Name FROM carservice.clients WHERE clients.Client_Id = @Id";
        private string _queryClientPatronymic = "SELECT clients.Patronymic FROM carservice.clients WHERE clients.Client_Id = @Id";
        private string _queryClientPassport = "SELECT clients.Passport FROM carservice.clients WHERE clients.Client_Id = @Id";
        private string _queryClientPhone = "SELECT clients.Phone FROM carservice.clients WHERE clients.Client_Id = @Id";

        private void EditClientForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(_queryClientSurname, connection);
                    command.Parameters.Add("@id", MySqlDbType.Int32);
                    command.Parameters["@id"].Value = _selectedClientId;
                    surnameTextBox.Text = (string)command.ExecuteScalar();
                    command = new MySqlCommand(_queryClientName, connection);
                    command.Parameters.Add("@id", MySqlDbType.Int32);
                    command.Parameters["@id"].Value = _selectedClientId;
                    nameTextBox.Text = (string)command.ExecuteScalar();
                    command = new MySqlCommand(_queryClientPatronymic, connection);
                    command.Parameters.Add("@id", MySqlDbType.Int32);
                    command.Parameters["@id"].Value = _selectedClientId;
                    patronymicTextBox.Text = (string)command.ExecuteScalar();
                    command = new MySqlCommand(_queryClientPassport, connection);
                    command.Parameters.Add("@id", MySqlDbType.Int32);
                    command.Parameters["@id"].Value = _selectedClientId;
                    passportTextBox.Text = (string)command.ExecuteScalar();
                    command = new MySqlCommand(_queryClientPhone, connection);
                    command.Parameters.Add("@id", MySqlDbType.Int32);
                    command.Parameters["@id"].Value = _selectedClientId;
                    phoneTextBox.Text = (string)command.ExecuteScalar();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string _queryEditClient = "UPDATE carservice.clients " + 
                                          "SET clients.Surname = @Surname, clients.Name = @Name, clients.Patronymic = @Patronymic, " + 
                                          "clients.Passport = @Passport, clients.Phone = @Phone " + 
                                          "WHERE clients.Client_Id = @Id";

        private void editClientButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Зберегти внесені зміни?", "Увага", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                    {
                        connection.Open();

                        MySqlCommand command = new MySqlCommand(_queryEditClient, connection);

                        command.Parameters.Add("@Surname", MySqlDbType.VarChar);
                        command.Parameters.Add("@Name", MySqlDbType.VarChar);
                        command.Parameters.Add("@Patronymic", MySqlDbType.VarChar);
                        command.Parameters.Add("@Passport", MySqlDbType.VarChar);
                        command.Parameters.Add("@Phone", MySqlDbType.VarChar);
                        command.Parameters.Add("@Id", MySqlDbType.Int32);

                        command.Parameters["@Surname"].Value = surnameTextBox.Text;
                        command.Parameters["@Name"].Value = nameTextBox.Text;
                        command.Parameters["@Patronymic"].Value = patronymicTextBox.Text;
                        command.Parameters["@Passport"].Value = passportTextBox.Text;
                        command.Parameters["@Phone"].Value = phoneTextBox.Text;
                        command.Parameters["@Id"].Value = _selectedClientId;

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
                EditClientForm_Load(null, null);
            }
        }
    }
}
