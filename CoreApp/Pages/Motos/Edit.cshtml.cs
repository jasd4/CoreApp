﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreApp.Data;
using CoreApp.Models;

namespace CoreApp.Pages.Motos
{
    public class EditModel : PageModel
    {
        private readonly CoreApp.Data.CoreAppContext _context;

        public EditModel(CoreApp.Data.CoreAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Moto Moto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Moto == null)
            {
                return NotFound();
            }

            var moto =  await _context.Moto.FirstOrDefaultAsync(m => m.MotoId == id);
            if (moto == null)
            {
                return NotFound();
            }
            Moto = moto;
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

            _context.Attach(Moto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotoExists(Moto.MotoId))
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

        private bool MotoExists(int id)
        {
          return (_context.Moto?.Any(e => e.MotoId == id)).GetValueOrDefault();
        }
    }
}
