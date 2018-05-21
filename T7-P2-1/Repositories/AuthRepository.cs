using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using T7_P2_1.Infrastructure;
using T7_P2_1.Models.DTOs;

namespace T7_P2_1.Repositories
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }


        public async Task<IdentityResult> RegisterUser(UserDTO userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName

            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            _userManager.AddToRole(user.Id, "users");
            return result;
        }
        public async Task<IdentityResult> RegisterAdminUser(UserDTO userModel)
        {
            IdentityUser user = new IdentityUser { UserName = userModel.UserName };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            _userManager.AddToRole(user.Id, "admins");
            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);
            return user;
        }


        public async Task<IList<string>> FindRoles(string userId)
        {
            return await _userManager.GetRolesAsync(userId);
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }

    }
    
}