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
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext _db;
        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Dog Dog { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            Dog = new Dog();
            if (id == null)
            {
                return Page();
            }
            Dog = await _db.Dog.FirstOrDefaultAsync(u => u.Id == id);
            if (Dog == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Dog.Id == 0)
                {
                    _db.Dog.Add(Dog);
                }
                else
                {
                    _db.Dog.Update(Dog);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
