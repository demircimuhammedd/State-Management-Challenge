using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SMC.Application.Commands;
using SMC.Application.Mapper;
using SMC.Application.Responses;
using SMC.Core.Repositories;
using Task = SMC.Core.Entities.Task;

namespace SMC.Application.Handlers.CommandHandlers
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, TaskResponse>
    {
        private readonly ITaskRepository _taskRepository;

        public CreateTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            Task entity = TaskMapper.Mapper.Map<Task>(request);

            if (entity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            Task newTask = await _taskRepository.AddAsync(entity);
            return TaskMapper.Mapper.Map<TaskResponse>(newTask);
        }
    }
}