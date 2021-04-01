using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public CarRepository()
        {
            Models = new List<ICar>();
        }

        private List<ICar> Models { get => models; set => models = value; }

        public void Add(ICar model)
        {
            if (Models != null && Models.Any(d => d.Model == model.Model))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarAlreadyCreated, model.Model));
            }
            else
            {
                Models.Add(model);
            }
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return Models.AsReadOnly();
        }

        public ICar GetByName(string name)
        {
            if (Models != null && !Models.Exists(car => car.Model == name))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarNotFound, name));
            }

            return Models.FirstOrDefault(car => car.Model == name);
        }

        public bool Remove(ICar model)
        {
            if (Models != null && Models.Contains(model))
            {
                return Models.Remove(model);
            }

            return false;
        }
    }
}
