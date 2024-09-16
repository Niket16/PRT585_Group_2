using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Maps
{
    public static class ProjectMapExtensions
    {
        public static ProjectModel ToProjectModel(this Project src)
        {
            var dst = new ProjectModel();

            dst.ProjectId = src.ProjectId;
            dst.ProjectName = src.ProjectName;
            dst.Description = src.Description;
            dst.StartDate = src.StartDate;
            dst.EndDate = src.EndDate;

            return dst;
        }

        public static Project ToProject(this ProjectModel src, Project dst = null)
        {
            if (dst == null)
            {
                dst = new Project();
            }

            dst.ProjectId = src.ProjectId;
            dst.ProjectName = src.ProjectName;
            dst.Description = src.Description;
            dst.StartDate = src.StartDate;
            dst.EndDate = src.EndDate;

            return dst;
        }
    }
}
