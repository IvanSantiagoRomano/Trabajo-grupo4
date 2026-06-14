using Application.Common;
using Application.Privileges;

namespace Application.Users
{
    public class UserDTO: IDto
    {
        public string Username { get; set; } = null!;
        public string Password { get;  set; } = null!;
        public string Salt { get;  set; } = null!;
        public string Name { get;  set; } = null!;
        public string LastName { get;  set; } = null!;
        public string TaxId { get; set; } = null!;
        public string DocNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;

        public List<PrivilegeDTO> Privileges { get; set; } = new List<PrivilegeDTO>();

    }
}
