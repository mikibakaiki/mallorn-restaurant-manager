using MallornRestaurantManagerApi.Models;

namespace MallornRestaurantManagerApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}