using System;
using Solar.Infrastructure.Common.Exceptions;

namespace Solar.Infrastructure.FileSystem.Services.Exceptions
{
    public class JsonNotConsistNestedObjectException : SolarException
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