﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAppo_JosueVa.Services
{
    public static class APIConnection
    {

        public static string MimeType = "application/json";
        public static string ContentType = "Content-Type";

        public static string ProductionUrlPrefix = "http://192.168.0.15:45455/api/";
        public static string TestingUrlPrefix = "http://192.168.0.15:45455/api/";

        public static string ApiKey = "JosueVargasAQWERTQWEQWEQWEQWE";
        public static string ApiKeyName = "P6ApiKey";
    }
}
