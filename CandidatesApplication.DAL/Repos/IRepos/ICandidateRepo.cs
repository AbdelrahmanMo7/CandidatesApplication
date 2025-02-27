using CandidatesApplication.DAL.Data;
using CandidatesApplication.DAL.Models;
using CandidatesApplication.DAL.Repos.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.DAL.Repos
{
    public interface ICandidateRepo : IGenericRepo<Candidate> 
    {
        List<string> GetCanditatesEmails(int? id );
    }
}
