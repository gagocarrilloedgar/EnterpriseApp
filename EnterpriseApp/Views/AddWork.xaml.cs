using System;
using System.Collections.Generic;
using System.Windows;
using EnterpriseApp.Model;
using EnterpriseApp.Repositories;

namespace EnterpriseApp.Views
{
    /// <summary>
    /// Interaction logic for AddWork.xaml
    /// </summary>
    public partial class AddWork : Window
    {
        IWorkRepository workRepository = new WorkRepository();
        IUserRepository userRepository = new UserRepository();

        public AddWork()
        {
            InitializeComponent();
            Load();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (NewName.Text!="" & NewContent.Text!="")
            {
                workRepository.AddWork(NewName.Text, NewContent.Text, Int32.Parse(UserIdList.SelectedItem.ToString()));
                MessageBox.Show("Work saved correctly","Saved");
            }
            else
            {
                MessageBox.Show("There is empty at least one empty box, fill it", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

        }

        void Load()
        {   
            UserIdList.ItemsSource = userRepository.GetUsersId();
        }

    }
}
