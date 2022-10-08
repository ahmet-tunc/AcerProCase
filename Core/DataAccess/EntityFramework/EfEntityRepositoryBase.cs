using Core.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
                    where TEntity : Entity, new()
                    where TContext : DbContext
    {
        protected readonly TContext _context;

        public EfEntityRepositoryBase(TContext context)
        {
            _context = context;
        }
        public async Task<IResult> AddAsync(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await _context.SaveChangesAsync();
            return new SuccessResult(Message.Added);
        }

        public async Task<IResult> AddListAsync(List<TEntity> entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await _context.SaveChangesAsync();
            return new SuccessResult(Message.AddedList);
        }

        public async Task<IResult> UpdateAsync(TEntity entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Added;
            await _context.SaveChangesAsync();
            return new SuccessResult(Message.Updated);
        }

        public async Task<IResult> UpdateListAsync(List<TEntity> entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Added;
            await _context.SaveChangesAsync();
            return new SuccessResult(Message.UpdatedList);
        }


        public async Task<IResult> DeleteByIdAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(filter);

            if (entity == null)
                return new ErrorResult(Message.NotFoundRecord);

            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return new SuccessResult(Message.Deleted);
        }

        public async Task<IResult> DeleteByIdsAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entity = _context.Set<TEntity>().Where(filter).ToList();

            if (entity.Count == 0)
                return new ErrorResult(Message.NotFoundRecord);

            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return new SuccessResult(Message.Deleted);
        }

        public async Task<IResult> DeleteListAsync(TEntity entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return new SuccessResult(Message.DeletedList);
        }


        public async Task<IDataResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
            if (entity != null)
                return new SuccessDataResult<TEntity>(entity, Message.ListedRecord);

            return new ErrorDataResult<TEntity>(entity, Message.NotFoundRecord);
        }

        public async Task<IDataResult<List<TEntity>>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var entity = filter != null ? await _context.Set<TEntity>().Where(filter).ToListAsync() : await _context.Set<TEntity>().ToListAsync();
            if (entity.Count > 0)
                return new SuccessDataResult<List<TEntity>>(entity, Message.ListedRecord);
            else if (entity.Count == 0)
                return new SuccessDataResult<List<TEntity>>(Message.NotFoundRecord);

            return new ErrorDataResult<List<TEntity>>(Message.GetAllFailed);
        }
    }
}
