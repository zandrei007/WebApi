using System;
using BusinessEntities;
using BusinessServices.Interface;
using DataModel.Database;
using Resolver;

namespace BusinessServices.Concrete
{
    public class TokenServices : ITokenServices
    {
        public TokenServices()
        {
        }

        public bool DeleteByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public TokenEntity GenerateToken(int userId)
        {
            throw new NotImplementedException();
        }

        public bool Kill(string tokenId)
        {
            throw new NotImplementedException();
        }

        public bool ValidateToken(string tokenId)
        {
            var ta = DI.Resolve<TokenAccess>();
            var isValid = ta.Validate(tokenId);
            return isValid;
        }
    }
}
