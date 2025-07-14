using AutoRent.Interfaces;
using Google.Apis.Auth;
using System.Linq.Expressions;

namespace AutoRent.Services
{
    public class FirebaseAuthService : IFirebaseAuthService
    {
        public async Task<GoogleJsonWebSignature.Payload?> verifyTokenAsync(string token)
        {
            try
            {
                var decoded = await GoogleJsonWebSignature.ValidateAsync(token);
                return decoded;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Token invalido" + ex.Message);
                return null;
            }
        }
    }
}
