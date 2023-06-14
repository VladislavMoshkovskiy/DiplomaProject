using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public partial class CarsTableForm : Form
    {
        public CarsTableForm()
        {
            InitializeComponent();
        }

        private const string CarsQuery = "SELECT cars.Car_Id AS @Id, cars.Brand AS @Brand, cars.Model AS @Model, " + 
                                         "cars.Reg_Number AS @RegNumber, cars.Color AS @Color, cars.Engine_Capacity AS @EngineCapacity, " +
                                         "cars.Fuel_Type AS @FuelType FROM carservice.cars";

        private string _selectedCarId;

        public string SelectedCarId { get => _selectedCarId; set => _selectedCarId = value; }

        private void RefreshCars()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
                {
                    MySqlCommand command = new MySqlCommand(CarsQuery, connection);

                    command.Parameters.Add("@Id", MySqlDbType.VarChar);
                    command.Parameters.Add("@Brand", MySqlDbType.VarChar);
                    command.Parameters.Add("@Model", MySqlDbType.VarChar);
                    command.Parameters.Add("@RegNumber", MySqlDbType.VarChar);
                    command.Parameters.Add("@Color", MySqlDbType.VarChar);
                    command.Parameters.Add("@EngineCapacity", MySqlDbType.VarChar);
                    command.Parameters.Add("@FuelType", MySqlDbType.VarChar);

                    command.Parameters["@Id"].Value = "Код";
                    command.Parameters["@Brand"].Value = "Марка";
                    command.Parameters["@Model"].Value = "Модель";
                    command.Parameters["@RegNumber"].Value = "Держ. номер";
                    command.Parameters["@Color"].Value = "Колір";
                    command.Parameters["@EngineCapacity"].Value = "Об'єм двигуна";
                    command.Parameters["@FuelType"].Value = "Тип пального";

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        bindingSource1.DataSource = dataTable;
                        bindingNavigator1.BindingSource = bindingSource1;
                        carsDataGridView.DataSource = bindingSource1;
                    }
                }

                carsDataGridView.Columns[0].Width = 100;
                carsDataGridView.Columns[1].Width = 230;
                carsDataGridView.Columns[2].Width = 230;
                carsDataGridView.Columns[3].Width = 150;
                carsDataGridView.Columns[4].Width = 150;
                carsDataGridView.Columns[5].Width = 150;
                carsDataGridView.Columns[6].Width = 150;

                carsDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                carsDataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                carsDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                carsDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                carsDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                carsDataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                carsDataGridView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshCars();
            carsDataGridView.Refresh();
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgramForm aboutProgramForm = new AboutProgramForm();
            aboutProgramForm.ShowDialog();
        }

        private void CarsTableForm_Load(object sender, EventArgs e)
        {
            carsDataGridView.EnableHeadersVisualStyles = false;
            RefreshCars();
        }

        private void carsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (carsDataGridView.CurrentRow != null)
                SelectedCarId = carsDataGridView.CurrentRow.Cells[0].Value.ToString();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchCarsQuery = "SELECT cars.Car_Id AS @Id, cars.Brand AS @Brand, cars.Model AS @Model, " +
                                     "cars.Reg_Number AS @RegNumber, cars.Color AS @Color, cars.Engine_Capacity AS @EngineCapacity, " +
                                     $"cars.Fuel_Type AS @FuelType FROM carservice.cars WHERE cars.Brand LIKE '%{searchTextBox.Text}%' " +
                                     $"OR cars.Model LIKE '%{searchTextBox.Text}%'";

            using (MySqlConnection connection = new MySqlConnection(DBWork.ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(searchCarsQuery, connection);

                command.Parameters.Add("@Id", MySqlDbType.Int32);
                command.Parameters.Add("@Brand", MySqlDbType.VarChar);
                command.Parameters.Add("@Model", MySqlDbType.VarChar);
                command.Parameters.Add("@RegNumber", MySqlDbType.VarChar);
                command.Parameters.Add("@Color", MySqlDbType.VarChar);
                command.Parameters.Add("@EngineCapacity", MySqlDbType.VarChar);
                command.Parameters.Add("@FuelType", MySqlDbType.VarChar);

                command.Parameters["@Id"].Value = "Код";
                command.Parameters["@Brand"].Value = "Марка";
                command.Parameters["@Model"].Value = "Модель";
                command.Parameters["@RegNumber"].Value = "Держ. номер";
                command.Parameters["@Color"].Value = "Колір";
                command.Parameters["@EngineCapacity"].Value = "Об'єм двигуна";
                command.Parameters["@FuelType"].Value = "Тип пального";

                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    bindingSource1.DataSource = dataTable;
                    carsDataGridView.DataSource = bindingSource1;
                }
            }
        }

        private void addRecordButton_Click(object sender, EventArgs e)
        {
            AddCarForm addCarForm = new AddCarForm();
            addCarForm.ShowDialog();
        }

        private void додатиЗаписToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addRecordButton_Click(null, null);
        }
    }
}
