namespace CarTransfer
{
    public interface IRepasitory<TEntity,TKey> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(TKey key);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TKey id);
        //bool Register(string username, string password);
        //bool VerifyLogin(string username, string password);
    }
}
