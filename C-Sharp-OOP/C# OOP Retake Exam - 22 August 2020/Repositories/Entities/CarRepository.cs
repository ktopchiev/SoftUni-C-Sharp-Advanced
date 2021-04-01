﻿using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> cars;
        public CarRepository()
        {
            cars = new List<ICar>();
        }
        public void Add(ICar model)
        {
            this.cars.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return this.cars.ToList();
        }

        public ICar GetByName(string name)
        {
            return cars.FirstOrDefault(c => c.Model == name);
        }

        public bool Remove(ICar model)
        {
            return this.cars.Remove(model);
        }
    }
}
