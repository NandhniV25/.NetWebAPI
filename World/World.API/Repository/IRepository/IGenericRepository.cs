using System.Linq.Expressions;
using World.API.Models;

namespace World.API.Repository.IRepository
{
    public interface IGenericRepository<T> where T : class
    {

        //generic repository -> used to reduce the redundant tasks
        //(like states and country operations are same) so we reduce the code
        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        Task Create(T entity);

        Task Delete(T entity);

        Task Save();

        bool IsRecordExists(Expression<Func<T, bool>> condition);
    }
}
