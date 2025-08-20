# Step-by-Step Guide: Building a Dynamic Shoes Listing App with ASP.NET Core MVC

This guide will walk you through creating an ASP.NET Core MVC app that lists shoes, allows filtering by type and color, and displays individual shoe details. All code snippets and instructions are included.

---

## 1. Create a New ASP.NET Core MVC Project

```bash
# In your terminal:
dotnet new mvc -n Routing
cd Routing
```

---

## 2. Create the Shoe Model

Create `Models/Shoe.cs`:
```csharp
namespace Routing.Models
{
    public class Shoe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
    }
}
```

---

## 3. Create the Shoes Controller

Create `Controllers/ShoesController.cs`:
```csharp
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
```

---

## 4. Create the Shoes Views

### a. List View: `Views/Shoes/Index.cshtml`
```cshtml
@model IEnumerable<Routing.Models.Shoe>
@{
    ViewData["Title"] = "Shoes List";
}
<h2>Shoes List</h2>
<form method="get" asp-controller="Shoes" asp-action="Index" class="row g-3 mb-3">
    <div class="col-auto">
        <select name="type" class="form-select" onchange="this.form.submit()">
            <option value="">All Types</option>
            @foreach (var t in ViewBag.Types as List<string>)
            {
                if (ViewBag.SelectedType == t)
                {
                    <option value="@t" selected>@t</option>
                }
                else
                {
                    <option value="@t">@t</option>
                }
            }
        </select>
    </div>
    <div class="col-auto">
        <select name="color" class="form-select" onchange="this.form.submit()">
            <option value="">All Colors</option>
            @foreach (var c in ViewBag.Colors as List<string>)
            {
                if (ViewBag.SelectedColor == c)
                {
                    <option value="@c" selected>@c</option>
                }
                else
                {
                    <option value="@c">@c</option>
                }
            }
        </select>
    </div>
</form>
<table class="table">
    <thead>
        <tr>
            <th>Name</th>
            <th>Type</th>
            <th>Color</th>
            <th>Price</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
    @foreach (var shoe in Model)
    {
        <tr>
            <td>@shoe.Name</td>
            <td>@shoe.Type</td>
            <td>@shoe.Color</td>
            <td>@shoe.Price.ToString("C")</td>
            <td>
                <a asp-controller="Shoes" asp-action="Details" asp-route-type="@shoe.Type" asp-route-color="@shoe.Color" asp-route-id="@shoe.Id">View</a>
            </td>
        </tr>
    }
    </tbody>
</table>
```

### b. Details View: `Views/Shoes/Details.cshtml`
```cshtml
@model Routing.Models.Shoe
@{
    ViewData["Title"] = "Shoe Details";
}
<h2>Shoe Details</h2>
<div>
    <h4>@Model.Name</h4>
    <hr />
    <dl class="row">
        <dt class = "col-sm-2">Type</dt>
        <dd class = "col-sm-10">@Model.Type</dd>
        <dt class = "col-sm-2">Color</dt>
        <dd class = "col-sm-10">@Model.Color</dd>
        <dt class = "col-sm-2">Price</dt>
        <dd class = "col-sm-10">@Model.Price.ToString("C")</dd>
    </dl>
    <a asp-action="Index">Back to List</a>
</div>
```

---

## 5. Register the Custom Route

Edit `Program.cs` to add the custom route for shoe details:
```csharp
// ...existing code...
app.MapControllerRoute(
    name: "shoes-details",
    pattern: "Shoes/{type}/{color}/{id}",
    defaults: new { controller = "Shoes", action = "Details" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// ...existing code...
```

---

## 6. Add Navigation Link

Edit `Views/Shared/_Layout.cshtml` to add a link to the Shoes list:
```cshtml
<li class="nav-item">
    <a class="nav-link text-dark" asp-area="" asp-controller="Shoes" asp-action="Index">Products</a>
</li>
```
Add this inside the `<ul class="navbar-nav flex-grow-1">`.

---

## 7. Run the App

```bash
dotnet run
```
- Visit `/Shoes` to see the list.
- Use the dropdowns to filter by type and color.
- Click "View" to see individual shoe details with a dynamic URL.

---

## Done!
You now have a dynamic, filterable product listing app using ASP.NET Core MVC.
