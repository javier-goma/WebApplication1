using WebApplication1.Models;
using System;

namespace WebApplication1.Dto
{
    public class UserDto
    {
        public UserDto(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Password = user.Password;
            IdEmployee = user.IdEmployee;
            Status = user.Status;
            CreatedDate = user.CreatedDate;
            UpdateDate = user.UpdateDate;
            LastLogin = user.LastLogin;
            ProfileId = user.ProfileId;
        }
        
        public uint Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public uint ProfileId { get; set; }

        public uint IdEmployee { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate{ get; set; }
        public DateTime LastLogin { get; set; }

    }
}