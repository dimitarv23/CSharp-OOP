﻿using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Formula1.Repositories.Entities
{
    public class PilotRepository : IRepository<IPilot>
    {
        private Collection<IPilot> pilots;

        public PilotRepository()
        {
            pilots = new Collection<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => pilots;

        public void Add(IPilot model)
        {
            pilots.Add(model);
        }

        public IPilot FindByName(string name)
        {
            return pilots.FirstOrDefault(p => p.FullName == name);
        }

        public bool Remove(IPilot model)
        {
            return pilots.Remove(model);
        }
    }
}
