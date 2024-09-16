using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context;
using _2DataAccessLayer.Context.Models;
using _2DataAccessLayer.Interfaces;
using _2DataAccessLayer.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Services
{
    public class ProjectDal : IProjectDal
    {
        //private readonly TestDBEntities context;
        private DBEntitiesContext _db;
        public ProjectDal(DBEntitiesContext dbctx)
        {
            this._db = dbctx; // new TestDBEntities();
        }


        public List<ProjectModel> GetAll()
        {
            var result = _db.Project.ToList();

            var returnObject = new List<ProjectModel>();
            foreach (var item in result)
            {
                returnObject.Add(item.ToProjectModel());
            }

            return returnObject;
        }

        public ProjectModel? GetById(int ProjectId)
        {
            var result = _db.Project.SingleOrDefault(x => x.ProjectId == ProjectId);
            return result?.ToProjectModel();
        }


        public int CreateProject(ProjectModel Project)
        {
            var newProject = Project.ToProject();
            _db.Project.Add(newProject);
            _db.SaveChanges();
            return newProject.ProjectId;
        }


        public void UpdateProject(ProjectModel Project)
        {
            var existingProject = _db.Project
                .SingleOrDefault(x => x.ProjectId == Project.ProjectId);

            if (existingProject == null)
            {
                throw new ApplicationException($"Project {Project.ProjectId} does not exist.");
            }
            Project.ToProject(existingProject);

            _db.Update(existingProject);
            _db.SaveChanges();
        }

        public void DeleteProject(int ProjectId)
        {
            var efModel = _db.Project.Find(ProjectId);
            _db.Project.Remove(efModel);
            _db.SaveChanges();


        }

    }

}
