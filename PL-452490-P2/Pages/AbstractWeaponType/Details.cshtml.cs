using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PL_452490_P2.Data;
using PL_452490_P2.Models;

namespace PL_452490_P2.Pages.AbstractWeaponType
{
    public class DetailsModel : PageModel
    {
        private readonly PL_452490_P2.Data.MyContext _context;

        public DetailsModel(PL_452490_P2.Data.MyContext context)
        {
            _context = context;
        }

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
    }
}
