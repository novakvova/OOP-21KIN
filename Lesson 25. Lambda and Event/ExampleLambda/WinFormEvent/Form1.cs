namespace WinFormEvent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void MyButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("Привіт");
        }
    }
}
