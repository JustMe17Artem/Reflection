using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace ClassLibrary
{
    [AttributeUsage(AttributeTargets.All)]
    public class AllAttribute : Attribute
    {
    }

    [All]
    class Usage
    {
        [All] // на метод
        [return: All] // на возвращаемое методом значение
        public int GiveMeInt<[All]T>([All] int param)
        {
            return 5 + param;
        }
        [All] // на событие
        [field: All] // на сгенерированное поле делегата для этого события
        public event Action Event;

        [All] // на свойство
        [field: All] // на сгенерированное поле для этого свойства
        public int Action { get; set; }

    }
}
