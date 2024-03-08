using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace RapidRetail.Infrastructure.Models
{
    internal class JwtSetting
    {
        public string Issuer { get; }
        public string SecretKey { get; }

        public JwtSetting(IConfiguration configuration)
        {
            Issuer = configuration.GetSection("Jwt:Issuer").Get<string>();
            SecretKey = configuration.GetSection("Jwt:Key").Get<string>();
        }
    }
}
