using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Formula1.Repositories.Entities
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private Collection<IFormulaOneCar> cars;

        public FormulaOneCarRepository()
        {
            cars = new Collection<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => cars;

        public void Add(IFormulaOneCar model)
        {
            cars.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return cars.FirstOrDefault(c => c.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return cars.Remove(model);
        }
    }
}
