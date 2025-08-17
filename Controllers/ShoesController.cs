using Microsoft.AspNetCore.Mvc;
using Routing.Models;
using System.Collections.Generic;
using System.Linq;

namespace Routing.Controllers
{
    public class ShoesController : Controller
    {
        private static List<Shoe> shoes = new List<Shoe>
        {
            new Shoe { Id = 1, Name = "Air Max", Type = "Sneaker", Color = "Red", Price = 120 },
            new Shoe { Id = 2, Name = "Classic Leather", Type = "Casual", Color = "White", Price = 90 },
            new Shoe { Id = 3, Name = "Runner Pro", Type = "Running", Color = "Blue", Price = 110 },
            new Shoe { Id = 4, Name = "Trail Blazer", Type = "Hiking", Color = "Brown", Price = 130 },
            new Shoe { Id = 5, Name = "City Walker", Type = "Casual", Color = "Black", Price = 85 },
            new Shoe { Id = 6, Name = "Speedster", Type = "Sneaker", Color = "Green", Price = 115 },
            new Shoe { Id = 7, Name = "Mountain King", Type = "Hiking", Color = "Gray", Price = 140 },
            new Shoe { Id = 8, Name = "Sprint Star", Type = "Running", Color = "Yellow", Price = 105 },
            new Shoe { Id = 9, Name = "Urban Flex", Type = "Sneaker", Color = "White", Price = 125 },
            new Shoe { Id = 10, Name = "Desert Trek", Type = "Hiking", Color = "Tan", Price = 135 }
        };


        public IActionResult Index(string? type, string? color)
        {
            var filteredShoes = shoes.AsEnumerable();
            if (!string.IsNullOrEmpty(type))
                filteredShoes = filteredShoes.Where(s => s.Type.ToLower() == type.ToLower());
            if (!string.IsNullOrEmpty(color))
                filteredShoes = filteredShoes.Where(s => s.Color.ToLower() == color.ToLower());

            // For dropdowns
            ViewBag.Types = shoes.Select(s => s.Type).Distinct().ToList();
            ViewBag.Colors = shoes.Select(s => s.Color).Distinct().ToList();
            ViewBag.SelectedType = type;
            ViewBag.SelectedColor = color;
            return View(filteredShoes.ToList());
        }


        [Route("Shoes/{type}/{color}/{id}")]
        public IActionResult Details(string type, string color, int id)
        {
            var shoe = shoes.FirstOrDefault(s => s.Id == id && s.Type == type && s.Color == color);
            if (shoe == null)
                return NotFound();
            return View(shoe);
        }
    }
}
