using System;
using System.Threading;

namespace P01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));

            string[] truckInfo = Console.ReadLine().Split();
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int numOfCommands = int.Parse(Console.ReadLine());

            for (int cmd = 0; cmd < numOfCommands; cmd++)
            {
                string[] command = Console.ReadLine().Split();
                string action = command[0];
                string vehicle = command[1];

                try
                {
                    if (action == "Drive")
                    {
                        if (vehicle == "Car")
                        {
                            Console.WriteLine(car.Drive(double.Parse(command[2])));
                        }
                        else if (vehicle == "Truck")
                        {
                            Console.WriteLine(truck.Drive(double.Parse(command[2])));
                        }
                    }
                    else if (action == "Refuel")
                    {
                        if (vehicle == "Car")
                        {
                            car.Refuel(double.Parse(command[2]));
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Refuel(double.Parse(command[2]));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
