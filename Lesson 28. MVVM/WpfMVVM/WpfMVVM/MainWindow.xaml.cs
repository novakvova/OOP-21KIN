using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using WpfMVVM.Models;

namespace WpfMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<UserVM> users = new();
        public MainWindow()
        {
            InitializeComponent();
            dgvUsers.ItemsSource = users; //Привязали користувачів до DateGrid
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            UserVM newUser = new UserVM();
            newUser.Id = users.Count + 1;
            newUser.Name = "Хороший козак " + newUser.Id;
            newUser.Phone = "+38(098) 224 83 05";
            newUser.Image = "https://i.pravatar.cc/1200";

            users.Add(newUser);
        }
    }
}