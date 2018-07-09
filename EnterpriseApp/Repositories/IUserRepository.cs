using EnterpriseApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EnterpriseApp.Repositories
{
    public interface IUserRepository
    {
        void AddUser(string name, string surname,string age);

        void DelteUser(string UserToDelete);

        void Guardar();

        List<User> GetUser();

        List<int> GetUsersId();

        void PurgeUsers();

        User GetUserByUserId(string v);

        void ModifyUserByUserId(string v, string NewName, string NewSurname, string NewAge);
    }
}
