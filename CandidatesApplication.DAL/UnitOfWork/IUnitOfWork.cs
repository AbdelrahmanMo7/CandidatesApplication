

using CandidatesApplication.DAL.Models;
using CandidatesApplication.DAL.Repos;
using CandidatesApplication.DAL.Repos.IRepos;

namespace CandidatesApplication.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICandidateRepo _canditateRepo { get; }
        ICandidateHasSkillRepo _candidateHasSkillRepo { get; }
        IGenericRepo<Skill> _skillRepo { get; }
    }
}
