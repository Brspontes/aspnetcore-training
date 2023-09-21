using DevFreela.Application.Queries.Outputs;
using MediatR;
using System.Collections.Generic;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<List<ProjectViewModel>>
    {
        public string Query { get; set; }
    }
}
