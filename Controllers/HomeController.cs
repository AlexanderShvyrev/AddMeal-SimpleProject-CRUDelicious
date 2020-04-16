using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoCrudelicious.Models;

namespace DojoCrudelicious.Controllers
{
    public class HomeController : Controller
    {

        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext=context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            // List<Dish>AllDishes=dbContext.Dishes.ToList();
            List<Dish>MostRecent=dbContext.Dishes
            .OrderByDescending(u => u.UpdatedAt)
            .Take(5)
            .ToList();
            return View(MostRecent);
        }

        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("process")]
        public IActionResult Process(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Dishes.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Add");
            }
        }

        [HttpGet("{dishId}")]

        public IActionResult Display(int dishId)
        {
            Dish RetrievedDish = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            return View(RetrievedDish);
        }

        [HttpGet("edit/{dishId}")]
        public IActionResult Edit(int dishId)
        {
            Dish edit = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            return View(edit);
        }


        [HttpPost("update/{dishId}")]
        public IActionResult Update(int dishId, Dish update)
        {
            Dish retrieved=dbContext.Dishes.FirstOrDefault(dish => dish.DishId==dishId);
            if (ModelState.IsValid)
            {
                retrieved.Name=update.Name;
                retrieved.Chef=update.Chef;
                retrieved.Tastiness=update.Tastiness;
                retrieved.Calories=update.Calories;
                retrieved.Description=update.Description;
                retrieved.UpdatedAt=DateTime.Now;
                dbContext.SaveChanges();
                return Redirect($"/{dishId}");

            }
            else
            {   update.DishId=dishId;
                return View("Edit", update);
            }
        }
        [HttpGet("delete/{dishId}")]
        public IActionResult Delete(int dishId)
        {
            Dish toBeDeleted = dbContext.Dishes.FirstOrDefault(dish => dish.DishId==dishId);
            dbContext.Dishes.Remove(toBeDeleted);
            dbContext.SaveChanges();
            return Redirect("/");
        }


    }
}
