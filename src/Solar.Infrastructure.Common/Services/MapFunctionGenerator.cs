using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Solar.Infrastructure.Common.Extensions;
using Solar.Infrastructure.Common.Services.Exceptions;

namespace Solar.Infrastructure.Common.Services
{
    internal static class MapFunctionGenerator<TSource, TTarget>
        where TSource : class
        where TTarget : class, new()
    {
        private static readonly Type SourceType = typeof(TSource);
        private static readonly Type TargetType = typeof(TTarget);

        private static ConstructorInfo TargetTypeConstructor
        {
            get
            {
                var targetConstructor = TargetType.GetConstructor(new Type[0]);
                if (targetConstructor == null)
                {
                    throw new TargetTypeMustHaveConstructorException(TargetType);
                }
                return targetConstructor;
            }
        }

        private static IEnumerable<AssignmentPropertiesMethods> AssignementPropertiesPairs
        {
            get
            {
                var sourceProperties = SourceType.GetPublicProperties();
                var targetProperties = TargetType.GetPublicProperties().ToList();
                return
                    from sp in sourceProperties
                    let tp = targetProperties.FirstOrDefault(tp => tp.Name == sp.Name && tp.PropertyType == sp.PropertyType)
                    where tp != null
                    select new AssignmentPropertiesMethods
                    {
                        SourcePropertyGetter = sp.GetGetMethod(),
                        TargetPropertySetter = tp.GetSetMethod()
                    };
            }
        }

        public static Func<TSource, TTarget> Generate()
        {
            var dynamicMethod = new DynamicMethod("MappingMethod", typeof(TTarget), new Type[] { typeof(TSource) });
            var ilGenerator = dynamicMethod.GetILGenerator();
            GenerateParameters(dynamicMethod);
            GenerateMapMethodBody(ilGenerator);
            return (Func<TSource, TTarget>) dynamicMethod.CreateDelegate(typeof(Func<TSource, TTarget>));
        }

        private static void GenerateParameters(DynamicMethod dynamicMethod)
        {
            dynamicMethod.DefineParameter(1, ParameterAttributes.None, "source");
        }

        private static void GenerateMapMethodBody(ILGenerator generator)
        {
            var locResult = generator.DeclareLocal(TargetType);
            GenerateResultInstance(generator, locResult);
            GeneratePropertiesMapping(generator, locResult);
            GenerateReturnStatement(generator, locResult);
        }

        private static void GenerateResultInstance(ILGenerator generator, LocalBuilder locResult)
        {
            generator.Emit(OpCodes.Newobj, TargetTypeConstructor);
            generator.Emit(OpCodes.Stloc, locResult);
        }

        private static void GeneratePropertiesMapping(ILGenerator generator, LocalBuilder methodResult)
        {
            foreach (var pair in AssignementPropertiesPairs)
            {
                generator.Emit(OpCodes.Ldloc, methodResult);
                generator.Emit(OpCodes.Ldarg, 0);
                generator.Emit(OpCodes.Callvirt, pair.SourcePropertyGetter);
                generator.Emit(OpCodes.Callvirt, pair.TargetPropertySetter);
            }
        }

        private static void GenerateReturnStatement(ILGenerator generator, LocalBuilder locResult)
        {
            generator.Emit(OpCodes.Ldloc, locResult);
            generator.Emit(OpCodes.Ret);
        }

        private class AssignmentPropertiesMethods
        {
            public MethodInfo SourcePropertyGetter { get; set; }

            public MethodInfo TargetPropertySetter { get; set; }
        }
    }
}