using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using System.Diagnostics;
using Dominio;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}