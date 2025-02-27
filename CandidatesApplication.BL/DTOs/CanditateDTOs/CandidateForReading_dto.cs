using CandidatesApplication.BL.DTOs.SkillDTOs;
using CandidatesApplication.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.BL.Services.DTOs.CanditateDTOs
{
    public class CandidateForReading_dto
    {
         
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public int YearsOfExperience { get; set; }
        public int MaxNumSkills { get; set; }
        public IList<SkillForReading_dto> Skills_list { get; set; } = new List<SkillForReading_dto>();
    }
}
