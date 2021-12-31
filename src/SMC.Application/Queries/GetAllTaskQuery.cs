using System.Collections.Generic;
using MediatR;

namespace SMC.Application.Queries
{
    public class GetAllTaskQuery : IRequest<List<Core.Entities.Task>>
    {
    }
}