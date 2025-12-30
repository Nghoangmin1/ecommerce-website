using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Fahasa.Data;
using Fahasa.Models;

namespace Fahasa.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class AddressController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AddressController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Customer/Address
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var addresses = await _context.Addresses
                .Where(a => a.UserId == user.Id)
                .OrderByDescending(a => a.IsDefault) // Default first
                .ToListAsync();

            return View(addresses);
        }

        // GET: Customer/Address/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Address/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReceiverName,PhoneNumber,StreetAddress,City,District,Ward,IsDefault")] Address address)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                // Trim string properties
                if (address.ReceiverName != null) address.ReceiverName = address.ReceiverName.Trim();
                if (address.PhoneNumber != null) address.PhoneNumber = address.PhoneNumber.Trim();
                if (address.StreetAddress != null) address.StreetAddress = address.StreetAddress.Trim();
                if (address.City != null) address.City = address.City.Trim();
                if (address.District != null) address.District = address.District.Trim();
                if (address.Ward != null) address.Ward = address.Ward.Trim();

                address.UserId = user.Id;

                if (address.IsDefault)
                {
                    // Unset other defaults
                    var existingDefaults = await _context.Addresses
                        .Where(a => a.UserId == user.Id && a.IsDefault)
                        .ToListAsync();
                    
                    foreach (var item in existingDefaults)
                    {
                        item.IsDefault = false;
                    }
                }
                else
                {
                    // If this is the first address, make it default automatically
                    var count = await _context.Addresses.CountAsync(a => a.UserId == user.Id);
                    if (count == 0)
                    {
                        address.IsDefault = true;
                    }
                }

                _context.Add(address);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Thêm địa chỉ thành công";
                return RedirectToAction(nameof(Index));
            }
            return View(address);
        }

        // GET: Customer/Address/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id && a.UserId == user.Id);
            
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        // POST: Customer/Address/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ReceiverName,PhoneNumber,StreetAddress,City,District,Ward,IsDefault")] Address address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (address.UserId != user.Id)
            {
                return Unauthorized();
            }

            if (ModelState.IsValid)
            {
                // Trim string properties
                if (address.ReceiverName != null) address.ReceiverName = address.ReceiverName.Trim();
                if (address.PhoneNumber != null) address.PhoneNumber = address.PhoneNumber.Trim();
                if (address.StreetAddress != null) address.StreetAddress = address.StreetAddress.Trim();
                if (address.City != null) address.City = address.City.Trim();
                if (address.District != null) address.District = address.District.Trim();
                if (address.Ward != null) address.Ward = address.Ward.Trim();

                try
                {
                    if (address.IsDefault)
                    {
                        // Unset other defaults
                        var existingDefaults = await _context.Addresses
                            .Where(a => a.UserId == user.Id && a.IsDefault && a.Id != id)
                            .ToListAsync();

                        foreach (var item in existingDefaults)
                        {
                            item.IsDefault = false;
                        }
                    }

                    _context.Update(address);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Cập nhật địa chỉ thành công";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(address);
        }

        // POST: Customer/Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id && a.UserId == user.Id);
            
            if (address != null)
            {
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Đã xóa địa chỉ";
            }
            
            return RedirectToAction(nameof(Index));
        }

        // POST: Customer/Address/SetDefault/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetDefault(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id && a.UserId == user.Id);

            if (address != null)
            {
                // Unset current default
                var currentDefault = await _context.Addresses
                    .Where(a => a.UserId == user.Id && a.IsDefault)
                    .FirstOrDefaultAsync();
                
                if (currentDefault != null)
                {
                    currentDefault.IsDefault = false;
                }

                address.IsDefault = true;
                await _context.SaveChangesAsync();
                TempData["Success"] = "Đã đặt làm địa chỉ mặc định";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }
    }
}
