# ASP.NET Core MVC Routing: Lesson Plan

## Overview
This lesson covers how to create and add routing in ASP.NET Core MVC, focusing on both static and dynamic routing. It includes a recap of MVC and routing concepts, practical demos, and hands-on exercises. Learners are expected to already understand the basics of MVC, controllers, and views.

---

## 1. Introduction & Recap (5 min)
### MVC Recap
- **Model:** Handles data and business logic.
- **View:** Responsible for the user interface.
- **Controller:** Processes incoming requests, updates the model, and selects a view to render.

### Routing Recap
- **Routing** is the mechanism that maps URLs to controller actions.
- It enables clean, user-friendly URLs and helps organize application navigation.

---

## 2. Static Routing (10 min)
### What is Static Routing?
- Uses fixed URL patterns.
- Example: `/Home/Index` always maps to the `Index` action of the `HomeController`.

### Demo: Default Route
```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```
- This pattern means URLs like `/Home/Index` or `/Shoes/Index` are automatically mapped.

---

## 3. Dynamic Routing (15 min)
### What is Dynamic Routing?
- Uses URL parameters to create flexible routes.
- Example: `/Shoes/Sneaker/Red/1` maps to a specific shoe by type, color, and id.

### Demo: Custom Route
```csharp
app.MapControllerRoute(
    name: "shoes-details",
    pattern: "Shoes/{type}/{color}/{id}",
    defaults: new { controller = "Shoes", action = "Details" });
```
- Controller action receives parameters:
```csharp
public IActionResult Details(string type, string color, int id)
```

### Practice
- Add a new dynamic route, e.g., `/Books/{genre}/{id}`.

---

## 4. Static vs Dynamic Routing (5 min)
| Static Routing         | Dynamic Routing                |
|-----------------------|-------------------------------|
| Fixed URL patterns    | Flexible, parameterized URLs   |
| For standard pages    | For resources with parameters  |
| Simple to configure   | More powerful and flexible     |

---

## 5. Hands-On: Add Routing to a Product Feature (20 min)
- Create a new controller and views for a product (e.g., Shoes).
- Add both static and dynamic routes.
- Test navigation and URL patterns in the browser.

---

## 6. Q&A & Wrap-Up (5 min)
- Review key concepts: MVC, routing, static vs dynamic.
- Open floor for questions.

---

## Key Takeaways
- MVC separates concerns for scalable web apps.
- Routing maps URLs to controller actions.
- Static routes are simple and fixed; dynamic routes are flexible and powerful.
- Practice by adding and testing routes in your own projects.
