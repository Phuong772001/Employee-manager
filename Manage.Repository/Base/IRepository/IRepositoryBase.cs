using Manage.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Manage.Repository.Base.IRepository
{
    public interface IRepositoryBase<T>where T : class, IEntityBase
    {
       IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T,bool>> expression);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> FindByCode(string code);
        Task<T> FindById(int? id);
        //Task<List<T>> GetAll(BaseRequest baseRequest);
    }
}
