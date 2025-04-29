using CandidatesApplication.BL.DTOs.CanditateDTOs;
using CandidatesApplication.BL.Services.DTOs.CanditateDTOs;
using CandidatesApplication.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.BL.Services.IServices
{
    public interface ICandidatesServices
    {
        KeyValuePair<IList<CandidateForReading_dto>, int> GetAll( int PageNumber);
        CandidateForReading_dto? GetById(int id);
        Task<KeyValuePair<int, string>> AddOne(CandidateForWriting_dto canditateForAdding_dto);
        Task<IList<CandidateForReading_dto>> AddList(Stream fileStream);
        Task<string> Update(CandidateForWriting_dto canditateForAdding_dto);
    }
}
