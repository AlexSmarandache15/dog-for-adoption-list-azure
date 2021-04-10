using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogForAdoptionList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DogForAdoptionList.Pages.DogList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Dog Dog { get; set; }
        public async Task OnGet(int id)
        {
            Dog = await _db.Dog.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var DogFromDb = await _db.Dog.FindAsync(Dog.Id);
                DogFromDb.Name = Dog.Name;
                DogFromDb.Gender = Dog.Gender;
                DogFromDb.Race = Dog.Race;
                DogFromDb.DateOfBirth = Dog.DateOfBirth;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
