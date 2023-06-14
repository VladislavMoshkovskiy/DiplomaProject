using System.Windows.Forms;

namespace CarService
{
    public partial class ManagerMenuForm : Form
    {
        public ManagerMenuForm()
        {
            InitializeComponent();
        }

        private void ManagerMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Доступ до модуля робота з клієнтами
        private void clientsFormButton_Click(object sender, System.EventArgs e)
        {
            ClientsMenuForm clientsMenuForm = new ClientsMenuForm();
            clientsMenuForm.ShowDialog();
        }

        //Доступ до довідника складу
        private void storageFormButton_Click(object sender, System.EventArgs e)
        {
            StorageTableForm storageTableForm = new StorageTableForm();
            storageTableForm.ShowDialog();
        }

        //Доступ до модуля сервісу
        private void serviceFormButton_Click(object sender, System.EventArgs e)
        {
            ServiceMenuForm serviceMenuForm = new ServiceMenuForm();
            serviceMenuForm.ShowDialog();
        }

        //Доступ до модуля роботи з кадрами
        private void workersFormButton_Click(object sender, System.EventArgs e)
        {
            WorkersTableForm workersTableForm = new WorkersTableForm();
            workersTableForm.ShowDialog();
        }
    }
}
