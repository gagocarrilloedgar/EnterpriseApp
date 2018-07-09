using EnterpriseApp.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EnterpriseApp.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        DataBaseContext db = new DataBaseContext();

        public void AddTask(string NewName, string NewDescription, int WorkId, string NewProgres)
        {
            try
            {
                var SelectedTask = (from task in db.Tasks where task.WorkId == WorkId select task).First();
                SelectedTask.Name = NewName;
                SelectedTask.Description = NewDescription;

                db.Tasks.Add(SelectedTask);
                db.SaveChanges();

                MessageBox.Show("Your new Task has been created correctly", "Saved", MessageBoxButton.OK);

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid WorkId try again", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

        }

        public void DeleteTask(string DeleteTaskId)
        {
            try
            {
                try
                {
                    var deleteTaskId = Int32.Parse(DeleteTaskId);

                    var TaskToDelte = (from task in db.Tasks where task.TaskId == deleteTaskId select task).First();
                    db.Tasks.Remove(TaskToDelte);
                    db.SaveChanges();

                    MessageBox.Show("The task selected has been correctly deleted ", "Deleted", MessageBoxButton.OK);
                }
                catch (NullReferenceException)
                {

                    MessageBox.Show("There is no TaskId selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                }

            }
            catch (InvalidOperationException)
            {

                MessageBox.Show("Invalid TaskId", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

        }


        public void Guardar()
        {
            db.SaveChanges();
        }

        public List<Model.Task> GetTasks()
        {
            return db.Tasks.ToList();
        }

        public void PurgeTasks()
        {
            try
            {
                var TasksToPurge = from task in db.Tasks where task.WorkId != 0 select task;

                foreach (var task in TasksToPurge)
                {
                    db.Tasks.Remove(task);
                }
                db.SaveChanges();
            }
            catch (InvalidOperationException)
            {

                MessageBox.Show("Unable to find the Task", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        public List<int> GetTasksId()
        {
            var TasksIdList = (from task in db.Tasks select task.TaskId).ToList();

            return TasksIdList;
        }

        public List<int> GetTasksIdByUserId(string v)
        {
            int workId = Int32.Parse(v);

            var TasksOfAUserId = from task in db.Tasks where task.WorkId == workId select task.WorkId;

            return TasksOfAUserId.ToList();
        }
    }
}
