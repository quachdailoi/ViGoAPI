using API.Extensions;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System.Security.Cryptography;
using System.Text;

namespace API.Utils
{
    public class ZaloPayHelpers
    {
        private static int randomNumber = new Random().Next(999999);
        public static string GetAppTransId()
        {
            
            string timeString = DateTimeOffset.Now.ToFormatString("yyMMdd_hhmmss");

            return $"{timeString}{randomNumber.ToString("D6")}";
        }

        public static string Encrypt(string data, string publicKey)
        {
            byte[] publicKeyBytes = Convert.FromBase64String(publicKey);
            AsymmetricKeyParameter asymmetricKeyParameter = PublicKeyFactory.CreateKey(publicKeyBytes);
            RsaKeyParameters rsaKeyParameters = (RsaKeyParameters)asymmetricKeyParameter;

            RSAParameters rsaParameters = new RSAParameters
            {
                Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned(),
                Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned()
            };


            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(rsaParameters);


            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(data);

            byte[] encryptedData = rsa.Encrypt(dataToEncrypt, false);

            var hash = Convert.ToBase64String(encryptedData);

            return hash;
        }
    }
}
