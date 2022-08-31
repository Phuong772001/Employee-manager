using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Manage.Model.Base;
using Manage.Model.Context;
using Manage.Repository.Base.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Manage.Repository.Base.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntityBase
    {
        private readonly DatabaseContext _context;
        public RepositoryBase(DatabaseContext context)
        {
            _context = context;
        }
        public IQueryable<T> FindAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            await Task.Run(() => _context.Set<T>().Update(entity));
        }

        public async Task Delete(T entity)
        {
            await Task.Run(() => _context.Set<T>().Remove(entity));
            await _context.SaveChangesAsync();
        }
        public async Task<T> FindByCode(string code)
        {
            return await FindByCondition(a => a.Code.Equals(code)).FirstOrDefaultAsync();
        }

        public async Task<T> FindById(int? id)
        {
            return await FindByCondition(a => a.Id.Equals(id)).FirstOrDefaultAsync();

        }

        //public async Task<List<T>> GetAll(BaseRequest baseRequest)
        //{
        //    return await Task.Run(() => FindAll().OrderBy(a => a.Id)
        //        .Skip((baseRequest.pageNum - 1) * baseRequest.pageSize)
        //        .Take(baseRequest.pageSize)
        //        .ToList());
        //}
    }
}
