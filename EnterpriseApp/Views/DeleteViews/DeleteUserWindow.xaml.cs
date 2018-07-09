using System;
using System.Windows;
using EnterpriseApp.Repositories;

namespace EnterpriseApp.Views.DeleteViews
{
    /// <summary>
    /// Interaction logic for DeleteUserWindow.xaml
    /// </summary>
    public partial class DeleteUserWindow : Window
    {
        IUserRepository userRepository = new UserRepository();

        public DeleteUserWindow()
        {
            InitializeComponent();
            Load();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                userRepository.DelteUser(UserToDelete.SelectedItem.ToString());

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There is no UserId selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
        
        private void Load()
        {
            UserToDelete.ItemsSource = userRepository.GetUsersId();
        }
    }
}
