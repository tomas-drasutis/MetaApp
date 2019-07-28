using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Metaapp.DataLayer.Storage
{
    class Storage : IStorage
    {
        private string _filePath = "FileName.txt";

        private readonly JsonSerializer _serializer = new JsonSerializer
        {
            Formatting = Formatting.Indented
        };

        public void Save<T>(IEnumerable<T> obj)
        {
            using (var writer = new StreamWriter(_filePath))
            {
                _serializer.Serialize(writer, obj);
            }
        }

        public IEnumerable<T> Read<T>()
        {
            if (!File.Exists(_filePath))
            {
                using (File.Create(_filePath))
                {
                    return Enumerable.Empty<T>();
                }
            }
            using (var reader = new StreamReader(_filePath))
            using (var jsonReader = new JsonTextReader(reader))
                return _serializer.Deserialize<IEnumerable<T>>(jsonReader);
        }
    }
}
