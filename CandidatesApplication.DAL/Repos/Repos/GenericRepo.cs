using CandidatesApplication.DAL.Data;
using CandidatesApplication.DAL.Repos.IRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesApplication.DAL.Repos.Repos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        CandidateAppContext _context { get; set; }
        DbSet<T> entity_list { get; set; }
        public GenericRepo(CandidateAppContext context)
        {
            _context = context;
            entity_list = _context.Set<T>();
        }


        public DbSet<T> GetAll()
        {
            return entity_list;
        }

        public T? GetById(int id)
        {
            T? entity = entity_list.Find(id);
            return  entity;
        }
        public async Task<int> Add(T t)
        {
           await entity_list.AddAsync(t);
            return await _context.SaveChangesAsync();

        }


        public async Task Update(T t)
        {
            _context.Entry(t).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async Task Delete(int id)
        {
            T? founded = entity_list.Find(id);
            if (founded == null)
                return;
            entity_list.Remove(founded);
            await _context.SaveChangesAsync();
        }

    }
}
