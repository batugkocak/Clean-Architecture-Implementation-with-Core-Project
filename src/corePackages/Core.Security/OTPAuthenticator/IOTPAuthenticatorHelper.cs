namespace Core.Security.OTPAuthenticator;

public interface IOTPAuthenticatorHelper
{
    public Task<byte[]> GenerateSecretKey();
    public Task<string> ConvertSecretKeyToString(byte[] secretKey);
    public Task<bool> VerifyCode(byte[] secretKey, string code);
}