using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;

        public Controller()
        {
            this.booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int currId = this.booths.Models.Count + 1;

            IBooth booth = new Booth(currId, capacity);
            this.booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, currId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (cocktailTypeName != nameof(Hibernation) &&
                cocktailTypeName != nameof(MulledWine))
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (booth.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            ICocktail cocktail;

            if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else
            {
                cocktail = new MulledWine(cocktailName, size);
            }

            booth.CocktailMenu.AddModel(cocktail);
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (delicacyTypeName != nameof(Gingerbread) &&
                delicacyTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            if (booth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            IDelicacy delicacy;

            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else
            {
                delicacy = new Stolen(delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicacy);
            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            double currBill = booth.CurrentBill;

            booth.Charge();
            booth.ChangeStatus();

            var sb = new StringBuilder();

            sb.AppendLine($"Bill {currBill:f2} lv");
            sb.AppendLine(string.Format(OutputMessages.BoothIsAvailable, boothId));

            return sb.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            List<IBooth> boothsAvailable = this.booths.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .ToList();

            if (!boothsAvailable.Any())
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            IBooth firstBooth = boothsAvailable.First();
            firstBooth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, firstBooth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            string[] itemInfo = order.Split('/', StringSplitOptions.RemoveEmptyEntries);
            string itemTypeName = itemInfo[0];
            string itemName = itemInfo[1];
            int unitsCount = int.Parse(itemInfo[2]);

            if (itemInfo.Length == 4)
            {
                //The item is a cocktail
                string cocktailSize = itemInfo[3];

                if (itemTypeName != nameof(Hibernation) &&
                    itemTypeName != nameof(MulledWine))
                {
                    return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
                }

                if (!booth.CocktailMenu.Models.Any(c => c.Name == itemName))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                if (!booth.CocktailMenu.Models.Any(c => c.GetType().Name == itemTypeName
                        && c.Name == itemName && c.Size == cocktailSize))
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, cocktailSize, itemName);
                }

                ICocktail cocktail;

                if (itemTypeName == nameof(Hibernation))
                {
                    cocktail = new Hibernation(itemName, cocktailSize);
                }
                else
                {
                    cocktail = new MulledWine(itemName, cocktailSize);
                }

                booth.UpdateCurrentBill(cocktail.Price * unitsCount);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, unitsCount, itemName);
            }
            else
            {
                //The item is a delicacy

                if (itemTypeName != nameof(Gingerbread) &&
                    itemTypeName != nameof(Stolen))
                {
                    return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
                }

                if (!booth.DelicacyMenu.Models.Any(d => d.Name == itemName))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                if (!booth.DelicacyMenu.Models.Any(d => d.GetType().Name == itemTypeName && d.Name == itemName))
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);
                }

                IDelicacy delicacy;

                if (itemTypeName == nameof(Gingerbread))
                {
                    delicacy = new Gingerbread(itemName);
                }
                else
                {
                    delicacy = new Stolen(itemName);
                }

                booth.UpdateCurrentBill(delicacy.Price * unitsCount);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, unitsCount, itemName);
            }
        }
    }
}
