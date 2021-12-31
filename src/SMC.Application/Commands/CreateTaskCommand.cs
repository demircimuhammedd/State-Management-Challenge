using MediatR;
using SMC.Application.Responses;

namespace SMC.Application.Commands
{
    public class CreateTaskCommand : IRequest<TaskResponse>
    {
    }
}