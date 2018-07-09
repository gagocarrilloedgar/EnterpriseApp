using System.Windows;
using System.Windows.Controls;
using EnterpriseApp.Model;
using EnterpriseApp.Repositories;
using EnterpriseApp.Views;

namespace EnterpriseApp.Views.ModifyViews
{
    /// <summary>
    /// Interaction logic for ModifyUserWindow.xaml
    /// </summary>
    public partial class ModifyUserWindow : Window
    {
        IUserRepository userRepository = new UserRepository();
        IWorkRepository workRepository = new WorkRepository();
        ITaskRepository taskRepository = new TaskRepository();

        DataBaseContext db = new DataBaseContext();

        public ModifyUserWindow()
        {
            InitializeComponent();
            Load();
        }

        private void ModifyUser_Click(object sender, RoutedEventArgs e)
        {
            if (NewAge.Text!="" & NewName.Text!="" & NewSurname.Text!="")
            {
                userRepository.ModifyUserByUserId(SelectedUserId.SelectedItem.ToString(), NewName.Text, NewSurname.Text, NewAge.Text);
                MessageBox.Show("User changed correctly", "Changed");
            }
            else
            {
                MessageBox.Show("There is at least one box empty, fill it ","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            
        }

        private void SelectedWorkId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedTaskId.ItemsSource = taskRepository.GetTasksIdByUserId(SelectedWorkId.SelectedItem.ToString());
        }

        private void SelectedUserId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedWorkId.ItemsSource = workRepository.GetWorksIdByUserId(SelectedUserId.SelectedItem.ToString());
            DataContext = userRepository.GetUserByUserId(SelectedUserId.SelectedItem.ToString());
        }

        private void Load()
        {
            SelectedUserId.ItemsSource = userRepository.GetUsersId();
            
        }

        private void ModiffyWork_Click(object sender, RoutedEventArgs e)
        {
            ModifyWorkWindow modifyWorkWindow = new ModifyWorkWindow();
            modifyWorkWindow.Owner = this;
            modifyWorkWindow.Show();

        }

        private void ModiffyTask_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
