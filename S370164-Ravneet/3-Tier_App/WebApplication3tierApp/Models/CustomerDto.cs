using _1CommonInfrastructure.Models;

namespace WebApplication3tierApp.Models
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }


    }

    public static class CustomerDtoMapExtensions
    {
        public static CustomerDto ToCustomerDto(this CustomerModel src)
        {
            var dst = new CustomerDto();
            dst.CustomerId = src.CustomerId;
            dst.FirstName = src.FirstName;
            dst.LastName = src.LastName;
            dst.Email = src.Email;
            dst.Phone = src.Phone;
            dst.Address = src.Address;

            return dst;
        }

        public static CustomerModel ToCustomerModel(this CustomerDto src)
        {
            var dst = new CustomerModel();
            dst.CustomerId = src.CustomerId;
            dst.FirstName = src.FirstName;
            dst.LastName = src.LastName;
            dst.Email = src.Email;
            dst.Phone = src.Phone;
            dst.Address = src.Address;
            return dst;
        }
    }
}
