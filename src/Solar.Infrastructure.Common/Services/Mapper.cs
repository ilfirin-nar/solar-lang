using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Solar.Infrastructure.Common.Extensions;
using Solar.Infrastructure.Common.Services.Exceptions;

namespace Solar.Infrastructure.Common.Services
{
    internal class Mapper<TSource, TTarget> : IMapper<TSource, TTarget>
        where TSource : class, new()
        where TTarget : class, new()
    {
        private delegate TTarget MapMethod(TSource source);

        private static readonly Type SourceType;
        private static readonly Type TargetType;
        private static readonly MapMethod DoMap;

        static Mapper()
        {
            SourceType = typeof(TSource);
            TargetType = typeof(TTarget);
            DoMap = GenerateMapMethod();
        }

        public TTarget Map(TSource source)
        {
            return DoMap(source);
        }

        private static MapMethod GenerateMapMethod()
        {
            var dynamicMethod = new DynamicMethod("MappingMethod", typeof(TTarget), new Type[] { typeof(TSource) });
            var ilGenerator = dynamicMethod.GetILGenerator();
            var parameter = dynamicMethod.DefineParameter(1, ParameterAttributes.None, "source");
            var propertiesDictionary = GetSourceTypePropertiesDictionary();

            GenerateMapMethodBody(ilGenerator, parameter, propertiesDictionary);

            return (MapMethod)dynamicMethod.CreateDelegate(typeof(MapMethod));
        }

        private static IReadOnlyList<string> GetSourceTypePropertiesDictionary()
        {
            var sourceProperties = SourceType.GetPublicProperties();
            var targetProperties = TargetType.GetPublicProperties().ToList();
            return (
                from sp in sourceProperties
                select targetProperties.FirstOrDefault(tp => tp.Name == sp.Name && tp.PropertyType == sp.PropertyType)
                into matchingTargetProperty
                where matchingTargetProperty != null
                select matchingTargetProperty.Name).ToList();
        }

        private static void GenerateMapMethodBody(ILGenerator generator, ParameterBuilder prmSource, IReadOnlyList<string> properties)
        {
            var targetConstructor = TargetType.GetConstructor(new Type[0]);

           if (targetConstructor == null)
           {
               throw new TargetTypeMustHaveConstructorException(TargetType);
           }

            var locResult = generator.DeclareLocal(TargetType);

            // result = new TOut();
            generator.Emit(OpCodes.Newobj, targetConstructor);
            generator.Emit(OpCodes.Stloc, locResult);

            foreach (var property in properties)
            {
                var methodSource = SourceType.GetProperty(property).GetGetMethod();
                var methodTarget = TargetType.GetProperty(property).GetSetMethod();

                // result.methodTarget = source.methodSrc;
                generator.Emit(OpCodes.Ldloc, locResult);
                generator.Emit(OpCodes.Ldarg, prmSource.Position - 1);
                generator.Emit(OpCodes.Callvirt, methodSource);
                generator.Emit(OpCodes.Conv_R8);
                generator.Emit(OpCodes.Callvirt, methodTarget);
            }

            // return result;
            generator.Emit(OpCodes.Ldloc, locResult);
            generator.Emit(OpCodes.Ret);
        }
    }
}