﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.DataAccess.Models
{
    public class ResponseAmount
    {
        public string date { get; set; }
        public Info info { get; set; }
        public Query query { get; set; }
        public double? result { get; set; }
        public bool success { get; set; }
    }
    public class Info
    {
        public double? rate { get; set; }
        public int? timestamp { get; set; }
    }

    public class Query
    {
        public int? amount { get; set; }
        public string from { get; set; }
        public string to { get; set; }
    }
}
