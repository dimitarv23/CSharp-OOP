using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Formula1.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private Collection<IRace> races;

        public RaceRepository()
        {
            races = new Collection<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => races;

        public void Add(IRace model)
        {
            races.Add(model);
        }

        public IRace FindByName(string name)
        {
            return races.FirstOrDefault(r => r.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            return races.Remove(model);
        }
    }
}
