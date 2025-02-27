using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.DAL.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<CandidateHasSkill> CandidateHasSkill_list { get; set; } 
    }
}
