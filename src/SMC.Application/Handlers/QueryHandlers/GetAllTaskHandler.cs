using System.Collections.Generic;
using System.Threading;
using MediatR;
using SMC.Application.Queries;
using SMC.Core.Entities;
using SMC.Core.Repositories;

namespace SMC.Application.Handlers.QueryHandlers
{
    public class GetAllTaskHandler : IRequestHandler<GetAllTaskQuery, List<Task>>
    {
        private readonly ITaskRepository _taskRepository;

        public GetAllTaskHandler(ITaskRepository taskRepository) => _taskRepository = taskRepository;

        public async System.Threading.Tasks.Task<List<Task>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken) =>
            (List<Task>)await _taskRepository.GetAllAsync();
    }
}