using Assignment.Shared.User;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyAssignment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAssignment.Respositories.UserRepo
{
    public class UserRespo : IUserRespo
    {
        private readonly ApplicationDbContext _context;
      

        public UserRespo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IdentityUser>> GetUser()
        {
            var user = await _context.Users.AsNoTracking().ToListAsync();

            return user;
        }
    }
}
