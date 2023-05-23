using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.OutputModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(string title, DateTime createdAt)
        {
            Title = title;
            CreatedAt = createdAt;
        }

        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
