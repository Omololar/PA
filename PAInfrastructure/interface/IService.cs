using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAInfrastructure
{
    public interface IService<T> where T : class
    {
        void AddItem(T entity);

        void RemoveItem(T entity);
        //IEnumerable<T> GetAll();
        //IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);        

        //T GetSingle(int id);
        //void Edit(T entity);
        void Clear();

    }
}
