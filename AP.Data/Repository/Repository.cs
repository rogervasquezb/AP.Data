using AP.Data.Models;
using Microsoft.EntityFrameworkCore;
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
        _context.Remove(id);
        _context.SaveChanges();
        return true;
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Where(predicate).ToList();
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public T Update(T entity)
    {
        _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
        return entity;
    }
}
