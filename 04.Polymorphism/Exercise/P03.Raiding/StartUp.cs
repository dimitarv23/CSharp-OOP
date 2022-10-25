using System;
using System.Collections.Generic;

namespace P03.Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HeroFactory factory = new ConcreteHeroFactory();
            List<BaseHero> heroes = new List<BaseHero>(n);

            while (heroes.Count < n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    BaseHero hero = factory.GetHero(heroName, heroType);
                    heroes.Add(hero);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int totalPower = 0;

            foreach (var hero in heroes)
            {
                var currHeroPower = hero.Power;
                totalPower += currHeroPower;

                Console.WriteLine(hero.CastAbility());
            }

            if (totalPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
