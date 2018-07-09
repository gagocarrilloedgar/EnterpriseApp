using EnterpriseApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using EnterpriseApp.Repositories;

namespace EnterpriseApp.Repositories
{
    class UserRepository : IUserRepository
    {
        DataBaseContext _db = new DataBaseContext();

        public void AddUser(string name, string surname, string age)
        {
            int ageInt = -1;
            if (int.TryParse(age, out ageInt))
            {
                var user = new User
                {
                    Name = name,
                    Surname = surname,
                    Age = ageInt,
                    Works = new List<Work>
                    {
                        new Work(),
                    }

                };

                _db.Users.Add(user);
                _db.SaveChanges();
            }
            else { }
        }

        public void DelteUser(string UserToDelete)
        {
            try
            {
                try
                {
                    int _userToDelete = Int32.Parse(UserToDelete);

                    var DeleteThisUser = (from user in _db.Users where user.UserId == _userToDelete select user).First();

                    _db.Users.Remove(DeleteThisUser);

                    var DeleteWorks = from work in _db.Works where work.UserId == _userToDelete select work;

                    foreach (var work in DeleteWorks)
                    {
                        _db.Works.Remove(work);

                    }

                    var DeleteWorksId = from work in _db.Works where work.UserId == _userToDelete select work.UserId;

                    foreach (var workid in DeleteWorksId)
                    {
                        var DeleteTask = from task in _db.Tasks where task.WorkId == workid select task;

                        foreach (var task in DeleteTask)
                        {
                            _db.Tasks.Remove(task);
                        }
                    }

                    _db.SaveChanges();

                    MessageBox.Show("The User has been correctly deleted", "Deleted", MessageBoxButton.OK);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("There is no user selected ", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);


                }

            }
            catch (InvalidOperationException)
            {

                MessageBox.Show("Unable to find the User or there is ", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        public List<int> GetUsersId()
        {
            List<int> IdList = new List<int>();
            var UsersIdList = (from userid in _db.Users where userid.UserId != 0 select userid.UserId).ToList();

            return UsersIdList;

        }

        public void Guardar()
        {
            _db.SaveChanges();
            MessageBox.Show("Data was saved Correctly");
        }

        public List<User> GetUser()
        {
            return _db.Users.ToList();
        }

        public void PurgeUsers()
        {
            try
            {
                var UsersToPurge = from user in _db.Users where user.UserId != 0 select user;

                foreach (var user in UsersToPurge)
                {
                    _db.Users.Remove(user);
                }
                _db.SaveChanges();
            }
            catch (InvalidOperationException)
            {

                MessageBox.Show("Unable to find the User", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        public User GetUserByUserId(string v)
        {
            int SelectedUserId = Int32.Parse(v);

            var SelectedUser = (from user in _db.Users where user.UserId == SelectedUserId select user).First();

            return SelectedUser;

        }

        public void ModifyUserByUserId(string v,string NewName,string NewSurname,string NewAge)
        {
            var UserId = Int32.Parse(v);

            var UserToModify = (from user in _db.Users where user.UserId == UserId select user).First();

            UserToModify.Name = NewName;
            UserToModify.Surname = NewSurname;
            UserToModify.Age = Int32.Parse(NewAge);

            _db.SaveChanges();
        }
    }
}