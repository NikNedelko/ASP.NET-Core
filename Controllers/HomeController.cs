using System;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PartyInvites.Models;
using Partyinvites.Models;
using System.Linq;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon"; return View("MyView");
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                // Обнаружена ошибка проверки достоверности, 
                return View();
            }
        }
        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(r => (bool)(r.WillAttend = true)));
        }
    }
}
