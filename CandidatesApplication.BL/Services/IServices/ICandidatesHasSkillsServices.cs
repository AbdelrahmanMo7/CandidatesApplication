using CandidatesApplication.BL.DTOs.CandidateHasSkillDTOs;
using CandidatesApplication.BL.DTOs.CanditateDTOs;
using CandidatesApplication.BL.DTOs.SkillDTOs;
using CandidatesApplication.BL.Services.DTOs.CanditateDTOs;
using CandidatesApplication.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.BL.Services.IServices
{
    public interface ICandidatesHasSkillsServices
    {
       
       // CandidateHasSkill_dto? GetByCandidateIdAndSkillId(int Candidate_id, int Skill_id);
        Task<KeyValuePair<int, string>> Add(IList< CandidateHasSkill_dto> candidateHasSkill_dto_list);
        Task<string> Update(IList<CandidateHasSkill_dto> candidateHasSkill_dto_list);
        Task<  KeyValuePair<string, IList<SkillForReading_dto> >  > Delete(IList<CandidateHasSkill_dto> candidateHasSkill_dto_list);

    }
}
