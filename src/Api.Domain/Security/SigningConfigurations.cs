using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Api.Domain.Security
{
    public class SigningConfigurations
    {
        public SecurityKey key { get; set; }
        public SigningCredentials SigningCredentials { get; set; }

        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}