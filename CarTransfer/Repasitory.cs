using Microsoft.EntityFrameworkCore;

namespace CarTransfer
{
    public class Repository<TEntity, TKey> : IRepasitory<TEntity, TKey> where TEntity : class
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(TKey key)
        {
            var entity = GetById(key);
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
            //return _dbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(TKey id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        //public bool Register(string username, string password)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool VerifyLogin(string username, string password)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
