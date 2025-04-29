using CandidatesApplication.BL.DTOs.CandidateHasSkillDTOs;
using CandidatesApplication.BL.DTOs.SkillDTOs;
using CandidatesApplication.BL.Services.IServices;
using CandidatesApplication.DAL.Models;
using CandidatesApplication.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.BL.Services.Services
{
    public class CandidatesHasSkillsServices : ICandidatesHasSkillsServices
    {
        IUnitOfWork _unitOfWork { get; set; }
        public CandidatesHasSkillsServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        KeyValuePair<int, string> checkMaxNumSkills(int count, int Candidate_Id)
        {

            var foundedCandidate = _unitOfWork._canditateRepo.GetById(Candidate_Id);
            if (foundedCandidate is null)
            {
                return new KeyValuePair<int, string>(-1, "Candidates not Existed");
            }

            int remainingSkillCount_FofAdding = (foundedCandidate.MaxNumSkills) - (foundedCandidate.CandidateHasSkill_list.Count);

            return new KeyValuePair<int, string>(remainingSkillCount_FofAdding, "");
        }

        bool checkExperience_Limit(int Candidate_Id, DateTime skill_GainedDate)
        {
            var foundedCandidate = _unitOfWork._canditateRepo.GetById(Candidate_Id);
            if (foundedCandidate is null)
            {
                return false;
            }

            if (foundedCandidate.YearsOfExperience < (DateTime.Now.Year - skill_GainedDate.Year))
            {
                return false;
            }
            return true;

        }
        public async Task<KeyValuePair<int, string>> Add(IList<CandidateHasSkill_dto> candidateHasSkill_dto_list)
        {
            KeyValuePair<int, string> checkMaxNumSkills_result = checkMaxNumSkills(candidateHasSkill_dto_list.Count, candidateHasSkill_dto_list[0].Candidate_Id);

            if (checkMaxNumSkills_result.Key < 0)
            {
                return checkMaxNumSkills_result;
            }

            string Messege = " done \r\n";
            bool isAdded = false;
            int counterLimit = checkMaxNumSkills_result.Key <= candidateHasSkill_dto_list.Count ? checkMaxNumSkills_result.Key : candidateHasSkill_dto_list.Count;
            for (int i = 0; i < counterLimit; i++)
            {
                if (checkExperience_Limit(candidateHasSkill_dto_list[i].Candidate_Id, candidateHasSkill_dto_list[i].GainedDate))
                {
                    int Adding_result = await _unitOfWork._candidateHasSkillRepo.Add(new CandidateHasSkill
                    {

                        Candidate_Id = candidateHasSkill_dto_list[i].Candidate_Id,
                        Skill_Id = candidateHasSkill_dto_list[i].Skill_Id,
                        GainedDate = candidateHasSkill_dto_list[i].GainedDate
                    });
                    isAdded = true;
                }
                else
                {
                    Messege += $" gain date of the skill with is {candidateHasSkill_dto_list[i].Skill_Id} can not be smaller than the YearsOfExperience ... \r\n";
                }

            }

            return new KeyValuePair<int, string>(isAdded? 1 : -1, Messege);
        }


        public async Task<string> Update(IList<CandidateHasSkill_dto> candidateHasSkill_dto_list)
        {

            string Messege = "";
            foreach (var skill in candidateHasSkill_dto_list)
            {
                if (checkExperience_Limit(skill.Candidate_Id, skill.GainedDate))
                {
                    await _unitOfWork._candidateHasSkillRepo.Update(new CandidateHasSkill
                    {

                        Candidate_Id = skill.Candidate_Id,
                        Skill_Id = skill.Skill_Id,
                        GainedDate = skill.GainedDate
                    });
                    Messege +=" Updated \r\n";
                }
                else
                {

                    Messege += $" gain date of the skill with is {skill.Skill_Id} can not be smaller than the YearsOfExperience ... \r\n";
                }

            }

            return Messege;
        }

        public async Task<KeyValuePair<string, IList<SkillForReading_dto>>> Delete(IList<CandidateHasSkill_dto> candidateHasSkill_dto_list)
        {
            if (candidateHasSkill_dto_list is null)
            {
                return new KeyValuePair<string, IList<SkillForReading_dto>>("deleted Faild", null);
            }
            if (!candidateHasSkill_dto_list.Any())
            {
                return new KeyValuePair<string, IList<SkillForReading_dto>>("deleted Faild", null);
            }
            bool isDeleted = false;
            foreach (var skill in candidateHasSkill_dto_list)
            {

               bool result=  await _unitOfWork._candidateHasSkillRepo.Delete_CandidateHasSkill(skill.Candidate_Id, skill.Skill_Id);
                if (result)
                {
                    isDeleted = true;
                }

            }

            if (isDeleted)
            {
                IList<SkillForReading_dto> Candidate_Skills = _unitOfWork._canditateRepo.GetById(candidateHasSkill_dto_list[0].Candidate_Id).CandidateHasSkill_list.Select(h => new SkillForReading_dto
                {
                    Id = h.Skill_Id,
                    Name = h.Skill.Name,
                    GainedDate = h.GainedDate
                }).ToList();
                return new KeyValuePair<string, IList<SkillForReading_dto>>("deleted Successfully", Candidate_Skills);
            }

            return new KeyValuePair<string, IList<SkillForReading_dto>>("deleted Faild", null);

        }

    }
}
