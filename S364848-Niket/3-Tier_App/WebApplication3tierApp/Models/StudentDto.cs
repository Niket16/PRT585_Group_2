using _1CommonInfrastructure.Models;

namespace WebApplication3tierApp.Models
{
    public class StudentDto
    {
        public int StudentId { get; set; }

        public string StudentFirstName { get; set; } // nvarchar(400)

        public string StudentLastName { get; set; }

        public string StudentEmail { get; set; }

        public string StudentDepartment { get; set; }

    }

    public static class StudentDtoMapExtensions
    {
        public static StudentDto ToStudentDto(this StudentModel src)
        {
            var dst = new StudentDto();
            dst.StudentId = src.StudentId;
            dst.StudentFirstName = src.StudentFirstName;
            dst.StudentLastName = src.StudentLastName;
            dst.StudentDepartment = src.StudentDepartment;
            dst.StudentEmail = src.StudentEmail;
            return dst;
        }

        public static StudentModel ToStudentModel(this StudentDto src)
        {
            var dst = new StudentModel();
            dst.StudentId = src.StudentId;
            dst.StudentFirstName = src.StudentFirstName;
            dst.StudentLastName = src.StudentLastName;
            dst.StudentDepartment = src.StudentDepartment;
            dst.StudentEmail = src.StudentEmail;
            return dst;
        }
    }
}
