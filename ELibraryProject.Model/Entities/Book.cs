using ELibraryProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ELibraryProject.Model.Entities
{
    public class Book : BaseEntity
    {
        public string BookName { get; set; }
        public int Page { get; set; }
        public int BookStock { get; set; } = 0;
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int CategoryId {get; set;}
        public Category Category { get; set; }

    }
}
