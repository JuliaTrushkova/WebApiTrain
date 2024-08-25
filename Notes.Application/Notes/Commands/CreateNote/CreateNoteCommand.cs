using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.CreateNote
{
    //IRequest marks the result of running this command and return the result of this command
    //What is needed for creating a note
    public class CreateNoteCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; } 
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
