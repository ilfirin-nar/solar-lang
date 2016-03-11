using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Solar.Infrastructure.FileSystem.Services.Exceptions;

namespace Solar.Infrastructure.FileSystem.Services
{
    internal class JsonFileParser : IJsonFileParser
    {
        private readonly ITextFileReader _fileReader;

        public JsonFileParser(ITextFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public IList<object> ParseNestedObject(string jsonFilePath, IEnumerable<Type> types)
        {
            var json = Parse(jsonFilePath);
            return types.Select(type => ParseNestedObject(jsonFilePath, json, type)).ToList();
        }

        private static object ParseNestedObject(string jsonFilePath, JObject json, Type type)
        {
            var resultJson = json[type.Name];
            if (resultJson == null)
            {
                throw new JsonFileNotConsistNestedObjectException(jsonFilePath, type);
            }
            return resultJson.ToObject(type);
        }

        private JObject Parse(string jsonFilePath)
        {
            var configContent = _fileReader.Read(jsonFilePath);
            return JObject.Parse(configContent);
        }
    }
}