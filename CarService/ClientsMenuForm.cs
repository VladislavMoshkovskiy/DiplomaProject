using System;
using System.Windows.Forms;

namespace CarService
{
    public partial class ClientsMenuForm : Form
    {
        public ClientsMenuForm()
        {
            InitializeComponent();
        }

        private void clientsTableButton_Click(object sender, EventArgs e)
        {
            ClientsTableForm clientsTableForm = new ClientsTableForm();
            clientsTableForm.ShowDialog();
        }

        private void createOrderButton_Click(object sender, EventArgs e)
        {
            CreateOrderForm createOrderForm = new CreateOrderForm();
            createOrderForm.ShowDialog();
        }

        private void ordersTableButton_Click(object sender, EventArgs e)
        {
            OrdersTableForm ordersTableForm = new OrdersTableForm();
            ordersTableForm.ShowDialog();
        }

        private void clientOrderButton_Click(object sender, EventArgs e)
        {
            ClientOrdersForm clientOrdersForm = new ClientOrdersForm();
            clientOrdersForm.ShowDialog();
        }
    }
}
