﻿namespace AutoRent.DTOs.Login
{
    public class AuthResultDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
