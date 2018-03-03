using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtServer.Services.Identity.Tokens;
using JwtServer.Services.Identity.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace JwtServer.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        private IConfiguration _config;
        private readonly ILogger _logger;
        private IClaimsFactory _claimsfactory;
        private ITokensFactory _tokensfactory;

        public TokenController(IConfiguration config, ILogger<TokenController> logger, IClaimsFactory claimsfactory, ITokensFactory tokensfactory)
        {
            _logger = logger;
            _config = config;
            _claimsfactory = claimsfactory;
            _tokensfactory = tokensfactory;

        }

        /// <summary>
        /// here we return a JWT token from the claims service
        /// The claims service gets the token from the token service
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody] Key Key)
        {
            //Defaults to not authroised http 401
            IActionResult response = Unauthorized();




            // TODO  // check/validate api keys  get from DB
            if (Key.APIKey == "q1WkAk+jB3K1jc2cbwNDDO5JjwleCmUWhw/aPCay9J8=")
            {
                var User = "Mule";
                var Roles = new List<String>()
                {
                    "Mule"
                 };
                //TODO get role from db/api key get userneme from db

                //get claims from the claims factory
                List<Claim> Claims = _claimsfactory.CreateJwtClaims(User, Roles);

                // // Get new token from token factory
                String TokenString = _tokensfactory.CreateToken(Claims);

                //update the http response send token to caller
                response = Ok(new { token = TokenString });
            }

            return response;
        }

        public class Key
        {
            public String APIKey { get; set; }

        }

    }
}