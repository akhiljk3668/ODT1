using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODT.Data.ViewModels;
using ODT.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODT.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepositoy userRepositoy;

        public UserController(IUserRepositoy _userRepositoy)
        {
            userRepositoy = _userRepositoy;
        }
        // GET: UserController
        [Route("Users")]
        public async Task<IActionResult> Index()
        {
            return View(await userRepositoy.GetAllUserDetails());
        }

        // GET: UserController/Details/5
        public async Task<IActionResult> Details(long id)
        {
            return View(await userRepositoy.GetUserDetailById(id));
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
