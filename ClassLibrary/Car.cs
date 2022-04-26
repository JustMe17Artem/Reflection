using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Text.Unicode;
using System.Text;
using System.Text.Encodings.Web;

namespace ClassLibrary
{
    public class SpeedValidationAttribute : Attribute
    {
        int minSpeed;
        int maxSpeed;

        public SpeedValidationAttribute(int min, int max)
        {
            minSpeed = min;
            maxSpeed = max;
        }

        public bool Test(int speed)
        {
            return speed >= minSpeed && speed <= maxSpeed;
        }
    }

    public class Car
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        //[JsonPropertyName("Name")]
        public string Name { get; set; }

        [Required]
        [Range(50, 400)]
        //[JsonPropertyName("MaxSpeed")]
        public int MaxSpeed { get; set; }

        public Car(string name, int speed)
        {
            Name = name;
            MaxSpeed = speed;
        }
        public Car()
        {

        }

        private static string jsonString = @"C:\Users\ИМЕННО ОН\Desktop\Cars.json";

        public static string readString = File.ReadAllText(jsonString);
        public static List<Car> cars { get; private set; } = JsonSerializer.Deserialize<List<Car>>(readString);

        
        public static void WriteToJson(Car car)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            cars.Add(car);
            var json = JsonSerializer.Serialize(cars.ToArray(), options);
            File.WriteAllText(jsonString, json);
        }
        
        public void StartEngine()
        {
            Console.WriteLine("Вжух, двигатель заведён");
        }
        public void Drive()
        {
            StartEngine();
            Console.WriteLine($"Машина {Name} едет со скоростью {MaxSpeed} км/ч");
        }
        
    }
}
