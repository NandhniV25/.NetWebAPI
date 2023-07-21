using Microsoft.EntityFrameworkCore;
using NotesAPI.Data;
using NotesAPI.Repository.IRepository;

namespace NotesAPI.Repository
{
    public class NotesRepository : INotesRepository
    {
        //Database Connection
        private readonly ApplicationDbContext _dbContext;

        //Constructor
        public NotesRepository(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        //Interface Implementation
        public async Task Create(Notes entity)
        {
            await _dbContext.Notes.AddAsync(entity);
            await Save();
        }

        public async Task Delete(Notes entity)
        {
            _dbContext.Notes.Remove(entity);
            await Save();
        }

        public async Task<List<Notes>> GetAll()
        {
            List<Notes> notes = await _dbContext.Notes.ToListAsync();
            return notes;
        }

        public async Task<Notes> GetById(int id)
        {
            Notes notes = await _dbContext.Notes.FindAsync(id);
            return notes;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Notes entity)
        {
            _dbContext.Notes.Update(entity);
            await Save();
        }
    }
}
