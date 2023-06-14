using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CarService
{
    public static class DBWork
    {
        public const string ConnectionString = "Server=localhost;" +
                                               "Port=3306;" + 
                                               "Username=root;" + 
                                               "Password=root;" + 
                                               "Database=carservice";

        public static DataTable GetDataTableFromSqlQuery(string query)
        {
            DataTable dataTable;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection))
                    {
                        dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                    }
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;              
            }
        }
    }
}
