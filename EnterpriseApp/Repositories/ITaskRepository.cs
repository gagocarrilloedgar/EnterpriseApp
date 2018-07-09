using System.Collections;
using System.Collections.Generic;
using System.Windows.Controls;
using EnterpriseApp.Model;

namespace EnterpriseApp.Repositories
{
    public interface ITaskRepository
    {
        void AddTask(string NewName, string NewDescription, int WorkId,string NewProgres);

        void DeleteTask(string DeleteTaskId);

        void PurgeTasks();

        void Guardar();

        List<Task> GetTasks();

        List<int> GetTasksId();

        List<int> GetTasksIdByUserId(string v);
    }
}
