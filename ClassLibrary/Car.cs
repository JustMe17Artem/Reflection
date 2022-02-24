using System;

namespace ClassLibrary
{
    public class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int Power { get; set; }
        public int HoldingPeriod { get; set; }

        public Car(string name, int speed, int power, int holdingPeriod)
        {
            Name = name;
            Speed = speed;
            Power = power;
            HoldingPeriod = holdingPeriod;
        }
        public Car()
        {
            
        }
        public void StartEngine()
        {
            Console.WriteLine("Вжух, двигатель заведён");
        }
        public void Drive()
        {
            StartEngine();
            Console.WriteLine($"Машина {Name} едет со скоростью {Speed} км/ч");
        }
        public double TaxCalculation(int rate)
        {
            return rate*Power*(HoldingPeriod/12);
        }
    }
}
