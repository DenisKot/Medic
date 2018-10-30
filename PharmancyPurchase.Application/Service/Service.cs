namespace PharmancyPurchase.Application.Service
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

            return instance;
        }

        public virtual void Update(T instance)
        {
            this.repository.Update(instance);
        }

        public virtual void Delete(T instance)
        {
            this.repository.Delete(instance);
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

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> exp)
        {
            return this.repository.GetAllList(exp);
        }
    }
}