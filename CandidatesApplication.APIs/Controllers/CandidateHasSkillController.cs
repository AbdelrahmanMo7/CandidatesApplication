using CandidatesApplication.BL.DTOs.CandidateHasSkillDTOs;
using CandidatesApplication.BL.DTOs.CanditateDTOs;
using CandidatesApplication.BL.DTOs.SkillDTOs;
using CandidatesApplication.BL.Services.DTOs.CanditateDTOs;
using CandidatesApplication.BL.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CandidatesApplication.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateHasSkillController : ControllerBase
    {


        private ICandidatesHasSkillsServices _candidatesHasSkillsServices;
        public CandidateHasSkillController(ICandidatesHasSkillsServices candidatesHasSkillsServices)
        {
            _candidatesHasSkillsServices = candidatesHasSkillsServices;
        }



        [HttpPost("add")]
        public async Task<IActionResult> Add(IList<CandidateHasSkill_dto> candidateHasSkill_Dto_list)
        {
            try
            {
                KeyValuePair<int, string> result = await _candidatesHasSkillsServices.Add(candidateHasSkill_Dto_list);
                if (result.Key < 0)
                {
                    return BadRequest(result.Value);
                }
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(" Filled to add skils to Canditate !!!");
            }
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update(IList<CandidateHasSkill_dto> candidateHasSkill_Dto_list)
        {
            try
            {
                string result = await _candidatesHasSkillsServices.Update(candidateHasSkill_Dto_list);
                if (!result.Contains("Updated"))
                {
                    return BadRequest(result);
                }
                return StatusCode(204, new { massage = result });
            }
            catch (Exception ex)
            {
                return BadRequest(" Filled to Update this Candidates skills !!!");
            }
        }


        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(IList<CandidateHasSkill_dto> candidateHasSkill_Dto_list)
        {
            try
            {
                KeyValuePair<string, IList<SkillForReading_dto>> result = await _candidatesHasSkillsServices.Delete(candidateHasSkill_Dto_list);
                return Ok(new
                {
                    message = result.Key,
                    DeletedcandidateHasSkill_Dto_list = candidateHasSkill_Dto_list,
                    Candidate_Skills_ = result.Value
                });

                return StatusCode(204, new { massage = result });
            }
            catch (Exception ex)
            {
                return BadRequest(" Filled to delete this Candidates skills !!!");
            }

        }

    }
}
