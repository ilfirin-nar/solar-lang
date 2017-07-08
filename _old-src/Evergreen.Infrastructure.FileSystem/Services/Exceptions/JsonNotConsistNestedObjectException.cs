using System;
using Evergreen.Infrastructure.Common.Exceptions;

namespace Evergreen.Infrastructure.FileSystem.Services.Exceptions
{
    public class JsonNotConsistNestedObjectException : EvergreenException
    {
        private readonly string _typeName;
        private readonly string _jsonString;

        public JsonNotConsistNestedObjectException(string jsonString, Type type)
        {
            _jsonString = jsonString;
            _typeName = type.Name;
        }

        public override string Message => $"JSON `{_jsonString}` not consists nested object of type `{_typeName}`";
    }
}