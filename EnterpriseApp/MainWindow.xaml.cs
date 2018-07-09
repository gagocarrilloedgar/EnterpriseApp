using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EnterpriseApp.Model;
using EnterpriseApp.Repositories;
using EnterpriseApp.Views;
using EnterpriseApp.Views.DeleteViews;
using EnterpriseApp.Views.ModifyViews;

namespace EnterpriseApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IUserRepository userRepo = new UserRepository();
        IWorkRepository workRepo = new WorkRepository();
        ITaskRepository taskRepo = new TaskRepository();

        DataBaseContext _db = new DataBaseContext();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUser viewUserWindow = new AddUser();
            viewUserWindow.Owner = this;
            viewUserWindow.Show();

        }

        private void AddWork_Click(object sender, RoutedEventArgs e)
        {
            AddWork viewWorWindow = new AddWork();
            viewWorWindow.Owner = this;
            viewWorWindow.Show();

        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow addTaskWindow = new AddTaskWindow();
            addTaskWindow.Owner = this;
            addTaskWindow.Show();
        }

        private void ChangeUser_Click(object sender, RoutedEventArgs e)
        {
            ModifyUserWindow modifyUserWindow = new ModifyUserWindow();
            modifyUserWindow.Owner = this;
            modifyUserWindow.Show();
        }

        private void ChangeWork_Click(object sender, RoutedEventArgs e)
        {
            ModifyWorkWindow modifyWorkWindow = new ModifyWorkWindow();
            modifyWorkWindow.Owner = this;
            modifyWorkWindow.Show();
        }

        private void ChangeTask_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            DeleteUserWindow deleteUserWindow = new DeleteUserWindow();
            deleteUserWindow.Owner = this;
            deleteUserWindow.Show();
        }

        private void DeleteWork_Click(object sender, RoutedEventArgs e)
        {
            DeleteWorkWindow deleteWorkWindow = new DeleteWorkWindow();
            deleteWorkWindow.Owner = this;
            deleteWorkWindow.Show();
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            DeleteTaskWindow deleteTaskWindow = new DeleteTaskWindow();
            deleteTaskWindow.Owner = this;
            deleteTaskWindow.Show();

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            userRepo.Guardar();
            workRepo.Guardar();
        }

        private void ViewWork_Click(object sender, RoutedEventArgs e)
        {
            List<Work> works = workRepo.GetWorks();
            myDataGrid.ItemsSource = works;
        }

        private void ViewTask_Click(object sender, RoutedEventArgs e)
        {
            List<Task> tasks = taskRepo.GetTasks();
            myDataGrid.ItemsSource = tasks;

        }

        private void ViewUser_Click(object sender, RoutedEventArgs e)
        {
            List<User> users = userRepo.GetUser();
            myDataGrid.ItemsSource = users;
        }

        private void PurgeDB_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you really want to purge de whole Data Base?", "Warning", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    taskRepo.PurgeTasks();
                    workRepo.PurgeWorks();
                    userRepo.PurgeUsers();
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Oh well, too bad!", "Warning");
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Nevermind then...", "Warning");
                    break;
            }
        }


    }
}
