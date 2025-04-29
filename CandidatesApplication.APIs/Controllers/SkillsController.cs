using CandidatesApplication.BL.DTOs.SkillDTOs;
using CandidatesApplication.BL.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CandidatesApplication.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {

        private ISkillServices _skillServices;
        public SkillsController(ISkillServices skillServices)
        {
            _skillServices = skillServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_skillServices.GetAll());
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(SkillForReading_dto skillForReading_Dto)
        {
            try
            {
                int new_Id = await _skillServices.Add(skillForReading_Dto);
                return CreatedAtAction("GetAll", skillForReading_Dto);
            }
            catch (Exception ex)
            {
                return BadRequest(" Filled to add this skill!!!");
            }
        }
    }
}
