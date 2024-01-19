using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Contracts;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly RealEstateContext context;

        public BaseRepository(RealEstateContext context)
        {
            this.context = context;
        }
        public virtual async Task<Result<T>> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return Result<T>.Success(entity);
        }

        public virtual async Task<Result<T>> DeleteAsync(Guid id)
        {
            var result = await FindByIdAsync(id);
            if (result != null)
            {
                context.Set<T>().Remove(result.Value);
                await context.SaveChangesAsync();
                return Result<T>.Success(result.Value);
            }
            return Result<T>.Failure($"Entity with id {id} not found");
        }

        public virtual async Task<Result<T>> DeleteIntAsync(int id)
        {
            var result = await FindByIntIdAsync(id);
            if (result != null)
            {
                context.Set<T>().Remove(result.Value);
                await context.SaveChangesAsync();
                return Result<T>.Success(result.Value);
            }
            return Result<T>.Failure($"Entity with id {id} not found");
        }

        public virtual async Task<Result<T>> FindByIdAsync(Guid id)
        {
            var result = await context.Set<T>().FindAsync(id);
            if (result == null)
            {
                return Result<T>.Failure($"Entity with id {id} not found");
            }
            return Result<T>.Success(result);
        }

        public virtual async Task<Result<T>> FindByIntIdAsync(int id)
        {
            var result = await context.Set<T>().FindAsync(id);
            if (result == null)
            {
                return Result<T>.Failure($"Entity with id {id} not found");
            }
            return Result<T>.Success(result);
        }

		public virtual async Task<Result<T>> FindByBasePostIdAsync(Guid basePostId)
		{
			
			var result = await context.Set<T>().SingleOrDefaultAsync(e => EF.Property<Guid>(e, "BasePostId") == basePostId);

			if (result == null)
			{
				return Result<T>.Failure($"Entity with BasePostId {basePostId} not found");
			}

			return Result<T>.Success(result);
		}

        public virtual async Task<Result<IReadOnlyList<T>>> FindByUserIdAsync(Guid userId)
        {
            var result = await context.Set<T>().Where(e => EF.Property<BasePost>(e, "BasePost").UserId == userId.ToString()).ToListAsync();

            if (result == null || result.Count == 0)
            {
                return Result<IReadOnlyList<T>>.Failure($"Entities with userId {userId} not found");
            }

            return Result<IReadOnlyList<T>>.Success(result);
        }

        public virtual async Task<Result<IReadOnlyList<T>>> GetPagedReponseAsync(int page, int size)
        {
            var result = await context.Set<T>().Skip(page).Take(size).AsNoTracking().ToListAsync();
            return Result<IReadOnlyList<T>>.Success(result);
        }

        public virtual async Task<Result<T>> UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Result<T>.Success(entity);
        }

        public virtual async Task<Result<IReadOnlyList<T>>> GetAllAsync()
        {
            var result = await context.Set<T>().ToListAsync();
            return Result<IReadOnlyList<T>>.Success(result);
        }
    }
}
