using System;
using System.Collections.Generic;
using System.Linq;
using AplikacjaInternetowa.Models;
using AplikacjaInternetowa.Services;
using AplikacjaInternetowa.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AplikacjaInternetowa.Controllers
{
    public class TaskController : Controller
    {

        private TaskListService _contetx;

        public TaskController(TaskListService task)
        {
            _contetx = task;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Add(NewTaskViewModel newTaskViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(newTaskViewModel);
            }

            _contetx.Add(newTaskViewModel.Title, newTaskViewModel.Desc);

            return RedirectToAction("Index", "Home");
        }
    }
}