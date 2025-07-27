
namespace DataAccessLayer.Data.Entities

{
    public  abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}

