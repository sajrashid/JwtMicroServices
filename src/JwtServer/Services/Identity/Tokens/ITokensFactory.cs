using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using static Microsoft.AspNetCore.WebSockets.Internal.Constants;


namespace JwtServer.Services.Identity.Tokens
{
    public interface ITokensFactory
    {
        string CreateToken(List<Claim> Claims);

        bool VerifyBearer(string hostName, IHeaderDictionary headers);
    }
}
