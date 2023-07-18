using Microsoft.EntityFrameworkCore;
using World.API.Data;
using World.API.DTO.States;
using World.API.Models;
using World.API.Repository.IRepository;

namespace World.API.Repository
{
    public class StatesRepository : GenericRepository<States>, IStatesRepository
    {
        //Database Connection
        private readonly ApplicationDbContext _dbContext;

        //Constructor
        public StatesRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        //Method 
        //Interface Implementation
        //public async Task Create(States entity)
        //{
        //    await _dbContext.States.AddAsync(entity);
        //    await Save();
        //}

        //public async Task Delete(States entity)
        //{
        //    _dbContext.States.Remove(entity);
        //    await Save();
        //}

        //public async Task<List<States>> GetAll()
        //{
        //    List<States> states = await _dbContext.States.ToListAsync();
        //    return states;
        //}

        //public async Task<States> GetById(int id)
        //{
        //    States states = await _dbContext.States.FindAsync(id);
        //    return states;
        //}

        //public bool IsStateExists(string name)
        //{
        //    var result = _dbContext.States.AsQueryable().Where(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).Any();
        //    return result;
        //}

        //public async Task Save()
        //{
        //    await _dbContext.SaveChangesAsync();
        //}

        public async Task Update(States entity)
        {
            _dbContext.States.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
