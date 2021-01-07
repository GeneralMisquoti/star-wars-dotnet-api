using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PL_452490_P2.Data;
using PL_452490_P2.Models;

namespace PL_452490_P2.Pages.Weapon
{
    public class EditModel : WeaponOwnersPageModel
    {
        private readonly PL_452490_P2.Data.MyContext _context;

        public EditModel(PL_452490_P2.Data.MyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Weapon Weapon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await PopulateWeaponOwnersDropDownList(_context);
            await PopulateAbstractWeaponTypesDropDownList(_context);
            if (id == null)
            {
                return NotFound();
            }

            Weapon = await _context.Weapons.FirstOrDefaultAsync(m => m.Id == id);

            if (Weapon == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Weapon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeaponExists(Weapon.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WeaponExists(int id)
        {
            return _context.Weapons.Any(e => e.Id == id);
        }
    }
}
