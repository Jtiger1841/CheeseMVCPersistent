using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            List<CheeseCategory> allCat = context.Categories.ToList();
            return View(allCat);
        }
        public IActionResult Add()
        {
            AddCategoryViewModel categoryViewModel = new AddCategoryViewModel();
            return View(categoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel categoryViewModel)
        {
            if(ModelState.IsValid)
            {
                CheeseCategory newCategory = new CheeseCategory
                {
                    Name = categoryViewModel.Name
                };
                context.Categories.Add(newCategory);
                context.SaveChanges();
                return Redirect("/Category");
            }
            else
            {
                return View(categoryViewModel);
            }
        }
    }
}




