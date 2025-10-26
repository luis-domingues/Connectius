using Connectius.Application.Common.Interfaces.Authentication;

namespace Connectius.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    
    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(), 
            "displayName", 
            "username", 
            email, 
            "token");
    }

    public AuthenticationResult Register(string displayName, string username, string email, string password)
    {
        
        // verificar se o usuário existe
        
        // criar usuário
        
        // criar um jwt token
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, displayName, username);
        
        return new AuthenticationResult(
            userId, 
            displayName, 
            username, 
            email, 
            token);
    }
}
