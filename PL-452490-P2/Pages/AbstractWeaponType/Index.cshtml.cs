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
    public class IndexModel : PageModel
    {
        private readonly PL_452490_P2.Data.MyContext _context;

        public IndexModel(PL_452490_P2.Data.MyContext context)
        {
            _context = context;
        }

        public IList<Models.AbstractWeaponType> AbstractWeaponType { get;set; }

        public async Task OnGetAsync()
        {
            AbstractWeaponType = await _context.AbstractWeaponTypes.ToListAsync();
        }
    }
}
