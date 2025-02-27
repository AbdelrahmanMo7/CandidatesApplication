using CandidatesApplication.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CandidatesApplication.DAL.Data.Config
{
    public  class SkillConfiguration : IEntityTypeConfiguration <Skill>
    {

       

        public void Configure(EntityTypeBuilder<Skill> builder)
        {
           
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired();
                       
           

            
        }
    }
}
