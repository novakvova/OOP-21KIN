using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfMyGallery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly string[] Extensions =
            { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFolderDialog();

            if (dialog.ShowDialog() != true)
                return;

            string folder = dialog.FolderName;
            PathText.Text = folder;

            //Повертаємо усі файли із папки, які є фото
            var files = Directory.GetFiles(folder)
                .Where(f => Extensions.Contains(Path.GetExtension(f).ToLower()));

            var images = new List<BitmapImage>();
            foreach(var file in files)
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(file);
                bitmap.DecodePixelWidth = 300; //економія пам'яті
                bitmap.CacheOption = BitmapCacheOption.OnLoad; //Щоб не блокувати фото
                bitmap.EndInit();
                images.Add(bitmap);
            }
            GalleryList.ItemsSource = images;
        }
    }
}