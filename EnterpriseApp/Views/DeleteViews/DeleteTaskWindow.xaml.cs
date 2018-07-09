using System.Windows;
using EnterpriseApp.Repositories;
using EnterpriseApp.Model;

namespace EnterpriseApp.Views.DeleteViews
{
    /// <summary>
    /// Interaction logic for DeleteTaskWindow.xaml
    /// </summary>
    public partial class DeleteTaskWindow : Window
    {
        ITaskRepository taskRepository = new TaskRepository();
        
        public DeleteTaskWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                taskRepository.DeleteTask(TaskToDelete.SelectedItem.ToString());
            }
            catch (System.Exception)
            {
                MessageBox.Show("There is no WorkId selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

        }

        private void Load()
        {
            TaskToDelete.ItemsSource = taskRepository.GetTasksId();
        }
    }
}
