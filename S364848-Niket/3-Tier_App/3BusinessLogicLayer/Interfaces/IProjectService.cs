using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3BusinessLogicLayer.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectModel?> GetById(int ProjectId);

        Task<List<ProjectModel>> GetAll();

        Task<int> CreateProject(ProjectModel Project);
        Task UpdateProject(ProjectModel Project);
        Task DeleteProject(int ProjectId);
    }
}
