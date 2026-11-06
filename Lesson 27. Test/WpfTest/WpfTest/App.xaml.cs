using System.Windows;

namespace WpfTest;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        MyDataContext fileData = new MyDataContext();
        fileData.Database.EnsureCreated();

        MainWindow window = new MainWindow();
        window.Show();
    }
}
