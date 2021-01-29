using Evernote.API.Data;
using Evernote.Domain.IRepositories;
using Evernote.Domain.Models;
using Evernote.Infrastructure.Repositories;

namespace Evernote.APIClone.Repositories.Notes
{
    public class NotesRepository : GenericRepository<Note> , INotesRepository
    {
        private readonly EvernoteDbContext DbContext;
        public NotesRepository(EvernoteDbContext dbContext) : base(dbContext)
        {
            this.DbContext = dbContext;
        }

    }
}
