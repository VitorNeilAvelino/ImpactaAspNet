﻿using System;

namespace ExpoCenter.WebApi.Models
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}