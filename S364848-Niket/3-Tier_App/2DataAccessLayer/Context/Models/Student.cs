using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Context.Models
{
    public class Student
    {
        public int StudentId { get; set; } // int
        public string StudentFirstName { get; set; } // nvarchar(400)

        public string StudentLastName { get; set; }

        public string StudentEmail { get; set; }

        public string StudentDepartment { get; set; }


        
    }
}
