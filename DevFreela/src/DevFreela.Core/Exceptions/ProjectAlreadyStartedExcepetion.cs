using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Exceptions
{
    internal class ProjectAlreadyStartedExcepetion : Exception
    {
        public ProjectAlreadyStartedExcepetion() : base("Project already started")
        {
            
        }
    }
}
