using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {

      [HttpGet("/items")]
      public ActionResult Index()
      {
          List<Item> allItems = Item.GetAll();
          return View(allItems);
      }

      [HttpGet("/items/new")]
      public ActionResult CreateForm()
      {
          return View();
      }

      [HttpPost("/items/create")]
      public ActionResult CreateItem()
      {
          Item newItem = new Item(Request.Form["new-item"]);
          newItem.Save();
          return View(newItem);
      }

      [HttpPost("/items/delete")]
      public ActionResult DeleteAll()
      {
          Item.ClearAll();
          return View();
      }
    }
}
