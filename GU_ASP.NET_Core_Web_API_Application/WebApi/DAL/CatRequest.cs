﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DAL
{
    public class CatRequest
    {
        public string Nickname { get; init; }
        public double Weight { get; init; }
        public string Color { get; init; }
        public bool HasCertificate { get; init; }
        public string Feed { get; init; }
    }
}