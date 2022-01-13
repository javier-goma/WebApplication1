﻿using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Db
{
    public class WebApplicationContext : DbContext
    {
        public WebApplicationContext(DbContextOptions<WebApplicationContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Profiles> Profiles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

    }
}