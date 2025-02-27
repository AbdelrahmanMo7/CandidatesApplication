using CandidatesApplication.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.DAL.Data
{
    public class CandidateAppContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CandidateHasSkill> CandidateHasSkills { get; set; }

        public CandidateAppContext(DbContextOptions<CandidateAppContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
