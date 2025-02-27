using CandidatesApplication.DAL.Data;
using CandidatesApplication.DAL.Models;
using CandidatesApplication.DAL.Repos.IRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.DAL.Repos.Repos
{
    public class CandidateRepo :GenericRepo<Candidate>, ICandidateRepo
    {
        CandidateAppContext _context { get; set; }
        public CandidateRepo(CandidateAppContext context) : base(context) 
        {
            this._context = context;
        }

        public List<string> GetCanditatesEmails(int? id)
        {
            if (id != null)
            {
                return _context.Candidates.Where(e=>e.Id!=id).Select(c => c.Email).ToList();
            }
            else
            {
                return _context.Candidates.Select(c => c.Email).ToList();
            }
           
        }

        public new Candidate? GetById(int id)
        {

            return _context.Candidates.Include(e=> e.CandidateHasSkill_list).ThenInclude(h=>h.Skill).FirstOrDefault(e => e.Id == id);
            
        }
    }
}
