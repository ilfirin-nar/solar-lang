using System;
using System.Collections.Generic;
using System.Linq;
using Evergreen.Infrastructure.FileSystem.Services.Exceptions;
using Newtonsoft.Json.Linq;

namespace Evergreen.Infrastructure.FileSystem.Services
{
    internal class JsonFileParser : IJsonFileParser
    {
        private readonly ITextFileReader _fileReader;

        public JsonFileParser(ITextFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public IList<object> ParseNestedObjectFromFile(string jsonFilePath, IEnumerable<Type> types)
        {
            var jsonString = _fileReader.Read(jsonFilePath);
            return ParseNestedObjectFromString(jsonString, types);
        }

        public IList<object> ParseNestedObjectFromString(string jsonString, IEnumerable<Type> types)
        {
            var json = JObject.Parse(jsonString);
            return types.Select(type => ParseNestedObject(json, type)).ToList();
        }

        private static object ParseNestedObject(JObject json, Type type)
        {
            var resultJson = json[type.Name];
            if (resultJson == null)
            {
                throw new JsonNotConsistNestedObjectException(json.ToString(), type);
            }
            return resultJson.ToObject(type);
        }
    }
}