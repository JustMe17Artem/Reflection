using System;
using System.Reflection;



namespace Reflection_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string dllName = @"C:\Users\ИМЕННО ОН\source\repos\ReflectionProject\ClassLibrary\bin\Debug\netcoreapp3.1\ClassLibrary";
            Assembly asm = Assembly.LoadFrom(dllName);
            Type type = asm.GetType("ClassLibrary.Car", true, true);
            Console.WriteLine($"Type: {type.AssemblyQualifiedName}");
            
            Console.WriteLine($"Members:");
            foreach (MemberInfo memberInfo in type.GetMembers())
            {
                Console.WriteLine($"    {memberInfo.DeclaringType} {memberInfo.MemberType} {memberInfo.Name}");
               
            }
            Console.WriteLine($"Methods:");
            foreach (MethodInfo method in type.GetMethods())
            {
                Console.Write($"    {method.ReturnType} {method.Name} (");
                foreach (ParameterInfo param in method.GetParameters())
                {
                    Console.Write($"{param.ParameterType.Name} {param.Name}, ");
                }
                Console.WriteLine(")");
            }
            object car = Activator.CreateInstance(type, "Volvo", 150, 100, 12);

            MethodInfo methodDrive = type.GetMethod("Drive");
            methodDrive.Invoke(car, new object[] { });

            MethodInfo methodTaxCalc = type.GetMethod("TaxCalculation");
            double sum = (double)methodTaxCalc.Invoke(car, new object[] {12});
            Console.WriteLine("Сумма транспортного налога:" + sum + "руб");


            ConstructorInfo carConstructor = type.GetConstructor(new Type[] {  });
            var newCar = carConstructor.Invoke(new object[] { });
            Console.WriteLine("Констурктор  " + ((carConstructor == null) ? "не найден" : "найден"));
            var propertySpeed = type.GetProperty("Speed");
            var propertyName= type.GetProperty("Name");
            propertyName.SetValue(newCar, "BMW");
            propertySpeed.SetValue(newCar, 111);
            Console.WriteLine(propertyName.GetValue(newCar));
            Console.WriteLine(propertySpeed.GetValue(newCar));
        }

    }
    
}
