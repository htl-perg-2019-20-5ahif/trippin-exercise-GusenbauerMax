﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Trippin
{
    public class JsonUser
    {
        [JsonPropertyName("UserName")]
        public string UserName { get; set; }

        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("LastName")]
        public string LastName { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("Address")]
        public string Address { get; set; }

        [JsonPropertyName("CityName")]
        public string CityName { get; set; }

        [JsonPropertyName("Country")]
        public string Country { get; set; }

        public string ToString()
        {
            return UserName + ": " + FirstName + ", " + LastName + " - " + Email + "\n" + Address + ", " + CityName + " - " + Country;
        }
    }
}
