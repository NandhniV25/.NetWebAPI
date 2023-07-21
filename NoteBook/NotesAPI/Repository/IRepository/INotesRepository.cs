namespace NotesAPI.Repository.IRepository
{
    public interface INotesRepository
    {
        //Method Definition
        Task<List<Notes>> GetAll();

        Task<Notes> GetById(int id);

        Task Create(Notes entity);

        Task Update(Notes entity);

        Task Delete(Notes entity);

        Task Save();
    }
}
