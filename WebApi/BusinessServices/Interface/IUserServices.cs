namespace BusinessServices.Interface
{
    public interface IUserServices
    {
        int Authenticate(string userName, string password);
    }
}
