using System;
using System.Reflection;


namespace Reflection_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string dllName = @"C:\Users\ИМЕННО ОН\source\repos\LEISURECore\LEISURECore\bin\Debug\LEISURECore";
            Assembly asm = Assembly.LoadFrom(dllName);
            Type type = asm.GetType("LEISURECore.DataAccess", true, true);
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

        }

    }
    
}
