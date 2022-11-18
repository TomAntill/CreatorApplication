using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatorApplication.Common
{
    public class Guards
    {
        public static void EntityIsNotNull<T>(object obj, int? lookUpId)
        {
            if (obj == null)
                throw new EntityNotFoundException(lookUpId.HasValue ? $"No entity of type {typeof(T).Name} found for id {lookUpId.Value}"
                    : $"No entity of type {typeof(T).Name} found");
        }

        public static void EntityLength(string entity, int length)
        {
            if (entity.Length < length)
                throw new EntityLengthException($"{entity} length is less than {length}");
        }
        public static void IngredientListNotEmpty<T>(List<T> list)
        {
            if (list.Count() == 0)
                throw new IngredientListNotEmptyException($"IngredientList cannot be empty");
        }
    }
}
