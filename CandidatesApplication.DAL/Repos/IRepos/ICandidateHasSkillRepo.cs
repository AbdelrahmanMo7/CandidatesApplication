using CandidatesApplication.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.DAL.Repos.IRepos
{
    public interface ICandidateHasSkillRepo : IGenericRepo<CandidateHasSkill>
    {

        CandidateHasSkill? GetByCandidateIdAndSkillId(int Candidate_id, int Skill_id);
       
        Task<bool> Delete_CandidateHasSkill(int Candidate_id, int Skill_id);
    }
}
