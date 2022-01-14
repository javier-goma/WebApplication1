using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace WebApplication1.Models
{
    public class User : IEntity
    {
        [Key]
        public uint Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public uint IdEmployee { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate{ get; set; }
        public DateTime LastLogin { get; set; }

        public uint ProfileId { get; set; }
        public virtual ICollection<Profile> Profile { get; set; }

    }
}