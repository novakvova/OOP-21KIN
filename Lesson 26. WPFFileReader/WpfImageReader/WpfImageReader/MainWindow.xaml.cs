using System.IO;
using System.Net.Http;
using System.Windows;

namespace WpfImageReader;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnDownload_Click(object sender, RoutedEventArgs e)
    {
        string imageUrl = txtUrl.Text; //"https://src.zakaz.atbmarket.com/prodwebp/catalog_product_gal/i33/catalog_product_gal_101973.webp";
        string dir = "images";
        Directory.CreateDirectory(dir);
        try
        {
            HttpClient client = new HttpClient();
            var buffer = client.GetByteArrayAsync(imageUrl).Result;
            string fileName = Guid.NewGuid().ToString()+".jpg";
            var imageSave = Path.Combine(dir, fileName);
            File.WriteAllBytes(imageSave, buffer);
            MessageBox.Show("Файл успішно збережено! "+ imageSave);
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}