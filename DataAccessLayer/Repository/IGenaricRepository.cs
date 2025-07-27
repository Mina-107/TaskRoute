

namespace DataAccessLayer.Repository
{
    public interface IGenaricRepository<TEntity, t> where TEntity :BaseEntity<t>
    
    {
 

        Task<IEnumerable<TEntity?>> GetAllAsync();
        Task<IEnumerable<TEntity?>> GetAllAsync(ISpecification<TEntity> specification);
        Task<TEntity?> GetByIdAsync(t id);
        Task<TEntity?> GetByIdAsync(ISpecification<TEntity> specification);
        void Delete(TEntity entity);
         //Task<int> countAsync(ISpecification<TEntity> specification);
        void Add(TEntity entity);
        void Update(TEntity entity);
        //void Update(IEnumerable<TEntity> entities);



    }
}
