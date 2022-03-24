using House.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace House.Data
{
    public class HouseDbContext : IdentityDbContext
    {
        public HouseDbContext(DbContextOptions<HouseDbContext> options)
            : base(options) { }

        public DbSet<Home> Home { get; set; }

        
    }
}
