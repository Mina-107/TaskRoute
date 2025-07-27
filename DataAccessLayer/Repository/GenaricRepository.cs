

namespace DataAccessLayer.Repository
{

    internal class GenaricRepository<TEntity, t>(ApplicationDbContext dbContext) : IGenaricRepository<TEntity, t> where TEntity : BaseEntity<t>

    {
        public async Task<IEnumerable<TEntity?>> GetAllAsync() => await dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        public async Task<IEnumerable<TEntity?>> GetAllAsync(ISpecification<TEntity> specification) { 

        var query = dbContext.Set<TEntity>().AsNoTracking();
           return await  SpecificationEvaluator.CreateQuery(query, specification).ToListAsync();
        }
        public async Task<TEntity?> GetByIdAsync(ISpecification<TEntity> specification) { 

        var query = dbContext.Set<TEntity>().AsNoTracking();
            return await SpecificationEvaluator.CreateQuery(query, specification).FirstAsync();
        }

        public async Task<TEntity?> GetByIdAsync(t id) => await dbContext.Set<TEntity>().FirstOrDefaultAsync(e=>e.Id.Equals(id));


        public void  Update(TEntity entity)
        =>  dbContext.Set<TEntity>().Update(entity);


        public  void Delete(TEntity entity) =>  dbContext.Set<TEntity>().Remove(entity);
        public void Add(TEntity entity)=>  dbContext.Set<TEntity>().Add(entity);

        //public async Task<int> countAsync(ISpecification<TEntity> specification)
        //{

        //    var query = dbContext.Set<TEntity>().AsNoTracking();
        //    return await SpecificationEvaluator.CreateQuery(query, specification).CountAsync();

        //}

    }
}
