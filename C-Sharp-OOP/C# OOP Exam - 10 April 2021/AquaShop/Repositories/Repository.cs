using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        public IReadOnlyCollection<T> Models => throw new NotImplementedException();

        public void Add(T model)
        {
            throw new NotImplementedException();
        }

        public T FindByType(string type)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T model)
        {
            throw new NotImplementedException();
        }
    }
}
