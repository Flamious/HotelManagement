using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
