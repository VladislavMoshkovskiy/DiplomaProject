using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public partial class AddCarForm : Form
    {
        public AddCarForm()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private const string Query = "INSERT INTO carservice.cars (Brand, Model, Reg_Number, Color, Engine_Capacity, Fuel_Type) " +
                                        "VALUES (@Brand, @Model, @RegNumber, @Color, @EngineCapacity, @FuelType)";

        private void addClientButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(Query, connection);

                    command.Parameters.Add("@Brand", MySqlDbType.VarChar);
                    command.Parameters.Add("@Model", MySqlDbType.VarChar);
                    command.Parameters.Add("@RegNumber", MySqlDbType.VarChar);
                    command.Parameters.Add("@Color", MySqlDbType.VarChar);
                    command.Parameters.Add("@EngineCapacity", MySqlDbType.VarChar);
                    command.Parameters.Add("@FuelType", MySqlDbType.VarChar);

                    command.Parameters["@Brand"].Value = brandTextBox.Text;
                    command.Parameters["@Model"].Value = modelTextBox.Text;
                    command.Parameters["@RegNumber"].Value = regNumberTextBox.Text;
                    command.Parameters["@Color"].Value = colorTextBox.Text;
                    command.Parameters["@EngineCapacity"].Value = engineCapacityTextBox.Text;
                    command.Parameters["@FuelType"].Value = fuelTypeTextBox.Text;

                    command.ExecuteNonQuery();

                    connection.Close();

                    MessageBox.Show("Запис додано успішно", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    brandTextBox.Text = string.Empty;
                    modelTextBox.Text = string.Empty;
                    regNumberTextBox.Text = string.Empty;
                    colorTextBox.Text = string.Empty;
                    engineCapacityTextBox.Text = string.Empty;
                    fuelTypeTextBox.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
