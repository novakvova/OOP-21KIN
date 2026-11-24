using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfThreadExample
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

        private static readonly string[] Extensions =
            { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFolderDialog();

            if (dialog.ShowDialog() != true)
                return;

            string folder = dialog.FolderName;
            PathText.Text = folder;

            Thread thread = new Thread(MyUploadImagesFolder);
            thread.Start(folder);

        }

        //Код будемо виконувати в окремому потоці
        private void MyUploadImagesFolder(object inObject)
        {
            string folder = (string)inObject; //unboxing - Розпокувати object
            //Повертаємо усі файли із папки, які є фото
            var files = Directory.GetFiles(folder)
                .Where(f => Extensions.Contains(Path.GetExtension(f).ToLower()));

            var images = new List<BitmapImage>();
            foreach (var file in files)
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(file);
                bitmap.DecodePixelWidth = 300; //економія пам'яті
                bitmap.CacheOption = BitmapCacheOption.OnLoad; //Щоб не блокувати фото
                bitmap.EndInit();
                bitmap.Freeze(); // Для того, щоб працювало між потоками :), був доступний для UI
                images.Add(bitmap);
            }
            //Із робочого потоку можна оновляти інтерфейс
            Dispatcher.Invoke(() =>
            {
                GalleryList.ItemsSource = images;
            });
            
        }
    }
}