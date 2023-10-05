using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTest
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            var projectRepository = new Mock<IProjectRepository>();
            var createProjectCommand = new CreateProjectCommand
            {
                Description = "Test",
                TotalCost = 1,
                Title = "Test",
                IdClient = 1,
                IdFreelancer = 2
            };

            var handler = new CreateProjectCommandHandler(projectRepository.Object);
            var id = await handler.Handle(createProjectCommand, new System.Threading.CancellationToken());

            Assert.True(id >= 0);
            projectRepository.Verify(p => p.AddAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}
