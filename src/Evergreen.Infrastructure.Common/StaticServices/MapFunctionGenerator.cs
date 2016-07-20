using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Evergreen.Infrastructure.Common.Extensions;

namespace Evergreen.Infrastructure.Common.StaticServices
{
    internal static class MapFunctionGenerator
    {
        public static Action<TSource, TTarget> Generate<TSource, TTarget>()
            where TTarget : class, new()
        {
            var dynamicMethod = GetDynamicMethod(typeof(TSource), typeof(TTarget));
            return (Action<TSource, TTarget>) dynamicMethod.CreateDelegate(typeof(Action<TSource, TTarget>));
        }

        public static Action<object, object> Generate(Type sourceType, Type targetType)
        {
            var dynamicMethod = GetDynamicMethod(sourceType, targetType);
            return (source, target) =>
            {
                var parameters = new[]
                {
                    Convert.ChangeType(source, sourceType),
                    Convert.ChangeType(target, targetType)
                };
                dynamicMethod.Invoke(null, parameters);
            };
        }

        private static DynamicMethod GetDynamicMethod(Type sourceType, Type targetType)
        {
            var dynamicMethod = new DynamicMethod("MappingMethod", null, new[] { sourceType, targetType });
            var ilGenerator = dynamicMethod.GetILGenerator();
            GenerateParameters(dynamicMethod);
            GenerateMapMethodBody(ilGenerator, sourceType, targetType);
            GenerateReturnStatement(ilGenerator);
            return dynamicMethod;
        }

        private static void GenerateParameters(DynamicMethod dynamicMethod)
        {
            dynamicMethod.DefineParameter(1, ParameterAttributes.None, "source");
            dynamicMethod.DefineParameter(2, ParameterAttributes.None, "target");
        }

        private static void GenerateMapMethodBody(ILGenerator generator, Type sourceType, Type targetType)
        {
            foreach (var pair in GetAssignementPropertiesPairs(sourceType, targetType))
            {
                generator.Emit(OpCodes.Ldarg, 1);
                generator.Emit(OpCodes.Ldarg, 0);
                generator.Emit(OpCodes.Callvirt, pair.SourcePropertyGetter);
                generator.Emit(OpCodes.Callvirt, pair.TargetPropertySetter);
            }
        }

        private static void GenerateReturnStatement(ILGenerator generator)
        {
            generator.Emit(OpCodes.Ret);
        }

        private static IEnumerable<AssignmentPropertiesMethods> GetAssignementPropertiesPairs(Type sourceType, Type targetType)
        {
            var sourceProperties = sourceType.GetPublicProperties();
            var targetProperties = targetType.GetPublicProperties();
            return
                from sp in sourceProperties
                let tp = targetProperties.FirstOrDefault(tp => IsMappableProperty(tp, sp))
                where tp != null
                select new AssignmentPropertiesMethods
                {
                    SourcePropertyGetter = sp.GetGetMethod(),
                    TargetPropertySetter = tp.GetSetMethod()
                };
        }

        private static bool IsMappableProperty(PropertyInfo tp, PropertyInfo sp)
        {
            return tp.Name == sp.Name && tp.PropertyType == sp.PropertyType;
        }

        private class AssignmentPropertiesMethods
        {
            public MethodInfo SourcePropertyGetter { get; set; }

            public MethodInfo TargetPropertySetter { get; set; }
        }
    }
}
