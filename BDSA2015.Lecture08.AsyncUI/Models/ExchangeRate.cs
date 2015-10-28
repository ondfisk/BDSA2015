﻿using Newtonsoft.Json;
using System;

namespace BDSA2015.Lecture08.AsyncUI.Models
{
    public class ExchangeRate
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

}
