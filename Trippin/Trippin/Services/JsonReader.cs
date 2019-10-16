using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Trippin.Services
{
    class JsonReader : IJsonReader
    {
        public JsonUser[] ReadUsers(string filename)
        {
            return JsonSerializer.Deserialize<JsonUser[]>(File.ReadAllText(filename));
        }
    }
}
