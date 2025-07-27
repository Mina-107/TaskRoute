
namespace DataAccessLayer.Repository
{
    internal static class SpecificationEvaluator
    {
        public static IQueryable<T> CreateQuery<T>(IQueryable<T> query, ISpecification<T> specification) where T : class { 
        if(specification.Criteria is not null)
                query = query.Where(specification.Criteria);
            query = specification.IncludeExpressions.Aggregate(query, (currentQuery, include) => currentQuery.Include(include));
            return query;
        
        }
    }
}

