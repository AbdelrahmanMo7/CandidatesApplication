using CandidatesApplication.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CandidatesApplication.DAL.Data.Config
{
    public  class CandidateConfiguration :IEntityTypeConfiguration <Candidate>
    {

       

        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
           
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired();
             

            
        }
    }
}
