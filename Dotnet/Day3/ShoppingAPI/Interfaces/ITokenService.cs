namespace ShoppingAPI.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(string username);
    }
}
