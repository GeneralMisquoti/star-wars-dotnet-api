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

namespace PL_452490_P2.Pages.AbstractWeaponType
{
    public class EditModel : PageModel
    {
        private readonly PL_452490_P2.Data.MyContext _context;

        public EditModel(PL_452490_P2.Data.MyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.AbstractWeaponType AbstractWeaponType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AbstractWeaponType = await _context.AbstractWeaponTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (AbstractWeaponType == null)
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

            _context.Attach(AbstractWeaponType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbstractWeaponTypeExists(AbstractWeaponType.Id))
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

        private bool AbstractWeaponTypeExists(int id)
        {
            return _context.AbstractWeaponTypes.Any(e => e.Id == id);
        }
    }
}
