using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.DAL.Repos.IRepos
{
    public interface IGenericRepo<T> where T : class
    {
        DbSet<T> GetAll();
        T? GetById(int id);
        Task<int> Add(T t);
        Task Update(T t);
        Task Delete(int id);

    }
}
