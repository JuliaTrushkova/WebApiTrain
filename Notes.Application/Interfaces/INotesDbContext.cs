using Notes.Domain;
using Microsoft.EntityFrameworkCore;

namespace Notes.Application.Interfaces
{
    public interface INotesDbContext
    {
        //collection of all entities or requested type from database 
        DbSet<Note> Notes { get; set; }

        //save changes of context into database
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
