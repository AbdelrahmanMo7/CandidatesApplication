using CandidatesApplication.BL.DTOs.CanditateDTOs;
using CandidatesApplication.BL.DTOs.SkillDTOs;
using CandidatesApplication.BL.Services.DTOs.CanditateDTOs;
using CandidatesApplication.BL.Services.IServices;
using CandidatesApplication.DAL.Models;
using CandidatesApplication.DAL.UnitOfWork;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.BL.Services.Services
{
    public class CandidatesServices : ICandidatesServices
    {
        IUnitOfWork _unitOfWork {  get; set; }
        public CandidatesServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private IList<Candidate> ParseFile(Stream fileStream)
        {
            var candidates = new List<Candidate>();
            try
            {
                var reader = new StreamReader(fileStream);
                string headerLine = reader.ReadLine(); // Skip header


                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    var columns = line.Split("\t\t");
                    candidates.Add(new Candidate
                    {
                        Name = columns[0],
                        Nickname = columns[1],
                        Email = columns[2],
                        YearsOfExperience = int.TryParse(columns[4], out var newYearsOfExperience) ? newYearsOfExperience : 1,
                        MaxNumSkills = int.TryParse(columns[4], out var maxSkills) ? maxSkills : 0
                    });
                }
                return candidates.ToList();
            }
            catch (Exception ex)
            {
                return candidates.ToList();
            }
           
          
           
        }

        public async Task<IList<CandidateForReading_dto>> AddList(Stream fileStream)
        {

            var candidates = ParseFile(fileStream);
            IList <CandidateForReading_dto> newList= new List<CandidateForReading_dto >();

            foreach (var item in candidates)
            {
                // ckeck validations

                //

                KeyValuePair<int, string> result = await this.AddOne(new CandidateForWriting_dto
                {
                    Email = item.Email,
                    Nickname = item.Nickname,
                    Name = item.Name,
                    YearsOfExperience = item.YearsOfExperience,
                    MaxNumSkills = item.MaxNumSkills
                });

                if (result.Key > 0)
                {
                    newList.Add(new CandidateForReading_dto
                    {
                        Id = result.Key ,
                        Name = item.Name,
                        Nickname = item.Nickname,
                        Email = item.Email,
                        YearsOfExperience = item.YearsOfExperience,
                        MaxNumSkills = item.MaxNumSkills
                    });
                }
            }
            return newList;
        }

        public async Task<KeyValuePair<int,string>> AddOne(CandidateForWriting_dto canditateForAdding_dto)
        {
            bool IsEmailFounded_ = _unitOfWork._canditateRepo.GetCanditatesEmails(null).Where(e => e.Equals(canditateForAdding_dto.Email)).Any();
            if (IsEmailFounded_)
            {
                return new KeyValuePair<int, string>(-1, "this Email is Already Founded For another User");
            }
            Candidate NewCandidate = new Candidate
            {
                Name = canditateForAdding_dto.Name,
                Nickname = canditateForAdding_dto.Nickname,
                Email = canditateForAdding_dto.Email,
                YearsOfExperience = canditateForAdding_dto.YearsOfExperience,
                MaxNumSkills = canditateForAdding_dto.MaxNumSkills 
            };
            await _unitOfWork._canditateRepo.Add(NewCandidate);
            
            return new KeyValuePair<int, string>(NewCandidate.Id, "done");
        }

        public KeyValuePair< IList<CandidateForReading_dto>,int> GetAll(int PageNumber)
        {
            IList < CandidateForReading_dto > canditates = new List<CandidateForReading_dto >();
            var alllist = _unitOfWork._canditateRepo.GetAll();
            canditates = alllist.OrderByDescending(c=>c.Id).Skip((PageNumber-1)*20).Take(20).Select(e => new CandidateForReading_dto
            {
                Id = e.Id,
                Name = e.Name,
                Nickname = e.Nickname,
                Email = e.Email,
                YearsOfExperience = e.YearsOfExperience,
                MaxNumSkills = e.MaxNumSkills
            }).ToList();
            return new KeyValuePair<IList<CandidateForReading_dto>, int>( canditates,alllist.Count());
        }

        public CandidateForReading_dto? GetById(int id)
        {
            Candidate founded = _unitOfWork._canditateRepo.GetById(id);
            if (founded is null)
            {
                return null;
            }

            return new CandidateForReading_dto
            {
                Id = founded.Id,
                Name = founded.Name,
                Nickname = founded.Nickname,
                Email = founded.Email,
                YearsOfExperience = founded.YearsOfExperience,
                MaxNumSkills = founded.MaxNumSkills,
                Skills_list= founded.CandidateHasSkill_list.Select(h=> new SkillForReading_dto
                {
                    Id=h.Skill_Id,
                    Name= h.Skill.Name,
                    GainedDate=h.GainedDate
                }).ToList()
            };
        }

        public async Task<string> Update(CandidateForWriting_dto canditateForAdding_dto)
        {
            bool IsEmailFounded_ = _unitOfWork._canditateRepo.GetCanditatesEmails( canditateForAdding_dto.Id).Where(e => e.Contains(canditateForAdding_dto.Email)).Any();
            if (IsEmailFounded_)
            {
                return "this Email is Already Founded For another User";
            }
            Candidate NewCandidate = new Candidate
            {
                Id =canditateForAdding_dto.Id,
                Name = canditateForAdding_dto.Name,
                Nickname = canditateForAdding_dto.Nickname,
                Email = canditateForAdding_dto.Email,
                YearsOfExperience = canditateForAdding_dto.YearsOfExperience,
                MaxNumSkills = canditateForAdding_dto.MaxNumSkills
            };
            await _unitOfWork._canditateRepo.Update(NewCandidate);

            
            return "done";
        }
    }
}
