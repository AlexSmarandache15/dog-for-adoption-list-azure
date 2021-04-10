using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogForAdoptionList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DogForAdoptionList.Controllers
{
    [Route("api/Dog")]
    [ApiController]
    public class DogController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DogController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Json(new { data = await _db.Dog.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var dogFromDb = await _db.Dog.FirstOrDefaultAsync(u => u.Id == id);
            if (dogFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Dog.Remove(dogFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }

}
