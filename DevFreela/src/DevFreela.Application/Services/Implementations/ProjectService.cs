using DevFreela.Application.InputModels;
using DevFreela.Application.OutputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using DevFreela.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    internal class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext dbContext;

        public ProjectService(DevFreelaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description,
                inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost);

            dbContext.Projects.Add(project);

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel createComment)
        {
            var comment = new ProjectsComments(createComment.Content, createComment.IdProject, createComment.IdUser);
            dbContext.ProjectsComments.Add(comment);
        }

        public void Delete(int id)
        {
            var project = dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Cancel();
        }

        public void Finish(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = dbContext.Projects;
            return projects.Select(p => new ProjectViewModel(p.Title, p.CreatedAt))
                           .ToList();
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = dbContext.Projects.SingleOrDefault(p => p.Id == id);
            return new ProjectDetailsViewModel(project.Title, project.CreatedAt);
        }

        public void Start(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateProjectInputModel inputModel)
        {
            throw new NotImplementedException();
        }
    }
}
