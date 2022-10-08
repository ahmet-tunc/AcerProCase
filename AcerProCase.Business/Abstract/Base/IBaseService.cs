using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AcerProCase.Business.Abstract.Base
{
    public interface IBaseService<T> where T : Entity, new()
    {
        Task<IResult> AddAsync(T entity);
        Task<IResult> AddListAsync(List<T> entity);
        Task<IResult> UpdateAsync(T entity);
        Task<IResult> UpdateListAsync(List<T> entity);
        Task<IDataResult<List<T>>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<IDataResult<T>> GetByIdAsync(int id);
    }
}
