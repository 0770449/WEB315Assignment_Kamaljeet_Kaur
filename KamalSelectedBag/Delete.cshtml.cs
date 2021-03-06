using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KamalSelectedBag.Models;

namespace KamalSelectedBag
{
    public class DeleteModel : PageModel
    {
        private readonly KamalSelectedBagContext _context;

        public DeleteModel(KamalSelectedBagContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bag Bag { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bag = await _context.Bag.FirstOrDefaultAsync(m => m.ID == id);

            if (Bag == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bag = await _context.Bag.FindAsync(id);

            if (Bag != null)
            {
                _context.Bag.Remove(Bag);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
