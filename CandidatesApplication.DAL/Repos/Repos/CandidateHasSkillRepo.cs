using CandidatesApplication.DAL.Data;
using CandidatesApplication.DAL.Models;
using CandidatesApplication.DAL.Repos.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.DAL.Repos.Repos
{
    public class CandidateHasSkillRepo : GenericRepo<CandidateHasSkill> , ICandidateHasSkillRepo
    {
        CandidateAppContext _context { get; set; }
        public CandidateHasSkillRepo(CandidateAppContext context) : base(context)
        {
            this._context = context;
        }

       
        public CandidateHasSkill? GetByCandidateIdAndSkillId(int Candidate_id, int Skill_id)
        {
            CandidateHasSkill? candidateHasSkill = _context.CandidateHasSkills.FirstOrDefault(e => e.Candidate_Id == Candidate_id && e.Skill_Id== Skill_id);
            if (!(candidateHasSkill is null))
            {
                _context.Entry(candidateHasSkill).Reference("CandidateHasSkill_list").Load();
            }

            return candidateHasSkill;
        }

        public async Task Delete_CandidateHasSkill(int Candidate_id, int Skill_id)
        {
            CandidateHasSkill? candidateHasSkill = _context.CandidateHasSkills.FirstOrDefault(e => e.Candidate_Id == Candidate_id && e.Skill_Id == Skill_id);
            if (candidateHasSkill is null)
            {
                return;
            }

            _context.CandidateHasSkills.Remove(candidateHasSkill);
            await _context.SaveChangesAsync();
        }
    }
}
