using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseApp.Model;
using EnterpriseApp.Repositories;

namespace EnterpriseApp.MockingRepositories
{
    public class WorkRepositoryMock : IWorkRepositoryMock
    {

        private List<Work> UserList = new List<Work>
        {
            new Work{Name="Work 1",Content="Content 1 of User 1", UserId=1, Tasks = new List<Model.Task> {new Model.Task()}},
            new Work{Name="Work 2",Content="Content 2 of User 1", UserId=1, Tasks = new List<Model.Task> {new Model.Task()}},
            new Work{Name="Work 1",Content="Content 1 of User 2", UserId=2, Tasks = new List<Model.Task> {new Model.Task()}},
            new Work{Name="Work 2",Content="Content 2 of User 2", UserId=2, Tasks = new List<Model.Task> {new Model.Task()}},
            new Work{Name="Work 1",Content="Content 1 of User 3", UserId=3, Tasks = new List<Model.Task> {new Model.Task()}},
            new Work{Name="Work 2",Content="Content 2 of User 3", UserId=3, Tasks = new List<Model.Task> {new Model.Task()}},
            new Work{Name="Work 1",Content="Content 1 of User 4", UserId=4, Tasks = new List<Model.Task> {new Model.Task()}},
            new Work{Name="Work 2",Content="Content 2 of User 4", UserId=4, Tasks = new List<Model.Task> {new Model.Task()}},

        };
        

        public IEnumerable<Work> GetWorks()
        {
            return UserList;
        }
    }
}
