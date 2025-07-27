

namespace DataAccessLayer.Repository
{
    public interface IUnitOfWork 
    {
        public Task<int> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        IGenaricRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>;

    }
}

