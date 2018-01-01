using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HISAB.ExpenseTracker.Data.Persistance
{
    public interface IRepository<T> where T : IEntity
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void Attach(T item);
        IQueryable<T> AsQueryable();
        IEnumerable<T> GetAll();
        T Create();
        T Get(int? Id);

    }
}
