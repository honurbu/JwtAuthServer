using JwtAuthServer.Core.Configuration;
using JwtAuthServer.Core.DTOs;
using JwtAuthServer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthServer.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp userApp);

        ClientTokenDto CreateTokenByClient(Client client);
        //Sistemde bulunan kullanıcının Token'inin erişimine izin verdiği yerleri Id sini ve listesini Dto ile dönüştürmeyi sağlar.
    }
}
