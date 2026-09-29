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

namespace BeginWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Button btn = new Button();
            btn.Width = 100;
            btn.Height = 100;
            btn.FontWeight = FontWeights.Bold;

            WrapPanel pnl = new WrapPanel(); //Робимо панель для контенту
            //btn.Content = "Красотка :)";
            TextBlock txt = new TextBlock();
            txt.Text = "Натисни";
            txt.Padding = new Thickness(10);
            txt.Foreground = Brushes.Blue;
            pnl.Children.Add(txt);

            btn.Content = pnl;

            myGrid.Children.Add(btn);
        }
    }
}