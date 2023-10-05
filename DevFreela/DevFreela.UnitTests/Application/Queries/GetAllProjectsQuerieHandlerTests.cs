using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsQuerieHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExists_Execute_ReturnThreeProjectViewModels()
        {
            var projects = new List<Project>
            {
                new Project("Nome", "Descricao", 2, 1, 1000),
                new Project("Nome", "Descricao", 2, 1, 2000),
                new Project("Nome", "Descricao", 2, 1, 3000)
            };

            var projectRepository = new Mock<IProjectRepository>();
            projectRepository.Setup(p => p.GetAllAsync().Result).Returns(projects);

            var query = new GetAllProjectsQuery("");
            var handler = new GetAllProjectsQueryHandler(projectRepository.Object);

            var result = await handler.Handle(query, new System.Threading.CancellationToken());

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count);
            projectRepository.Verify(p => p.GetAllAsync().Result, Times.Once);
        }
    }
}
