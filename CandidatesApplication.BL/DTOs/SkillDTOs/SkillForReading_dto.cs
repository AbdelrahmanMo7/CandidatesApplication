using CandidatesApplication.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.BL.DTOs.SkillDTOs

{
    public class SkillForReading_dto
    {
        public int Id { get; set; }
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Skill name should contain only letters and symbols, no numbers.")]
        public string Name { get; set; }

    }
}
