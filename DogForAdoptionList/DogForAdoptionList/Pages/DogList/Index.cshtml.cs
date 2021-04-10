using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogForAdoptionList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DogForAdoptionList.Pages.DogList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        } 

        public IEnumerable<Dog> Dogs { get; set; }

        public async Task OnGet()
        {
            Dogs = await _db.Dog.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var dog = await _db.Dog.FindAsync(id);
            if (dog == null)
            {
                return NotFound();
            }
            _db.Dog.Remove(dog);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
