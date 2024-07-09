using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly APIDbContext _context;
    private readonly DbSet<T> _entities;

    public Repository(APIDbContext context)
    {
        _context = context;
        _entities = _context.Set<T>();
    }

    public T GetById(int id)
    {
        return _entities.Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _entities.ToList();
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return _entities.Where(predicate);
    }

    public void Add(T entity)
    {
        _entities.Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _entities.Update(entity);
        _context.SaveChanges();
    }

    public void Remove(T entity)
    {
        _entities.Remove(entity);
        _context.SaveChanges();
    }
}