using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Cars
{
    public class CreateModel : CarCategoriesPageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public CreateModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProducerID"] = new SelectList(_context.Producer, "ID", "ProducerName");

            var car = new Car();
            car.CarCategories = new List<CarCategory>();
            PopulateAssignedCategoryData(_context, car);
            return Page();
        }
        [BindProperty]
        public Car Car { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newCar = new Car();
            if (selectedCategories != null)
            {
                newCar.CarCategories = new List<CarCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CarCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newCar.CarCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Car>(
            newCar,
            "Car",
            i => i.Model, i => i.Mark,
            i => i.Price, i => i.LaunchingDate, i => i.ProducerID))
            {
                _context.Car.Add(newCar);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newCar);
            return Page();
        }
    }
}
