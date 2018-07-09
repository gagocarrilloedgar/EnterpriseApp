using System.Windows;
using EnterpriseApp.Repositories;

namespace EnterpriseApp.Views
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        IUserRepository userRepository = new UserRepository();

        public AddUser()
        {
            InitializeComponent();

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if (NewName.Text!="" && NewSurname.Text!="" && NewAge.Text!="")
            {
                userRepository.AddUser(NewName.Text, NewSurname.Text, NewAge.Text);
                MessageBox.Show("User has been created correctly");
                
            }
            else
            {
                MessageBox.Show("There is empty at least one empty box, fill it", "Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            
        }
    }
}
