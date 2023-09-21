using DevFreela.Application.Queries.Outputs;
using MediatR;

namespace DevFreela.Application.Queries.GetProjectsById
{
    public class GetProjectByIdQuery : IRequest<ProjectDetailsViewModel>
    {
        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
