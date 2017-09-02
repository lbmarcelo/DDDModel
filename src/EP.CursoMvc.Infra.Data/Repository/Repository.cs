using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EP.CursoMvc.Domain.Interfaces;
using EP.CursoMvc.Domain.Models;
using EP.CursoMvc.Infra.Data.Context;

namespace EP.CursoMvc.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected CursoMvcContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(CursoMvcContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var retEnt = DbSet.Add(obj);
            return retEnt;
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> ObterTodosPaginado(int s, int t)
        {
            return DbSet.Skip(s).Take(t).ToList();
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            return obj;
        }

        public virtual void Remover(Guid id)
        {
            var obj = new TEntity(){Id = id};
            DbSet.Remove(obj);
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}