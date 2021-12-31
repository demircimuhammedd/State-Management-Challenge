using System.Collections.Generic;
using System.Threading.Tasks;
using SMC.Core.Repositories.Base;

namespace SMC.Core.Repositories
{
    public interface ITaskRepository : IRepository<Entities.Task>
    {
        Task<IEnumerable<SMC.Core.Entities.Task>> GetTaskByName(string name);
    }
}