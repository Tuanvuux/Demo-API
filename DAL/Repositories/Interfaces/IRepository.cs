using System.Linq.Expressions;

public interface IRepository<T> where T : class
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

    T Add(T entity);
    T Update(T entity);
    T Remove(T entity);
}
