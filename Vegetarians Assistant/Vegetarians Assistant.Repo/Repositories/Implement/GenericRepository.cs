﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vegetarians_Assistant.Repo.Entity;
using Vegetarians_Assistant.Repo.Repositories.Interface;

namespace Vegetarians_Assistant.Repo.Repositories.Implement
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly VegetariansAssistantV3Context context;

        private readonly DbSet<TEntity> dbSet;
        public GenericRepository(VegetariansAssistantV3Context context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async Task DeleteAsync(object id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);
            await DeleteAsync(entityToDelete);
        }

        public async Task DeleteAsync(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await dbSet.Where(expression).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            int? pageIndex = null,
            int? pageSize = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (pageIndex.HasValue && pageSize.HasValue)
            {
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 12;

                query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }

            return await query.ToListAsync();
        }


        public async Task<TEntity> GetByIDAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }


        public async Task InsertAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
            }
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.CountAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(
    Expression<Func<TEntity, bool>> filter,
    params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Thêm Include cho các bảng liên kết
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }
    }
}
