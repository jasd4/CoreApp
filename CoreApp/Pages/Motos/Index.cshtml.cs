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
    public class IndexModel : PageModel
    {
        private readonly CoreApp.Data.CoreAppContext _context;

        public IndexModel(CoreApp.Data.CoreAppContext context)
        {
            _context = context;
        }

        public IList<Moto> Moto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Moto != null)
            {
                Moto = await _context.Moto.ToListAsync();
            }
        }
    }
}
