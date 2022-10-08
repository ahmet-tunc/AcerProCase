using AcerProCase.Business.Abstract.Base;
using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AcerProCase.Business.Concrete.Base
{
    public abstract class BaseManager<T> : IBaseService<T> where T : Entity, new()
    {
        private readonly IEntityRepository<T> _entityRepository;

        public BaseManager(IEntityRepository<T> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async virtual Task<IResult> AddAsync(T entity)
        {
            var result = await _entityRepository.AddAsync(entity);
            if (result.Success)
                return new SuccessResult(result.Message);

            return new ErrorResult(result.Message);
        }

        public async virtual Task<IResult> AddListAsync(List<T> entity)
        {
            var result = await _entityRepository.AddListAsync(entity);
            if (result.Success)
                return new SuccessResult(result.Message);

            return new ErrorResult(result.Message);
        }

        public async virtual Task<IResult> UpdateAsync(T entity)
        {
            var result = await _entityRepository.UpdateAsync(entity);
            if (result.Success)
                return new SuccessResult(result.Message);

            return new ErrorResult(result.Message);
        }


        public async virtual Task<IResult> UpdateListAsync(List<T> entity)
        {
            var result = await _entityRepository.UpdateListAsync(entity);
            if (result.Success)
                return new SuccessResult(result.Message);

            return new ErrorResult(result.Message);
        }


        public async virtual Task<IDataResult<List<T>>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            var result = await _entityRepository.GetAllAsync(filter ?? null);
            if (result.Success)
                return new SuccessDataResult<List<T>>(result.Data, result.Message);

            return new ErrorDataResult<List<T>>(result.Message);
        }

        public async virtual Task<IDataResult<T>> GetByIdAsync(int id)
        {
            var result = await _entityRepository.GetAsync(x => x.Id == id);
            if (result.Success)
                return new SuccessDataResult<T>(result.Data, result.Message);

            return new ErrorDataResult<T>(result.Message);
        }
    }
}
