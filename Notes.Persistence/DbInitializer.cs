using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Persistence
{
    public class DbInitializer
    {
        //Check if Db is created or create Db according to our DbContext
        public static void Initialize(NotesDbContext notesDbContext) 
        {
            notesDbContext.Database.EnsureCreated();
        }
    }
}
