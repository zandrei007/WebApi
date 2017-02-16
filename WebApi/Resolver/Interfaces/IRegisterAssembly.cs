namespace Resolver.Interfaces
{
    /// <summary>
    /// Register underlying types with unity.
    /// </summary>
    public interface IRegisterAssembly
    {
        void SetUp(IRegisterComponent registerComponent);
    }
}
