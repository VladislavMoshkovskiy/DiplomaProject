using System;
using System.Windows.Forms;

namespace CarService
{
    public partial class ServiceMenuForm : Form
    {
        public ServiceMenuForm()
        {
            InitializeComponent();
        }

        private void analiticsButton_Click(object sender, EventArgs e)
        {
            StatisticsForm statisticsForm = new StatisticsForm();
            statisticsForm.ShowDialog();
        }

        private void ordersControlButton_Click(object sender, EventArgs e)
        {
            OrdersControlForm ordersControlForm = new OrdersControlForm();
            ordersControlForm.ShowDialog();
        }

        private void worksButton_Click(object sender, EventArgs e)
        {
            WorkersOrdersForm workersOrdersForm = new WorkersOrdersForm();
            workersOrdersForm.ShowDialog();
        }

        private void priceListButton_Click(object sender, EventArgs e)
        {
            PriceListForm priceListForm = new PriceListForm();
            priceListForm.ShowDialog();
        }
    }
}
