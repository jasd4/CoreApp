using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreApp.Data;
using CoreApp.Models;

namespace CoreApp.Pages.Motos
{
    public class DetailsModel : PageModel
    {
        private readonly CoreApp.Data.CoreAppContext _context;

        public DetailsModel(CoreApp.Data.CoreAppContext context)
        {
            _context = context;
        }

      public Moto Moto { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Moto == null)
            {
                return NotFound();
            }

            var moto = await _context.Moto.FirstOrDefaultAsync(m => m.MotoId == id);
            if (moto == null)
            {
                return NotFound();
            }
            else 
            {
                Moto = moto;
            }
            return Page();
        }
    }
}
