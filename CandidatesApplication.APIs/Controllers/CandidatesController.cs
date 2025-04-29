using CandidatesApplication.BL.DTOs.CanditateDTOs;
using CandidatesApplication.BL.Services.DTOs.CanditateDTOs;
using CandidatesApplication.BL.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CandidatesApplication.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {


        private ICandidatesServices _canditatesServices;
        public CandidatesController(ICandidatesServices canditatesServices)
        {
            _canditatesServices = canditatesServices;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] int pageNumber)
        {
            var result = _canditatesServices.GetAll(pageNumber);
            return Ok(new
            {
                TotalCount = result.Value,
               
                Data = result.Key
            });
           
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            CandidateForReading_dto? canditateForReading_ = _canditatesServices.GetById(id);
            if (canditateForReading_ == null)
                return NotFound(" no canditate with this id ");
            return Ok(canditateForReading_);
        }


        [HttpPost("addOne")]
        public async Task<IActionResult> AddOne(CandidateForWriting_dto canditateForAdding_)
        {
            try
            {
                KeyValuePair<int, string> result = await _canditatesServices.AddOne(canditateForAdding_);
                if (result.Key <= 0)
                {
                    return BadRequest(result.Value);
                }
                canditateForAdding_.Id = result.Key;
                return CreatedAtAction("GetById", new { id = result.Key }, canditateForAdding_);
            }
            catch (Exception ex)
            {
                return BadRequest(" Filled to add this Canditate !!!");
            }
        }

        [HttpPost("addList")]
        public async Task<IActionResult> AddList(IFormFile canditatesFile)
        {
            try
            {
                IList<CandidateForReading_dto> addedCanditates = await _canditatesServices.AddList(canditatesFile.OpenReadStream());

                return CreatedAtAction("GetAll", addedCanditates);
            }
            catch (Exception ex)
            {
                return BadRequest(" Filled to add this list of Candidates !!!");
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CandidateForWriting_dto canditateForUpdating_)
        {
            try
            {
                string result = await _canditatesServices.Update(canditateForUpdating_);
                if (!result.Contains("done"))
                {
                    return BadRequest(result);
                }
                return Ok( new { massage = "updated", UpdateedCandidates = canditateForUpdating_ });
            }
            catch (Exception ex)
            {
                return BadRequest(" Filled to Update this Canditate !!!");
            }
        }

         }
}
