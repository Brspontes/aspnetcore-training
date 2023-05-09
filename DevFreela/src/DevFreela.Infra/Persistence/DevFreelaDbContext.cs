using DevFreela.Core.Entities;
using System.Collections.Generic;

namespace DevFreela.Infra.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            //TODO: Podemos inicializar a lista com projetos novos    
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectsComments> ProjectsComments { get; set; }
    }
}
