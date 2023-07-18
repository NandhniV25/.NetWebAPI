using World.API.DTO.States;
using World.API.Models;

namespace World.API.Repository.IRepository
{
    public interface IStatesRepository : IGenericRepository<States>
    {
        //method definition
        //Task<List<States>> GetAll();
        //Task<States> GetById(int id);
        //Task Create(States entity);
        Task Update(States entity);
        //Task Delete(States entity);
        //Task Save();
        //bool IsStateExists(string name);
    }
}
