using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExampleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Digital_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var textBlock = (TextBlock)button.Content;
            string value = textBlock.Text;   // "0"
            //MessageBox.Show("Click button - " + value);
            if (txtResult.Text == "0")
            {
                txtResult.Text = value;
            }
            else
            {
                txtResult.Text += value;
            }
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "0";
        }

        private void Button_Backspace_Click(object sender, RoutedEventArgs e)
        {
            int len = txtResult.Text.Length;
            if(len!=0)
            {
                string str = txtResult.Text.Substring(0, len - 1);
                txtResult.Text = str;
            }
        }
    }
}