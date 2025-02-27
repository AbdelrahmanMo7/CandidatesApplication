using CandidatesApplication.BL.DTOs.SkillDTOs;
using CandidatesApplication.BL.Services.IServices;
using CandidatesApplication.DAL.Models;
using CandidatesApplication.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.BL.Services.Services
{
    public class SkillServices : ISkillServices
    {

        IUnitOfWork _unitOfWork { get; set; }
        public SkillServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<int> Add(SkillForReading_dto skillForReading_dto)
        {
            return _unitOfWork._skillRepo.Add(new Skill
            {
                Id = skillForReading_dto.Id,
                Name = skillForReading_dto.Name
            });
        }

        public IList<SkillForReading_dto> GetAll()
        {
            IList<SkillForReading_dto> skills = new List<SkillForReading_dto>();
            skills = _unitOfWork._skillRepo.GetAll().Select(s => new SkillForReading_dto
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();
            return skills;
        }
    }
}
