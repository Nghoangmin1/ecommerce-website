using Fahasa.Data;
using Fahasa.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fahasa.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index(string searchString, string roleFilter)
        {
            var usersQuery = _context.ApplicationUsers.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                usersQuery = usersQuery.Where(u => u.FullName.Contains(searchString) || u.Email.Contains(searchString) || u.PhoneNumber.Contains(searchString));
            }

            // Execute query to get users first (needed for Role filtering which is non-trivial in LINQ with Identity w/o navigation props setup)
            var users = await usersQuery.ToListAsync();

            // Filter by Role
            if (!string.IsNullOrEmpty(roleFilter))
            {
                var usersInRole = await _userManager.GetUsersInRoleAsync(roleFilter);
                var userIdsInRole = usersInRole.Select(u => u.Id).ToHashSet();
                users = users.Where(u => userIdsInRole.Contains(u.Id)).ToList();
            }

            var userRoles = new Dictionary<string, IList<string>>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userRoles[user.Id] = roles;
            }

            ViewBag.UserRoles = userRoles;
            ViewBag.Roles = await _roleManager.Roles.ToListAsync();
            ViewBag.SearchString = searchString;
            ViewBag.RoleFilter = roleFilter;

            return View(users);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.ApplicationUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);
            ViewBag.Roles = roles;

            return View(user);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.ApplicationUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.ApplicationUsers.FindAsync(id);
            if (user != null)
            {
                // Prevent deleting own account
                if (user.UserName == User.Identity.Name)
                {
                    TempData["Error"] = "Bạn không thể xóa tài khoản của chính mình.";
                    return RedirectToAction(nameof(Index));
                }

                _context.ApplicationUsers.Remove(user);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Đã xóa người dùng thành công.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
