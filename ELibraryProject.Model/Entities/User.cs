using ELibraryProject.Core.Entity;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryProject.Model.Entities
{
    public class User :BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public bool isEnabled { get; set; }
        public DateTime RecordDate { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
