

namespace DataAccessLayer.Repository
{
    public interface IDbInitializer
    {

        public Task InitializeAsync();
        public Task InitializeIdentityAsync();
    }
}

