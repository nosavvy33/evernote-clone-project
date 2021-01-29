using AutoMapper;
using Evernote.Domain.IRepositories;
using Evernote.Domain.IServices;
using Evernote.Domain.Models;
using Evernote.Domain.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evernote.Infrastructure.Services.Notes
{
    public class NotesService : INotesService
    {
        private readonly INotesRepository NotesRepository;
        private readonly IMapper Mapper;

        public NotesService(INotesRepository notesRepository, IMapper mapper) 
        {
            this.NotesRepository = notesRepository;
            this.Mapper = mapper;
        }

        public async Task<NoteDTO> Create(NoteDTO note) =>
            this.Mapper.Map<NoteDTO>(await this.NotesRepository.AddAsync(this.Mapper.Map<Note>(note)));

        public async Task<IEnumerable<NoteDTO>> ListAll() => this.Mapper.Map<List<NoteDTO>>(await this.NotesRepository.GetAll());
    }
}
