using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Source.Repositories.Abstract;

public interface IRepository<T>
{
    T? Get(Func<T, bool> predicate);
    IList<T>? GetList(Func<T, bool>? predicate = null);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
}
