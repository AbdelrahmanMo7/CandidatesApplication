using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.DAL.Models
{
    public class CandidateHasSkill
    {
        public int Candidate_Id { get; set; }
        public int Skill_Id { get; set; }
        public DateTime GainedDate { get; set; }
        public Candidate Candidate { get; set; } = new();
        public Skill Skill { get; set; } = new();
    }
}
