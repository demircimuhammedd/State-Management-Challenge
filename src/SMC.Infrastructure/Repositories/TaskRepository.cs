using System.Collections.Generic;
using SMC.Core.Entities;
using SMC.Core.Repositories;
using SMC.Infrastructure.Data;
using SMC.Infrastructure.Repositories.Base;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SMC.Infrastructure.Repositories
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public TaskRepository(SMCContext dbContext) : base(dbContext)
        {
        }

        public async System.Threading.Tasks.Task<IEnumerable<Task>> GetTaskByName(string name) => await _dbContext.Tasks.Where(m => m.Name == name).ToListAsync();
    }
}