using JwtAuthServer.Core.DTOs;
using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthServer.Core.Services
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        //giriş yapan kullanıcıya AccessToken ve RefreshToken üretir.

        Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        //her yenileme tokeni geldiğinde yeni bir AccesToken ve RefreshToken üretir.

        Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken);
        //Eğer RefreshToken deaktif edilecek ise NoDataDto ile Null dönülür.

        Response<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto);
        //?Client tarafından bir Token döndürülür.

    }
}
