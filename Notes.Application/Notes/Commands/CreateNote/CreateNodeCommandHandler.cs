using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.CreateNote
{
    //CreateNoteCommand - type of request
    //Guid - type of response
    //CreateNodeCommandHandler - based on info of needed for creating a note contains the logic of creating a note
    public class CreateNodeCommandHandler
        :IRequestHandler<CreateNoteCommand, Guid>
    {
        //For save changes to database
        private readonly INotesDbContext _dbContext;

        //Injection of dependency to database context on this class using constructor
        public CreateNodeCommandHandler(INotesDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle (CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                Id = Guid.NewGuid(),
                Creationdate = DateTime.Now,
                EditDate = null
            };

            await _dbContext.Notes.AddAsync(note, cancellationToken); //save to context
            await _dbContext.SaveChangesAsync(cancellationToken); //save to database

            return note.Id;
        }
    }
}
