using ELibraryProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryProject.Model.Entities
{
    public class Author : BaseEntity
    {
        public string AuthorName {  get; set; }
        public string AuthorSutname { get; set; }
        public string DateOfBirth { get; set; }
        public ICollection<Book> Books { get; set; }

    }
}
