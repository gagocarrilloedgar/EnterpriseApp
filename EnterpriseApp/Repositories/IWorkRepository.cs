using EnterpriseApp.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EnterpriseApp.Repositories
{
    public interface IWorkRepository
    {
        void AddWork(string NewName, string NewContent, int UserId);

        void DeleteWork(string WorkToDelete);

        void Guardar();

        void PurgeWorks();

        List<Work> GetWorks();

        List<int> GetWorksId();

        List<int> GetWorksIdByUserId(string v);

        Work GetWorkByWorkId(string v);

        void ModifyWorkByWorkId(string v,string NewName,string NewContent);

    }

}
