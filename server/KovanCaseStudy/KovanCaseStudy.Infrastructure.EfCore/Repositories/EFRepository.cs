using Ardalis.Specification.EntityFrameworkCore;
using KovanCaseStudy.SharedKernel.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace KovanCaseStudy.Infrastructure.EfCore.Repositories
{
    public class EFRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
    {
        protected readonly KovanDbContext _context;
        public EFRepository(KovanDbContext context) : base(context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public override async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Add(entity);

            return await Task.FromResult<T>(entity);
        }
        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().AddRange(entities);

            return await Task.FromResult<IEnumerable<T>>(entities);
        }
        public override async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Task.FromResult(_context.Entry(entity).State = EntityState.Modified);
        }
        public override async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Task.FromResult(_context.Set<T>().Remove(entity));
        }
        
        public override async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().RemoveRange(entities);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new Exception("Dont use this SaveChangesAsync() It's forbidden!");
        }
    }
}
