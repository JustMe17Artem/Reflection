using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

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
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId _id;
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(20, 400)]
        public int MaxSpeed { get; set; }


        public Car(string name, int speed)
        {
            Name = name;
            MaxSpeed = speed;
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
