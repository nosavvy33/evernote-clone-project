using Evernote.Domain.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evernote.Domain.IServices
{
    public interface INotesService
    {
        Task<IEnumerable<NoteDTO>> ListAll();
        Task<NoteDTO> Create(NoteDTO note);
    }
}
