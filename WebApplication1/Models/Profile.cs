﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Profile : IEntity
    {
        [Key]
        public uint Id { get; set; }
        public string ProfileName { get; set; }
    }
}