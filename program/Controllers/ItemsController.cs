using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Program.Models;

namespace Program.Controllers
{
    public class ItemsController : Controller
    {
        [HttpGet("/items")]
        public ActionResult Items()
        {
            List<Item> allItems = Item.GetAll();
            return View(allItems);
        }

        [HttpGet("/items/new")]
        public ActionResult CreateForm()
        {
            List<Category> allItems = Category.GetAll();
            return View(allItems);
        }

        [HttpPost("/items")]
        public ActionResult Create()
        {
          Item newItem = new Item (Request.Form["new-item"]);
          newItem.Save();
          Category selectedCategory = Category.Find(int.Parse(Request.Form["category"]));
          newItem.AddCategory(selectedCategory);
          List<Item> allItems = Item.GetAll();
          return View("Items", allItems);
        }
        [HttpGet("/")]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost("/category")]
        public ActionResult Indexc()
        {
            Category newItem = new Category (Request.Form["new-category"]);
            newItem.Save();
            List<Category> allItems = Category.GetAll();
            return View(allItems);
        }
        [HttpGet("/category/new")]
        public ActionResult Createcategory()
        {
            return View();
        }
        [HttpGet("/items/delete/{id}")]
        public ActionResult Delete(int id)
        {
            Item.Delete(id);
            List<Item> allItems = Item.GetAll();
            return View("Index", allItems);
        }
        [HttpPost("/items/delete")]
        public ActionResult DeleteAll(int id)
        {
            Item.DeleteAll();
            List<Item> allItems = Item.GetAll();
            return View("items", allItems);
        }
        [HttpPost("/category/search")]
        public ActionResult Resultcategory()
        {
          Category selectedCategory = Category.Find(int.Parse(Request.Form["category"]));
          return View("Items", selectedCategory.GetItems());
        }
        [HttpGet("/category/search")]
        public ActionResult Searchcategory()
        {
          List<Category> allItems = Category.GetAll();
          return View(allItems);
        }
        [HttpGet("/category")]
        public ActionResult Displaycategory()
        {
            List<Category> allItems = Category.GetAll();
            return View("indexc", allItems);
        }
        [HttpPost("/items/search")]
        public ActionResult Resultitems()
        {
          Item selecteditems = Item.Find(int.Parse(Request.Form["item"]));
          return View("Indexc", selecteditems.GetCategories());
        }
        [HttpGet("/items/search")]
        public ActionResult Searchcatfromitems()
        {
          List<Item> allItems = Item.GetAll();
          return View(allItems);
        }


    }
}
