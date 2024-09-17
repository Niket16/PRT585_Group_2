using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Context.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }  // int
        public string FirstName { get; set; }  // nvarchar(400)
        public string LastName { get; set; }  // nvarchar(400)
        public string Email { get; set; }  // nvarchar(400)
        public string Phone { get; set; }  // nvarchar(15)
        public string Address { get; set; }  // nvarchar(1000)
    }

}
