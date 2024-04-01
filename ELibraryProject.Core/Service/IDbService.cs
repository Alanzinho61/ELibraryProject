using ELibraryProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryProject.Core.Service
{
    //Generic yapi icin metotlar imzalandi
     public interface IDbService<T> where T: BaseEntity  
     {
        bool Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        List<T> GetAll();
        T Get(int id);
        bool save();
        T find(int id);
     }
}
