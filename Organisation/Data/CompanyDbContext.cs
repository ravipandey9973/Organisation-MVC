﻿using Microsoft.EntityFrameworkCore;
using Organisation.Models.Entities;

namespace Organisation.Data
{
    public class CompanyDbContext:DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options):base (options)
        {
            
        }
        public DbSet<Company> Companies { get; set; }    
    }
}
