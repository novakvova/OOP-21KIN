using System.Diagnostics.Eventing.Reader;
using System.Windows.Media.Imaging;

namespace WpfImageReader;

public class ImageItem
{
    public BitmapImage Image { get; set; } = null!;
    public string FileName { get; set; } = null!;
    public long FileSize { get; set; }
    public DateTime DateCreated { get; set; }
}
