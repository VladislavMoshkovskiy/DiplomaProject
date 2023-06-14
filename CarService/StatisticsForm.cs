using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CarService
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            chart1.Printing.PrintPreview();
        }

        private const string SelectAllOrders = "SELECT orders.Reception_Date, orders.Order_Cost FROM carservice.orders";
        private const string SelectYearOrders = "SELECT orders.Reception_Date, orders.Order_Cost FROM carservice.orders WHERE YEAR(Reception_Date) = YEAR(NOW())";
        private const string SelectMonthOrders = "SELECT orders.Reception_Date, orders.Order_Cost FROM carservice.orders WHERE YEAR(Reception_Date) = YEAR(NOW()) AND MONTH(Reception_Date) = MONTH(NOW())";
        private const string SelectWeekOrders = "SELECT orders.Reception_Date, orders.Order_Cost FROM carservice.orders WHERE YEAR(Reception_Date) = YEAR(NOW()) AND WEEK(Reception_Date) = WEEK(NOW())";

        private DataTable _allOrdersTable;
        private DataTable _yearOrdersTable;
        private DataTable _monthOrdersTable;
        private DataTable _weekOrdersTable;

        private void ChartBuild()
        {
            _allOrdersTable = DBWork.GetDataTableFromSqlQuery(SelectAllOrders);
            _yearOrdersTable = DBWork.GetDataTableFromSqlQuery(SelectYearOrders);
            _monthOrdersTable = DBWork.GetDataTableFromSqlQuery(SelectMonthOrders);
            _weekOrdersTable = DBWork.GetDataTableFromSqlQuery(SelectWeekOrders);

            if (allTimeRadioButton.Checked)
            {
                chart1.Series["Вартість замовлень"].Points.Clear();

                for (int i = 0; i < _allOrdersTable.Rows.Count; i++)
                {
                    DateTime orderDate = Convert.ToDateTime(_allOrdersTable.Rows[i][0]);
                    double orderCost = Convert.ToDouble(_allOrdersTable.Rows[i][1]);
                    chart1.Series["Вартість замовлень"].Points.AddXY(orderDate, orderCost);
                }
            }
            else if (yearRadioButton.Checked)
            {
                chart1.Series["Вартість замовлень"].Points.Clear();

                for (int i = 0; i < _yearOrdersTable.Rows.Count; i++)
                {
                    DateTime orderDate = Convert.ToDateTime(_yearOrdersTable.Rows[i][0]);
                    double orderCost = Convert.ToDouble(_yearOrdersTable.Rows[i][1]);
                    chart1.Series["Вартість замовлень"].Points.AddXY(orderDate, orderCost);
                }
            }
            else if (monthRadioButton.Checked)
            {
                chart1.Series["Вартість замовлень"].Points.Clear();

                for (int i = 0; i < _monthOrdersTable.Rows.Count; i++)
                {
                    DateTime orderDate = Convert.ToDateTime(_monthOrdersTable.Rows[i][0]);
                    double orderCost = Convert.ToDouble(_monthOrdersTable.Rows[i][1]);
                    chart1.Series["Вартість замовлень"].Points.AddXY(orderDate, orderCost);
                }
            }
            else if (weekRadioButton.Checked)
            {
                chart1.Series["Вартість замовлень"].Points.Clear();

                for (int i = 0; i < _weekOrdersTable.Rows.Count; i++)
                {
                    DateTime orderDate = Convert.ToDateTime(_weekOrdersTable.Rows[i][0]);
                    double orderCost = Convert.ToDouble(_weekOrdersTable.Rows[i][1]);
                    chart1.Series["Вартість замовлень"].Points.AddXY(orderDate, orderCost);
                }
            }
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            Title title = new Title("Графік вартості замовлень", Docking.Top, new Font("Roboto", 14, FontStyle.Bold), Color.RoyalBlue);
            chart1.Titles.Add(title);

            ChartBuild();
        }

        private void allTimeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChartBuild();
        }

        private void monthRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChartBuild();
        }
    }
}
