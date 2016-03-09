using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Solar.Infrastructure.Common.Services
{
    internal class DataMapper<TSource, TTarget> : IDataMapper<TSource, TTarget>
        where TSource : IDataTransferObject
        where TTarget : IDataTransferObject, new()
    {
        private static readonly IReadOnlyDictionary<PropertyInfo, PropertyInfo> MapSourceToTarget;

        static DataMapper()
        {
            MapSourceToTarget = GetMap();
        }

        public TTarget Map(TSource dto)
        {
            var result = new TTarget();
            foreach (var sourceToTargetPair in MapSourceToTarget)
            {
                var value = sourceToTargetPair.Key.GetValue(dto);
                sourceToTargetPair.Value?.SetValue(result, value);
            }
            return result;
        }

        private static IReadOnlyDictionary<PropertyInfo, PropertyInfo> GetMap()
        {
            var sourceProperties = typeof(TSource).GetProperties();
            var targetProperties = typeof(TTarget).GetProperties();
            var result = new Dictionary<PropertyInfo, PropertyInfo>();
            foreach (var targetProperty in targetProperties)
            {
                var sourceProperty = sourceProperties.SingleOrDefault(sp => IsEqual(sp, targetProperty));
                if (sourceProperty == null)
                {
                    continue;
                }
                result.Add(sourceProperty, targetProperty);
            }
            return result;
        }

        private static bool IsEqual(PropertyInfo sp, PropertyInfo targetProperty)
        {
            return sp.Name == targetProperty.Name && sp.PropertyType == targetProperty.PropertyType;
        }
    }
}