using ApiConsumerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ApiConsumerApp.Controllers
{
    public class UsersMVCController : Controller
    {
        public ActionResult ViewUsers()
        {
            IEnumerable<UsersModel> userlist;
            HttpResponseMessage response = HttpClientVariable.ApiClient.GetAsync("Users").Result;
            userlist = response.Content.ReadAsAsync<IEnumerable<UsersModel>>().Result;
            return View(userlist);
             
        }
        // GET: UsersMVC
        public ActionResult Index()
        {
            IEnumerable<UsersModel> userlist;
            HttpResponseMessage response = HttpClientVariable.ApiClient.GetAsync("Users").Result;
            userlist = response.Content.ReadAsAsync<IEnumerable<UsersModel>>().Result;
            return View(userlist);
        }

        public ActionResult CreateUser()
        {
            return View();
        }

       [HttpPost]
        public ActionResult CreateUser(UsersModel Model)
        {
            HttpResponseMessage response = HttpClientVariable.ApiClient.PostAsJsonAsync("Users", Model).Result;
            TempData["Saved"] = "Saved Successfully";
            return RedirectToAction("Index");
        }

        public ActionResult UpdateUser(long? id)
        {
            
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            HttpResponseMessage response = HttpClientVariable.ApiClient.GetAsync("Users/"+id.ToString()).Result;
            if (response == null)
                {
                    return HttpNotFound();
                }
                return View(response.Content.ReadAsAsync<UsersModel>().Result);
            
        }
        [HttpPost]
        public ActionResult UpdateUser(UsersModel model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage response = HttpClientVariable.ApiClient.PutAsJsonAsync("Users/" + model.ID,model).Result;
            TempData["Updated"] = "Update Successfully";
            return RedirectToAction("Index");

        }

        public ActionResult DeleteUser(long? id)
        {
            HttpResponseMessage response = HttpClientVariable.ApiClient.DeleteAsync("Users/" +id.ToString()).Result;
            TempData["Deleted"] = "Delete Successfully";
            return RedirectToAction("Index");
        }
    }
}