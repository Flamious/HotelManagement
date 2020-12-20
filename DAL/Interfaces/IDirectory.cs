using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IDirectory<T> where T : class
    {
        List<T> GetList();
        T GetItem(int idFirst, int idSecond);
        void Create(T item);
        void Update(T item);
        void Delete(int idFirst, int idSecond);
        void Delete(int id, bool isFirstId);
    }
}
