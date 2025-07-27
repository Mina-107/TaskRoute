

namespace DataAccessLayer.Repository
{
    public interface ISpecification<T> where T : class
    {
        public Expression<Func<T, bool>> Criteria { get; }
        public List< Expression<Func<T, object>>> IncludeExpressions { get; }

    }
}

