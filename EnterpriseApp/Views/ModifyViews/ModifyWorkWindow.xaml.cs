using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EnterpriseApp.Repositories;
using EnterpriseApp.Model;

namespace EnterpriseApp.Views.ModifyViews
{
    /// <summary>
    /// Interaction logic for ModifyWorkWindow.xaml
    /// </summary>
    public partial class ModifyWorkWindow : Window
    {
        IUserRepository userRepository = new UserRepository();
        IWorkRepository workRepository = new WorkRepository();

        public ModifyWorkWindow()
        {
            InitializeComponent();
            Load();
        }

        private void SaveWork_Click(object sender, RoutedEventArgs e)
        {
            if (NewName.Text != "" & NewContent.Text!="")
            {
                workRepository.ModifyWorkByWorkId(SelectedWorkId.SelectedItem.ToString(), NewName.Text, NewContent.Text);
                MessageBox.Show("Work modified correclty", "Changed");
            }
            else
            {
                MessageBox.Show("There is at least one box empty, fill it ", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

        }

        private void Load()
        {
            SelectedUserId.ItemsSource = userRepository.GetUsersId();
        }

        private void SelectedUserId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedWorkId.ItemsSource = workRepository.GetWorksIdByUserId(SelectedUserId.SelectedItem.ToString());
        }

        private void SelectedWorkId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContext = workRepository.GetWorkByWorkId(SelectedWorkId.SelectedItem.ToString());
        }
    }
}
