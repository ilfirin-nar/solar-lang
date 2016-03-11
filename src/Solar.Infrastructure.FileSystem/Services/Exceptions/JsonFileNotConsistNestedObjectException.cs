using System;
using Solar.Infrastructure.Common.Exceptions;

namespace Solar.Infrastructure.FileSystem.Services.Exceptions
{
    public class JsonFileNotConsistNestedObjectException : SolarException
    {
        private readonly string _typeName;
        private readonly string _jsonFilePath;

        public JsonFileNotConsistNestedObjectException(string jsonFilePath, Type type)
        {
            _jsonFilePath = jsonFilePath;
            _typeName = type.Name;
        }

        public override string Message => $"JSON file `{_jsonFilePath}` not consists nested object of type `{_typeName}`";
    }
}