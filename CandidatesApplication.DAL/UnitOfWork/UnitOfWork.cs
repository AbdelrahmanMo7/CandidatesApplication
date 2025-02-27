

using CandidatesApplication.DAL.Models;
using CandidatesApplication.DAL.Repos;
using CandidatesApplication.DAL.Repos.IRepos;

namespace CandidatesApplication.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        public ICandidateRepo _canditateRepo { get; }

        public ICandidateHasSkillRepo _candidateHasSkillRepo { get; }

        public IGenericRepo<Skill> _skillRepo { get; }

        public UnitOfWork(ICandidateRepo canditateRepo, ICandidateHasSkillRepo candidateHasSkillRepo, IGenericRepo<Skill> skillRepo)
        {
            _canditateRepo = canditateRepo;
            _candidateHasSkillRepo = candidateHasSkillRepo; 
            _skillRepo = skillRepo;
        }
    }
}
