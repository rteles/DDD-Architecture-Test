using Arch.Application;
using Arch.Application.DataTypes.Request;
using Arch.Application.DataTypes.Result;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Arch.UI.MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var users = AppService.User.GetUsers(false);
            if (users.Success)
                return View(users.Data.ToList());

            return View(new List<UserResult>());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = AppService.User.GetUser(id);
            return View(user.Data);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(AddUserRequest request)
        {
            try
            {
                AppService.User.AddUser(request);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = AppService.User.GetUser(id);
            var userEdit = Mapper.DynamicMap<UserResult, UpdateUserRequest>(user.Data);
            return View(userEdit);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(UpdateUserRequest request)
        {
            try
            {
                AppService.User.UpdateUser(request);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = AppService.User.GetUser(id);
            return View(user.Data);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(UserResult user)
        //UserResult user)
        {
            try
            {
                AppService.User.DeleteUser(user.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
