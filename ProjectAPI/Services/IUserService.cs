using ProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Services
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterModel model);
        Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model);
    }
}
