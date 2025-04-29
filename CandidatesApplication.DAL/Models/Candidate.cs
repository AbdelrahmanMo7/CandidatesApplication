using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.DAL.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [RegularExpression(@"^(?=.*[0-9])(?=.*[§®™©ʬ@]).+$", ErrorMessage = "Invalid Nick name format.")]
        public string Nickname { get; set; }
        [RegularExpression(@"^.+@.+$", ErrorMessage = "Invalid Email format. Must contain '@'.")]
        public string Email { get; set; }
        public int YearsOfExperience { get; set; }
        public int MaxNumSkills { get; set; }
        public ICollection<CandidateHasSkill> CandidateHasSkill_list { get; set; }
    }
}
