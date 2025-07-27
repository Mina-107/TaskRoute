namespace DataAccessLayer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly ConcurrentDictionary<string, object> _Repositories;

        public UnitOfWork(ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
            _Repositories = new();
        }
        public IGenaricRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            


            return (IGenaricRepository<TEntity, Tkey>)_Repositories.GetOrAdd(typeof(TEntity).Name, _ => new GenaricRepository<TEntity, Tkey>(_DbContext));
        }

        public async Task<int> SaveChangesAsync()
        => await _DbContext.SaveChangesAsync();
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _DbContext.Database.BeginTransactionAsync();
        }


    }
}
