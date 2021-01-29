using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Evernote.Domain.ValueObjects
{
    public class NoteDTO
    {
        public NoteDTO() { }

        public NoteDTO(Guid? id, string content)
        {
            Id = id;
            Content = content;
        }

        [JsonIgnore]
        public Guid? Id { get; set; }
        
        [Required]
        public string Content { get; set; }
    }
}
