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
    public class CreateModel : WeaponOwnersPageModel
    {
        private readonly PL_452490_P2.Data.MyContext _context;

        public CreateModel(PL_452490_P2.Data.MyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Weapon Weapon { get; set; }
        public IList<Models.WeaponOwners> WeaponOwners { get; set; }
        public IList<Models.AbstractWeaponType> AbstractWeaponTypes { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            await PopulateWeaponOwnersDropDownList(_context);
            await PopulateAbstractWeaponTypesDropDownList(_context);
            // WeaponOwners = await _context.WeaponOwners.ToListAsync();
            // AbstractWeaponTypes = await _context.AbstractWeaponTypes.ToListAsync();
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Weapons.Add(Weapon);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
