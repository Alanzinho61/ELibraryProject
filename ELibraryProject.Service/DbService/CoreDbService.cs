using ELibraryProject.Core.Entity;
using ELibraryProject.Core.Service;
using ELibraryProject.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryProject.Service.DbService
{

    //Core katmaninda imzalanan metodlarin icerisini burada yuani servis katmanimizda imzaliyoruz
    public class CoreDbService<T> : IDbService<T> where T : BaseEntity
    {
        private readonly ELibraryContext _db;
        public CoreDbService(ELibraryContext db)
        {
            _db = db;     
        }
        public bool Add(T entity)
        {
            _db.Set<T>().Add(entity);
            save();
            return true;
        }

        public bool Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            save(); 
            return true;
        }

        public T find(int id)
        {
            try
            {
                return (_db.Set<T>().Find(id));
            }
            catch (Exception)
            {
                
                throw new Exception("Kayit bulunamadi");
            }
            
        }

        public T Get(int id)
        {
            try
            {
                return _db.Set<T>().Find(id);
            }
            catch (Exception)
            {

                throw new Exception("Kayit bulunamadi");
            }
            
        }

        public List<T> GetAll() =>_db.Set<T>().ToList(); 

        public bool save()
        {
            return(_db.SaveChanges() >0 ? true : false );
        }

        public bool Update(T entity)
        {
            try
            {
                _db.Set<T>().Update(entity);
                save();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }
    }
}
