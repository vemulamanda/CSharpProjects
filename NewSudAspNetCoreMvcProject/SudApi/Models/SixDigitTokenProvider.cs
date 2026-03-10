using Microsoft.AspNetCore.Identity;

namespace SudApi.Models
{
    public class SixDigitTokenProvider : IUserTwoFactorTokenProvider<IdentityUser>
    {
        public Task<string> GenerateAsync(string purpose, UserManager<IdentityUser> manager, IdentityUser user)
        {
            // Generate a six-digit numeric code
            var token = new Random().Next(100000, 999999).ToString();
            return Task.FromResult(token);
        }

        public Task<bool> ValidateAsync(string purpose, string token, UserManager<IdentityUser> manager, IdentityUser user)
        {
            // Simple validation: must be 6 digits
            return Task.FromResult(token.Length == 6 && int.TryParse(token, out _));
        }

        public Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<IdentityUser> manager, IdentityUser user)
        {
            return Task.FromResult(true);
        }
    }
}
