using Microsoft.AspNetCore.Identity;

namespace rare.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string Username { get; set; }
        public string Password  { get; set; }
        public string ProfileImgUrl { get; set; }
        public string CreatedOn { get; set; }
        public string Active { get; set; }
    }
}
