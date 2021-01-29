using Evernote.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Evernote.API.Data
{
    public class EvernoteDbContext : DbContext
    {
        public EvernoteDbContext(DbContextOptions options) : base(options) 
        {
        }
    
        public DbSet<Note> Notes { get; set; }
    }
}
