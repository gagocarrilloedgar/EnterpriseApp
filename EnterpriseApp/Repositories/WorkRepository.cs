using EnterpriseApp.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EnterpriseApp.Repositories
{
    public class WorkRepository : IWorkRepository
    {
        DataBaseContext _db = new DataBaseContext();
        public static DataGrid dataGrid;

        public void AddWork(string NewName, string NewContent, int UserIdToFind)
        {
            try
            {
                var SelectedWork = (from work in _db.Works where work.UserId == UserIdToFind select work).First();
                SelectedWork.Content = NewContent;
                SelectedWork.Name = NewName;

                SelectedWork.Tasks = new List<Task>
                {
                    new Task(),

                };

                _db.Works.Add(SelectedWork);
                _db.SaveChanges();

                MessageBox.Show("Your new your has been created correctly", "Saved", MessageBoxButton.OK);
            }
            catch (InvalidOperationException)
            {

                MessageBox.Show("Invalid UserId try again", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        public void DeleteWork(string WorkToDelete)
        {
            try
            {
                try
                {
                    int _workToDelte = Int32.Parse(WorkToDelete);

                    var DeleteThisWork = (from work in _db.Works where work.WorkId == _workToDelte select work).First();

                    _db.Works.Remove(DeleteThisWork);

                    var DeleteTask = from task in _db.Tasks where task.WorkId == _workToDelte select task;

                    foreach (var task in DeleteTask)
                    {
                        _db.Tasks.Remove(task);
                    }

                    _db.SaveChanges();

                    MessageBox.Show("Te work selected has been deleted correctly", "Deleted", MessageBoxButton.OK);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("There is no WorkId selected", "Warning", MessageBoxButton.OK,MessageBoxImage.Warning);
                }

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid WorkId try again", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }

        public void Guardar()
        {
            _db.SaveChanges();
        }

        public List<Work> GetWorks()
        {
            return _db.Works.ToList();
        }

        public List<int> GetWorksId()
        {
            List<int> IdList = new List<int>();
            try
            {
                var WorksIdList = (from work in _db.Works where work.WorkId != 0 select work.WorkId).ToList();
                IdList = WorksIdList;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Unable to find the Work", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return IdList;
        }

        public void PurgeWorks()
        {
            var WorksToPurge = from work in _db.Works where work.WorkId != 0 select work;

            foreach (var work in WorksToPurge)
            {
                _db.Works.Remove(work);
            }

            _db.SaveChanges();
        }

        public List<int> GetWorksIdByUserId(string v)
        {
            int userId = Int32.Parse(v);

            var WorksOfAUserId = (from work in _db.Works where work.UserId == userId select work.WorkId).ToList();

            return WorksOfAUserId;
        }

        public Work GetWorkByWorkId(string v)
        {
            var WorkId = Int32.Parse(v);

            var WorkToSelect = (from work in _db.Works where work.WorkId == WorkId select work).First();

            return WorkToSelect;
        }

        public void ModifyWorkByWorkId(string v,string NewName,string NewContent)
        {
            var WorkId = Int32.Parse(v);

            var WorkToModify = (from work in _db.Works where work.WorkId == WorkId select work).First();

            WorkToModify.Name = NewName;
            WorkToModify.Content = NewContent;

            _db.SaveChanges();
        }
    }
}
