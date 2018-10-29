namespace PharmancyPurchase.Application.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain;

    public interface IService<T> where T : BaseEntity
    {
        T Create(T instance);

        void Update(T instance);

        T Save(T instance);

        void Delete(T instance);

        T Load(int id);

        T GetBy(Expression<Func<T, bool>> exp);

        IQueryable<T> Query();

        IEnumerable<T> GetAll();

        IEnumerable<T> FindBy(Expression<Func<T, bool>> exp);
    }
}