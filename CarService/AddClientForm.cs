using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public partial class AddClientForm : Form
    {
        public AddClientForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private const string Query = "INSERT INTO carservice.clients (Surname, Name, Patronymic, Passport, Phone) " + 
                                     "VALUES (@Surname, @Name, @Patronymic, @Passport, @Phone)";

        private void addClientButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(Query, connection);

                    command.Parameters.Add("@Surname", MySqlDbType.VarChar);
                    command.Parameters.Add("@Name", MySqlDbType.VarChar);
                    command.Parameters.Add("@Patronymic", MySqlDbType.VarChar);
                    command.Parameters.Add("@Passport", MySqlDbType.VarChar);
                    command.Parameters.Add("@Phone", MySqlDbType.VarChar);

                    command.Parameters["@Surname"].Value = surnameTextBox.Text;
                    command.Parameters["@Name"].Value = nameTextBox.Text;
                    command.Parameters["@Patronymic"].Value = patronymicTextBox.Text;
                    command.Parameters["@Passport"].Value = passportTextBox.Text;
                    command.Parameters["@Phone"].Value = phoneTextBox.Text;

                    command.ExecuteNonQuery();

                    connection.Close();

                    MessageBox.Show("Запис додано успішно", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    surnameTextBox.Text = string.Empty;
                    nameTextBox.Text = string.Empty;
                    patronymicTextBox.Text = string.Empty;
                    passportTextBox.Text = string.Empty;
                    phoneTextBox.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
