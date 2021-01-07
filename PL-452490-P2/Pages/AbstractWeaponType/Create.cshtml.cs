using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PL_452490_P2.Data;
using PL_452490_P2.Models;

namespace PL_452490_P2.Pages.AbstractWeaponType
{
    public class CreateModel : PageModel
    {
        private readonly PL_452490_P2.Data.MyContext _context;

        public CreateModel(PL_452490_P2.Data.MyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.AbstractWeaponType AbstractWeaponType { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AbstractWeaponTypes.Add(AbstractWeaponType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
