﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

        private DbSet<TEntity> iDBSet;



        //////////
        ///Methods
        //////////




        public void Add(TEntity pEntity)
        {
            iDBSet.Add(pEntity);
            iDbContext.SaveChanges();
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