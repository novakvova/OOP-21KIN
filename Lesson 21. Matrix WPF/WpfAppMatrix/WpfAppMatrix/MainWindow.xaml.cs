using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppMatrix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Resize(GridA, 3, 3, false);
            Resize(GridB, 3, 3, false);
            Resize(GridC, 3, 3, true);
        }

        /// <summary>
        /// Метод, який малює матрицю, будь-якого розміру
        /// </summary>
        private static void Resize(UniformGrid grid, int rows, int cols, bool readOnly)
        {
            var old = new Dictionary<(int, int), string>();
            if (grid.Columns > 0)
            {
                for (int k = 0; k < grid.Children.Count; k++)
                    old[(k / grid.Columns, k % grid.Columns)] =
                        ((TextBox)grid.Children[k]).Text;
            }
            grid.Children.Clear();
            grid.Rows = rows;
            grid.Columns = cols;

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    var tb = new TextBox
                    {
                        Width = 60,
                        Height = 28,
                        Margin = new Thickness(2),
                        TextAlignment = TextAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        IsReadOnly = readOnly,
                        Text = old.TryGetValue((i, j), out var t) ? t : "0"
                    };
                    var normal = readOnly ? Brushes.WhiteSmoke : Brushes.White;
                    tb.Background = normal;
                    // некоректне число — червоний фон
                    tb.TextChanged += (s, e) => tb.Background = TryParse(tb.Text, out _) ? normal : Brushes.MistyRose;
                    grid.Children.Add(tb);
                }
        }

        private static bool TryParse(string s, out double v)
            => double.TryParse(s.Trim().Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out v)
                && !double.IsNaN(v) && !double.IsInfinity(v);
    
        //метод, який читає значення матриці із input
        private static double[,] Read(UniformGrid grid, string name)
        {
            int rows = grid.Rows, cols = grid.Columns;
            var m = new double[rows, cols];
            for(int i = 0; i<rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var tb = (TextBox)grid.Children[i*cols+j];
                    if (!TryParse(tb.Text, out m[i, j]))
                        throw new InvalidOperationException($"Помилка матриця {name}");
                }
            }
            return m;
        }

        //Для форматування виводу
        private static string Format(double v) => Math.Round(v, 6).ToString("G7", CultureInfo.InvariantCulture);

        //Метод Fill заповняє матрицю значення
        private static void Fill(UniformGrid grid, double[,]m)
        {
            int cols = grid.Columns;
            for(int i=0; i<cols; i++)
                for (int j=0; j<cols; j++)
                    ((TextBox)grid.Children[i*cols+j]).Text = Format(m[i, j]);
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            var a = Read(GridA, "A");
            var b = Read(GridB, "B");
            var result = MatrixMath.Add(a, b);
            Resize(GridC, result.GetLength(0), result.GetLength(1), true);
            Fill(GridC, result); //Має записати суму 2 матриць у C

        }
    }
}