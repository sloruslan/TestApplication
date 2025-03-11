using Application.Inrefaces;
using AutoMapper;
using Domain;
using Domain.DTO;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly IMapper _mapper;
        public UserRepository(IDbContextFactory dbContextFactory, IMapper mapper)
        {
            _dbContextFactory = dbContextFactory;
            _mapper = mapper;
        }

        public bool CheckPasswordAsync(User user, string password)
        {
            return user.Password == PasswordHasher.HashPassword(password);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            await using (var context = _dbContextFactory.CreateDbContext())
            {
                var user = context.User
                    .Include(x => x.Role)
                    .FirstOrDefault(x => x.Email == email);

                return user;
            }
        }
    }
}
