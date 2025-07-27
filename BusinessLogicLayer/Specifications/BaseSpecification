

namespace BusinessLogicLayer.SI.Specifications
{
    public abstract class BaseSpecification<T> : ISpecification<T> where T : class
    {
        protected BaseSpecification(Expression<Func<T, bool>> ? criteria)
        {
            Criteria = criteria;
            }

        public Expression<Func<T, bool>> Criteria { get; private set; }

        public List<Expression<Func<T, object>>> IncludeExpressions { get; } = [];
        public List<Expression<Func<T, object>>> GroupExpressions { get; } = [];
        protected void AddInclude(Expression<Func<T, object>> expression)
        =>IncludeExpressions.Add(expression);
        protected void EditCriteria(Expression<Func<T, bool>> criteria)
       => Criteria=criteria;
        protected void AddGroup(Expression<Func<T, object>> expression) { 
        
        GroupExpressions.Add(expression);
        }

    }
}
