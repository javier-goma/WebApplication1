using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Users : IEntity
    {
        [Key]
        public uint Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public uint IdProfile { get; set; }
        public uint IdEmployee { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate{ get; set; }
        public DateTime LastLogin { get; set; }

        public virtual ICollection<Profiles> Profile { get; set; }

    }
}