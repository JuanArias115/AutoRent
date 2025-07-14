using Google.Apis.Auth;

namespace AutoRent.Interfaces
{
    public interface IFirebaseAuthService
    {
        Task<GoogleJsonWebSignature.Payload?> verifyTokenAsync(string token);
    }
}
