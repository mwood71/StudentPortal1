using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portal.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();

                }
            }
            catch (Exception ex)
            {

            }

            if (_db.Roles.Any(a => a.Name == SD.AdminEndUser)) return;

            _roleManager.CreateAsync(new IdentityRole(SD.AdminEndUser)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.StudentEndUser)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new IdentityUser
            {
                UserName = "mwood71@students.kennesaw.edu",
                Email = "mwood71@students.kennesaw.edu",

            }, "_Simplyliving9").GetAwaiter().GetResult();

            

            _userManager.AddToRoleAsync(_db.Users.FirstOrDefaultAsync(u => u.Email == "mwood71@students.kennesaw.edu").GetAwaiter().GetResult(), SD.AdminEndUser).GetAwaiter().GetResult();


        }
    }
}
