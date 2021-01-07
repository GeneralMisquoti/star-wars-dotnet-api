using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PL_452490_P2.Data;

namespace PL_452490_P2.Pages.Weapon
{
    public class WeaponOwnersPageModel : PageModel
    {
        public SelectList WeaponOwnersSL { get; set; }
        public SelectList WeaponTypesSL { get; set; }

        public async Task PopulateWeaponOwnersDropDownList(MyContext context,
            object selectedOwner = null)
        {
            var owners = await context.WeaponOwners.AsNoTracking().ToListAsync();
            WeaponOwnersSL = new SelectList(owners, "Id", "Name", selectedOwner);
        }
        
        public async Task PopulateAbstractWeaponTypesDropDownList(MyContext context,
            object selectedOwner = null)
        {
            var types = await context.AbstractWeaponTypes.AsNoTracking().ToListAsync();
            System.Console.WriteLine(types);
            WeaponTypesSL = new SelectList(types, "Id", "Name", selectedOwner);
        }
        
    }
}