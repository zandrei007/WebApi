using System.Web.Http;
using WebApiAuthentication.Models;

namespace WebApiAuthentication.Controllers
{
    public class LoginController : ApiController
    {
        //http://localhost:64188/api/login
        public void Post(User user)
        {
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
