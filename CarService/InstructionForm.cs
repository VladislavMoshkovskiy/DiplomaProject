using System.Windows.Forms;

namespace CarService
{
    public partial class InstructionForm : Form
    {
        public InstructionForm()
        {
            InitializeComponent();
        }

        private void InstructionForm_Load(object sender, System.EventArgs e)
        {
            string filename = "";
            webBrowser1.Navigate(filename);
        }
    }
}
