using Core.Security.JWT;
using Core.Security.OTPAuthenticator;
using Core.Security.OTPAuthenticator.OtpNet;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Security;

public static class SecurityServiceRegistration
{
    public static IServiceCollection AddSecurityServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenHelper, JWTHelper>();
        //services.AddScoped<IEmailAuthenticatorHelper, EmailAuthenticatorHelper>();
        services.AddScoped<IOTPAuthenticatorHelper, OtpNetOtpAuthenticatorHelper>();
        return services;
    }
}