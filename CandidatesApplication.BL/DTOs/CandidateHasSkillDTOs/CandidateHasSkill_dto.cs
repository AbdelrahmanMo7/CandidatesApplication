using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.BL.DTOs.CandidateHasSkillDTOs
{
    public class CandidateHasSkill_dto
    {
        public int Candidate_Id { get; set; }
        public int Skill_Id { get; set; }
        public DateTime GainedDate { get; set; }
    }
}
