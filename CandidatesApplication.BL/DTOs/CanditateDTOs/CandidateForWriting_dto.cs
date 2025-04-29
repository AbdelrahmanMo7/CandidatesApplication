using CandidatesApplication.BL.DTOs.SkillDTOs;
using CandidatesApplication.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.BL.DTOs.CanditateDTOs
{
    public class CandidateForWriting_dto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [RegularExpression(@"^(?=.*[0-9])(?=.*[§®™©ʬ@]).+$", ErrorMessage = "Invalid Nick name format.")]
        public string Nickname { get; set; }
        [RegularExpression(@"^.+@.+$", ErrorMessage = "Invalid Email format. Must contain '@'.")]
        public string Email { get; set; }
        public int YearsOfExperience { get; set; }
        public int MaxNumSkills { get; set; }
      //  public IList<SkillForReading_dto> Skills_list { get; set; } = new List<SkillForReading_dto>();
    }
}
