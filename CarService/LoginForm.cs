using System;
using System.Windows.Forms;

namespace CarService
{
    public partial class LoginForm : Form
    {
        private const string ServiceManagerLogin = "ServiceManager";
        private const string ServiceManagerPassword = "ManagerPassword";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if ((loginTextBox.Text == ServiceManagerLogin) && (passwordTextBox.Text == ServiceManagerPassword))
            {
                this.Hide();
                ManagerMenuForm managerMenuForm = new ManagerMenuForm();
                managerMenuForm.Show();
            }
            else
            {
                MessageBox.Show("Невірно введенні вхідні дані", "Помилка авторизації", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
