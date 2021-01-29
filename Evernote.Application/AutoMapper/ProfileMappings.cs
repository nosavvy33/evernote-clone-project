using AutoMapper;
using Evernote.Domain.Models;
using Evernote.Domain.ValueObjects;

namespace Evernote.Application.AutoMapper
{
    public class ProfileMappings : Profile
    {
        public ProfileMappings() 
        {
            CreateMap<Note, NoteDTO>().ReverseMap();
        }
    }
}
