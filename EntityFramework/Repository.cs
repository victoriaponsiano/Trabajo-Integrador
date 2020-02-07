using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Trabajo_Integrador.EntityFramework
{
    public abstract class Repository<TEntity, TDbContext>
            where TEntity : class
            where TDbContext : DbContext
    {
        ////////////
        ///Atributes
        ////////////
        private readonly TDbContext iDbContext;

        protected DbSet<TEntity> iDBSet;



        //////////
        ///Methods
        //////////




        public void Add(TEntity pEntity)
        {
            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges
                iDBSet.Add(pEntity);
                iDbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                
                throw;
            }
        }

        public void Remove(TEntity pEntity)
        {
            iDBSet.Remove(pEntity);
            iDbContext.SaveChanges();
        }

        public TEntity Get(int pId)
        {
            return this.iDBSet.Find(pId);
        }
        public TEntity Get(string pId)
        {
            return this.iDBSet.Find(pId);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.iDBSet.ToList();
        }

       






        //////////
        ///Constructor
        //////////
        public Repository(TDbContext pContext)
        {
            iDbContext = pContext;
            this.iDBSet = iDbContext.Set<TEntity>();
        }
    }
}
