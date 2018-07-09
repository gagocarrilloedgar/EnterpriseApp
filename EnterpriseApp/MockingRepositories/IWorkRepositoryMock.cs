using EnterpriseApp.Model;
using System.Collections.Generic;

namespace EnterpriseApp.MockingRepositories
{
    public interface IWorkRepositoryMock
    {
        IEnumerable<Work> GetWorks();

    }
}