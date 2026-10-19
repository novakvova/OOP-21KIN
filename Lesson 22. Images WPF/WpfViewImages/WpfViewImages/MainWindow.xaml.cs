using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace WpfViewImages
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

        private void Border_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[]) e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    LoadImage(files[0]);
                }
            }
        }
        //Потрібно завантажити фото у вікно, щоб воно
        //було лише в пам'яті - Щоб фото не було заблокованим
        private void LoadImage(string path)
        {
            try
            {
                //bitmap - для роботи з фото
                var bitmap = new BitmapImage();
                bitmap.BeginInit(); 
                bitmap.UriSource = new Uri(path, UriKind.Absolute);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                bitmap.EndInit();
                bitmap.Freeze(); //у нашому bitmap - фото - path
                imgPreview.Source = bitmap;
                var sizeKb = new FileInfo(path).Length / 1024.0;
                txtInfo.Text = $"{Path.GetFileName(path)} — {bitmap.PixelWidth}×{bitmap.PixelHeight} px, {sizeKb:F1} КБ";

            }
            catch(Exception ex)
            {
                MessageBox.Show($"Не вдалося завантажити фото: \n{ex.Message}",
                    "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Виберіть зображення",
                Filter = "Зображення|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tif;*.tiff|Усі файли|*.*",
                CheckFileExists = true,
            };
            if (dialog.ShowDialog() == true)
            {
                LoadImage(dialog.FileName);
            }
        }
    }
}