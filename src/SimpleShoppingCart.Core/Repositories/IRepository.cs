using System.Collections.Generic;

public interface IRepository<T>
{
    IEnumerable<T> Get();
    T Get(long id);
    T Save(T data);
    T Update(T data);
    void Delete(long id);
}
