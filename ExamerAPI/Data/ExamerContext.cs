#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamerAPI.Models;

namespace ExamerAPI.Data
{
    public class ExamerContext : DbContext
    {
        public ExamerContext(DbContextOptions<ExamerContext> options)
            : base(options)
        {
        }

        public DbSet<ExamerAPI.Models.User> Users { get; set; }

        public DbSet<ExamerAPI.Models.QnA> QnAs { get; set; }

        public DbSet<ExamerAPI.Models.Score> Scores { get; set; }

        public DbSet<ExamerAPI.Models.Exam> Exams { get; set; }

        public DbSet<ExamerAPI.Models.Temp>? Temp { get; set; }


    }


}

