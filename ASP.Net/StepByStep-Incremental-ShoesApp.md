
# Step-by-Step Guide: Building a Shoes App

This guide breaks the process into small, testable steps. Each step builds on the previous one, so you can run and see progress as you go.

---
## Step 1. Create the project called 'Shoes App' in Visual Studio 2022.

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


## 3. Create the Shoes Controller and List Action (No Filters Yet)

Create `Controllers/ShoesController.cs`:
```csharp
using Microsoft.AspNetCore.Mvc;
using Routing.Models;
using System.Collections.Generic;

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

        public IActionResult Index()
        {
            return View(shoes);
        }
    }
}
```

---


## 4. Create the List View

Create `Views/Shoes/Index.cshtml`:
```cshtml
@model IEnumerable<Routing.Models.Shoe>
@{
    ViewData["Title"] = "Shoes List";
}
<h2>Shoes List</h2>
<table class="table">
    <thead>
        <tr>
            <th>Name</th>
            <th>Type</th>
            <th>Color</th>
            <th>Price</th>
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
        </tr>
    }
    </tbody>
</table>
```

---

## 5. Add Navigation Link to Products

Edit `Views/Shared/_Layout.cshtml` to add a link to the Shoes list:
```cshtml
<li class="nav-item">
    <a class="nav-link text-dark" asp-area="" asp-controller="Shoes" asp-action="Index">Products</a>
</li>
```
Add this inside the `<ul class="navbar-nav flex-grow-1">`.

---

## 6. Run and Test the List View

- Run `dotnet run` and visit `/Shoes` to see the list of shoes.

---

## 7. Add the Details Action and View

Update `ShoesController.cs`:
```csharp
// ...existing code...
public IActionResult Details(int id)
{
    var shoe = shoes.FirstOrDefault(s => s.Id == id);
    if (shoe == null)
        return NotFound();
    return View(shoe);
}
```

Create `Views/Shoes/Details.cshtml`:
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
</div>
```

---


## 7. Add a Link to Details in the List View

Update `Views/Shoes/Index.cshtml`:
```cshtml
// ...existing code...
<td>
    <a asp-controller="Shoes" asp-action="Details" asp-route-id="@shoe.Id">View</a>
</td>
// ...existing code...
```

---

## 8. Add Navigation Link to Products

Edit `Views/Shared/_Layout.cshtml` to add a link to the Shoes list:
```cshtml
<li class="nav-item">
    <a class="nav-link text-dark" asp-area="" asp-controller="Shoes" asp-action="Index">Products</a>
</li>
```
Add this inside the `<ul class="navbar-nav flex-grow-1">`.

---

## 9. Run and Test Details

- Run `dotnet run` and click "View" to see individual shoe details at `/Shoes/Details/1`.

---

## 10. Make the URL More Dynamic (Add Type and Color to URL)

Update the Details action and route in `ShoesController.cs`:
```csharp
[Route("Shoes/{type}/{color}/{id}")]
public IActionResult Details(string type, string color, int id)
{
    var shoe = shoes.FirstOrDefault(s => s.Id == id && s.Type == type && s.Color == color);
    if (shoe == null)
        return NotFound();
    return View(shoe);
}
```

Update the link in `Index.cshtml`:
```cshtml
<a asp-controller="Shoes" asp-action="Details" asp-route-type="@shoe.Type" asp-route-color="@shoe.Color" asp-route-id="@shoe.Id">View</a>
```

Register the custom route in `Program.cs`:
```csharp
app.MapControllerRoute(
    name: "shoes-details",
    pattern: "Shoes/{type}/{color}/{id}",
    defaults: new { controller = "Shoes", action = "Details" });
```

---

## 11. Run and Test Dynamic URLs

- Run `dotnet run` and click "View". The URL should now look like `/Shoes/Sneaker/Red/1`.

---

## 12. Add Filtering Dropdowns for Type and Color

Update the `ShoesController` Index action to accept optional `type` and `color` parameters and provide lists for the dropdowns:
```csharp
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
```

Update `Views/Shoes/Index.cshtml` to add the dropdowns above the table:
```cshtml
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
```

---


You now have a step-by-step, incremental approach to building the app, testing each feature as you go, including advanced filtering and navigation!
