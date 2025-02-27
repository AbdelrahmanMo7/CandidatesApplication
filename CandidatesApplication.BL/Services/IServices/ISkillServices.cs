using CandidatesApplication.BL.DTOs.SkillDTOs;
using CandidatesApplication.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.BL.Services.IServices
{
    public interface ISkillServices
    {
        IList<SkillForReading_dto> GetAll();
        //Candidate? GetById(int id);
        Task<int> Add(SkillForReading_dto skillForReading_dto);
    }
}
