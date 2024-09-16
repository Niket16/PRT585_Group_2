using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Interfaces
{
    public interface IProjectDal
    {
        // Getters
        ProjectModel? GetById(int ProjectId);
        List<ProjectModel> GetAll();

        // Actions
        int CreateProject(ProjectModel Project);
        void UpdateProject(ProjectModel Project);
        void DeleteProject(int ProjectId);
    }
}
