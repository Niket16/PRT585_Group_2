

using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Interfaces;
using _3BusinessLogicLayer.Interfaces;

namespace _3BusinessLogicLayer.Services
{
    public class ProjectService :  IProjectService
    {
        private readonly IProjectDal _ProjectDal;
        //private readonly IProjectBalService _ProjectBalService;
        public ProjectService(IProjectDal ProjectDal
        //ILoggingService loggingService,
        //IProjectDal ProjectDal,
        //IAuditDal auditDal
       // IProjectBalanceService balsvc
        ) 
        {
            _ProjectDal = ProjectDal;
            // _ProjectBalService = balsvc;
        }

        public async Task<ProjectModel?> GetById(int ProjectId)
        {           
            return _ProjectDal.GetById(ProjectId);
        }


        public async Task<List<ProjectModel>> GetAll()
        {            
            return _ProjectDal.GetAll();
        }

        public async Task<int> CreateProject(ProjectModel Project)
        {
            //write validations here
            var newProjectId = _ProjectDal.CreateProject(Project);
            return newProjectId;
        }

        public async Task UpdateProject(ProjectModel Project)
        {
            //write validations here 
            _ProjectDal.UpdateProject(Project);
        }

        public async Task DeleteProject(int ProjectId)
        {            
            try
            {
                //if(balservice.getBal(ProjectId) = 0)
                _ProjectDal.DeleteProject(ProjectId);
            }
            catch (Exception e)
            {
                //_loggingService.WriteLog(LoggingLevel.Error, "Layer", $"Error delete Project Id:{ProjectId}. {e.Message}", e.StackTrace);
            }
        }
    }
}
