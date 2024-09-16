using _1CommonInfrastructure.Models;

namespace WebApplication3tierApp.Models
{
    public class ProjectDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }

    public static class ProjectDtoMapExtensions
    {
        public static ProjectDto ToProjectDto(this ProjectModel src)
        {
            var dst = new ProjectDto();
            dst.ProjectId = src.ProjectId;
            dst.ProjectName = src.ProjectName; 
            dst.Description = src.Description;
            dst.StartDate = src.StartDate;  
            dst.EndDate = src.EndDate;
            return dst;
        }

        public static ProjectModel ToProjectModel(this ProjectDto src)
        {
            var dst = new ProjectModel();
            dst.ProjectId = src.ProjectId;
            dst.ProjectName = src.ProjectName;
            dst.StartDate = src.StartDate;
            dst.EndDate = src.EndDate;
            dst.Description = src.Description;

            return dst;
        }
    }
}
