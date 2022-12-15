using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heros;

        public HeroRepository()
        {
            this.heros = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => heros.AsReadOnly();

        public void Add(IHero model)
        {
            heros.Add(model);
        }

        public IHero FindByName(string name)
        {
            return heros.FirstOrDefault(h => h.Name == name);
        }

        public bool Remove(IHero model)
        {
            return heros.Remove(model);
        }
    }
}
