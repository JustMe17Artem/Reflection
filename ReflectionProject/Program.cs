using System;
using ClassLibrary;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReflectionProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Speed:");
            int speed = Int32.Parse(Console.ReadLine());

            Car car = new Car (name, speed);

            var results = new List<ValidationResult>();
            var context = new ValidationContext(car);
            if (!Validator.TryValidateObject(car, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }



            bool car1IsValid = ValidateCar(car);
            //bool car2IsValid = ValidateCar(car2);
            
            //Console.WriteLine("car" + car.Name + "is valid:" + s );
            //    Console.WriteLine($"car {car2.Name} is valid: {car2IsValid}");
        }
        static bool ValidateCar(Car car)
        {
            Type t = typeof(Car);
            object[] attrs = t.GetCustomAttributes(false);
            foreach (SpeedValidationAttribute attr in attrs)
            {
                return attr.Test(car.MaxSpeed);
            }
            return true;
        }

    }
}
