using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion_Utilidad
{
    public static class CustomMapper
    {
        public static TTarget MapTo<TSource, TTarget>(TSource source) where TTarget : new()
        {
            var target = new TTarget();
            var sourceType = typeof(TSource);
            var targetType = typeof(TTarget);

            foreach (var targetProp in targetType.GetProperties())
            {
                // 1. Buscar propiedad directa con el mismo nombre
                var sourceProp = sourceType.GetProperty(targetProp.Name,
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

                if (sourceProp != null &&
                    targetProp.PropertyType.IsAssignableFrom(sourceProp.PropertyType))
                {
                    var value = sourceProp.GetValue(source);
                    targetProp.SetValue(target, value);
                    continue;
                }

                // 2. Buscar en propiedades complejas del source
                foreach (var parentProp in sourceType.GetProperties())
                {
                    // Saltar si no es clase o es string (para no entrar a strings)
                    if (!parentProp.PropertyType.IsClass || parentProp.PropertyType == typeof(string))
                        continue;

                    var nestedValue = parentProp.GetValue(source);
                    if (nestedValue == null) continue;

                    var nestedProp = parentProp.PropertyType.GetProperty(targetProp.Name,
                        BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

                    if (nestedProp != null)
                    {
                        var value = nestedProp.GetValue(nestedValue);
                        if (value != null &&
                            targetProp.PropertyType.IsAssignableFrom(value.GetType()))
                        {
                            targetProp.SetValue(target, value);
                            break;
                        }
                    }
                }
            }

            return target;
        }

    }
}
