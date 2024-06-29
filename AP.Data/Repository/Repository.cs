using AP.Data.Models;
using System.Linq.Expressions;

namespace AP.Data.Repository;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    bool Add(T entity);
    T Update(T entity);
    bool Delete(int id);
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
}
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApdatadbContext _context;

    public Repository(ApdatadbContext context) => _context = context;

    public bool Add(T entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public T GetById(int id)
    {
        throw new NotImplementedException();
    }

    public T Update(T entity)
    {
        throw new NotImplementedException();
    }
}
