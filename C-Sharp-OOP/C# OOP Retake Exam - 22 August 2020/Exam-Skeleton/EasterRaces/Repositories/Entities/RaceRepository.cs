using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;

        public RaceRepository()
        {
            Models = new List<IRace>();
        }

        private List<IRace> Models { get => models; set => models = value; }

        public void Add(IRace model)
        {
            if (Models != null && Models.Any(d => d.Name == model.Name))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceAlreadyCreated, model.Name));
            }
            else
            {
                Models.Add(model);
            }
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return Models.AsReadOnly();
        }

        public IRace GetByName(string name)
        {
            if (Models != null && !Models.Exists(r => r.Name == name))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, name));
            }

            return Models.FirstOrDefault(r => r.Name == name);
        }

        public bool Remove(IRace model)
        {
            if (Models != null && Models.Contains(model))
            {
                return Models.Remove(model);
            }

            return false;
        }
    }
}
