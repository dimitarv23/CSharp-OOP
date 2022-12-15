using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<Knight> knights = new List<Knight>();
            List<Barbarian> barbarians = new List<Barbarian>();

            foreach (var player in players)
            {
                if (player.GetType().Name == nameof(Knight))
                {
                    knights.Add(player as Knight);
                }
                else if (player.GetType().Name == nameof(Barbarian))
                {
                    barbarians.Add(player as Barbarian);
                }
            }

            int knightCasualties = 0;
            int barbarianCasualties = 0;

            while (knights.Count > knightCasualties && barbarians.Count > barbarianCasualties)
            {
                foreach (Knight knight in knights.Where(k => k.IsAlive))
                {
                    foreach (Barbarian barbarian in barbarians.Where(b => b.IsAlive))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());

                        if (!barbarian.IsAlive)
                        {
                            barbarianCasualties++;
                        }
                    }
                }

                foreach (Barbarian barbarian in barbarians.Where(b => b.IsAlive))
                {
                    foreach (Knight knight in knights.Where(k => k.IsAlive))
                    {
                        knight.TakeDamage(barbarian.Weapon.DoDamage());

                        if (!knight.IsAlive)
                        {
                            knightCasualties++;
                        }
                    }
                }
            }

            if (knights.Count > knightCasualties)
            {
                return $"The knights took {knightCasualties} casualties but won the battle.";
            }
            else
            {
                return $"The barbarians took {barbarianCasualties} casualties but won the battle.";
            }
        }
    }
}
