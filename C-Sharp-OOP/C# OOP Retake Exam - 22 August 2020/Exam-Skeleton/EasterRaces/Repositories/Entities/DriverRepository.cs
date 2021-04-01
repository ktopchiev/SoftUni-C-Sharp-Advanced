using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> models;

        public DriverRepository()
        {
            Models = new List<IDriver>();
        }

        private List<IDriver> Models { get => models; set => models = value; }

        public void Add(IDriver model)
        {
            if (Models != null && Models.Any(d => d.Name == model.Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriverAlreadyCreated, model.Name));
            }
            else
            {
                Models.Add(model);
            }
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return models.AsReadOnly();
        }

        public IDriver GetByName(string name)
        {
            if (Models != null && !Models.Exists(d => d.Name == name))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, name));
            }

            return Models.FirstOrDefault(d => d.Name == name);
        }

        public bool Remove(IDriver model)
        {
            if (Models != null && Models.Contains(model))
            {
               return Models.Remove(model);
            }

            return false;
        }
    }
}
