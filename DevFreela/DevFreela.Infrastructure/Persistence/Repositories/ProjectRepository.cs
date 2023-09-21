using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext dbContext;

        public ProjectRepository(DevFreelaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            var project = await dbContext.Projects
                            .Include(p => p.Client)
                            .Include(p => p.Freelancer)
                            .SingleOrDefaultAsync(p => p.Id == id);
            return project;
        }
    }
}
