using CandidatesApplication.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CandidatesApplication.DAL.Data.Config
{
    public  class CandidateHasSkillsConfiguration : IEntityTypeConfiguration <CandidateHasSkill>
    {

        public void Configure(EntityTypeBuilder<CandidateHasSkill> builder)
        {
           
            builder.HasKey(c => new {c.Candidate_Id, c.Skill_Id });
            builder.Property(c => c.Candidate_Id).IsRequired();
            builder.Property(c => c.Skill_Id).IsRequired();
                       
            builder.HasOne(h => h.Candidate).WithMany(c=>c.CandidateHasSkill_list).HasForeignKey(C => C.Candidate_Id);
            builder.HasOne(h => h.Skill).WithMany(c=>c.CandidateHasSkill_list).HasForeignKey(C => C.Skill_Id);

            
        }
    }
}
