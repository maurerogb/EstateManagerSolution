﻿namespace Authentication.Models
{
    public class JwtOptions
    {
      public string secret { get; set; }= string.Empty;
      public string Audience { get; set; }     = string.Empty;
      public string Issuer { get; set; } = string.Empty;
    }
}
