﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingApplication.Models;

namespace TrainingApplication.Data
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext>options):base(options) 
        {

        }

        public DbSet<Character> Characters { get; set; }
    }
}
