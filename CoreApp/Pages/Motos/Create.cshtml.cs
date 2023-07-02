using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreApp.Data;
using CoreApp.Models;

namespace CoreApp.Pages.Motos
{
    public class CreateModel : PageModel
    {
        private readonly CoreApp.Data.CoreAppContext _context;

        public CreateModel(CoreApp.Data.CoreAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Moto Moto { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Moto == null || Moto == null)
            {
                return Page();
            }

            _context.Moto.Add(Moto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
