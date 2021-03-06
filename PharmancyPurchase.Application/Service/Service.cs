﻿namespace PharmancyPurchase.Application.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Core;
    using Domain;

    public class Service<T> : IService<T>
        where T: BaseEntity
    {
        private readonly IRepository<T> repository;

        public Service(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual T Create(T instance)
        {
            instance.Id = this.repository.InsertAndGetId(instance);
            repository.SaveChanges();
            return instance;
        }

        public virtual T Save(T instance)
        {
            if (this.repository.FirstOrDefault(x => x.Id == instance.Id) == null)
            {
                instance.Id = this.repository.InsertAndGetId(instance);
                return instance;
            }
            
            this.repository.Update(instance);
            repository.SaveChanges();

            return instance;
        }

        public virtual void Update(T instance)
        {
            if (this.repository.FirstOrDefault(x => x.Id == instance.Id) != null)
            {
                this.repository.Update(instance);
                repository.SaveChanges();
            }
        }

        public virtual void Delete(T instance)
        {
            this.repository.Delete(instance);
            repository.SaveChanges();
        }

        public virtual T Load(int id)
        {
            var instance = this.repository.Get(id);
            return instance;
        }

        public virtual T GetBy(Expression<Func<T, bool>> exp)
        {
            var instance = this.repository.FirstOrDefault(exp);
            return instance;
        }

        public IQueryable<T> GetAll()
        {
            return this.repository.GetAll();
        }

        public IEnumerable<T> GetList()
        {
            return this.repository.GetAllList();
        }

        public IEnumerable<T> GetList(params Expression<Func<T, object>>[] propertySelectors)
        {
            return this.repository.GetAllIncluding(propertySelectors);
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> exp)
        {
            return this.repository.GetAllList(exp);
        }
    }
}