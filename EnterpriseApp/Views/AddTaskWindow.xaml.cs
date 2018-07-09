using EnterpriseApp.Model;
using System.Windows;
using EnterpriseApp.Repositories;
using System;

namespace EnterpriseApp.Views
{
    /// <summary>
    /// Interaction logic for AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : Window
    {
        ITaskRepository taskRepository = new TaskRepository();
        IWorkRepository workRepository = new WorkRepository();

        public AddTaskWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (NewName.Text!="" & NewDescription.Text!="" & NewProgres.Text!="")
            {
                taskRepository.AddTask(NewName.Text, NewDescription.Text, Int32.Parse(WorkId.SelectedItem.ToString()), NewProgres.Text);
                MessageBox.Show("The task has been added correctly","Saved");
            }
            else
            {
                MessageBox.Show("There is empty at least one empty box, fill it", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void Load()
        {
            WorkId.ItemsSource = workRepository.GetWorksId();

        }
    }
}
