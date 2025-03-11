using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inrefaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        bool CheckPasswordAsync(User user, string password);
    }
}
