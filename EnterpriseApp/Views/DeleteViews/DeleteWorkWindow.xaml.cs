using System;
using System.Windows;
using EnterpriseApp.Repositories;

namespace EnterpriseApp.Views.DeleteViews
{
    /// <summary>
    /// Interaction logic for DeleteWorkWindow.xaml
    /// </summary>
    public partial class DeleteWorkWindow : Window
    {
        IWorkRepository workRepository = new WorkRepository();
            
        public DeleteWorkWindow()
        {
            InitializeComponent();
            Load();
        }

        private void DeleteWork_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                workRepository.DeleteWork(WorkToDelete.SelectedItem.ToString());

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There is no WorkId selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Load()
        {
            WorkToDelete.ItemsSource = workRepository.GetWorksId();
        }
    }
}
