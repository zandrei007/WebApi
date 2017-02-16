using System.Web.Http;
using BusinessEntities;
using BusinessServices.Concrete;
using BusinessServices.Interface;
using Resolver;

namespace WebApiAuthentication.Controllers
{
    public class LoginController : ApiController
    {
        //http://localhost:64188/api/login
        public User Post(User user)
        {
            var service = DI.Resolve<ITokenServices>();
            return service.Authenticate(user);
        }

        //http://localhost:64188/api/login/1
        public void GetById(int id)
        {
        }

        // http://localhost:64188/api/login/details
        [Route("api/login/details")]
        public void GetDetails()
        {
        }
    }
}
